using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
}

public class QuizResult
{
    public string QuizName { get; set; }
    public int Score { get; set; }
    public DateTime DateTaken { get; set; }
    public string UserLogin { get; set; }
}

public class Question
{
    public string Category { get; set; }
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public List<int> CorrectAnswers { get; set; }
}

public class Quiz
{
    public string Name { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
}

class Program
{
    private static List<User> users = new List<User>();
    private static List<Quiz> quizzes = new List<Quiz>();
    private static User currentUser = null;

    static void Main(string[] args)
    {
        LoadData();

        while (true)
        {
            if (currentUser == null) ShowLoginMenu();
            else if (currentUser.Login == "admin") AdminMenu();
            else UserMenu();
        }
    }

    static void LoadData()
    {
        if (File.Exists("users.json"))
            users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json"));

        if (File.Exists("quizzes.json"))
            quizzes = JsonConvert.DeserializeObject<List<Quiz>>(File.ReadAllText("quizzes.json"));
    }

    static void SaveData()
    {
        File.WriteAllText("users.json", JsonConvert.SerializeObject(users));
        File.WriteAllText("quizzes.json", JsonConvert.SerializeObject(quizzes));
    }

    static void ShowLoginMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Вход\n2. Регистрация\n3. Выход");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1": currentUser = Login(); break;
            case "2": Register(); break;
            case "3": SaveData(); Environment.Exit(0); break;
        }
    }

    static User Login()
    {
        Console.Write("Логин: ");
        var login = Console.ReadLine();
        Console.Write("Пароль: ");
        var password = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Login == login && u.Password == password);
        if (user != null) Console.WriteLine("Успешный вход!");
        else Console.WriteLine("Неверные данные!");

        Console.ReadKey();
        return user;
    }

    static void Register()
    {
        var newUser = new User();

        Console.Write("Логин: ");
        newUser.Login = Console.ReadLine();

        if (users.Any(u => u.Login == newUser.Login))
        {
            Console.WriteLine("Логин занят!");
            Console.ReadKey();
            return;
        }

        Console.Write("Пароль: ");
        newUser.Password = Console.ReadLine();

        Console.Write("Дата рождения (дд.мм.гггг): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
        {
            Console.WriteLine("Неверная дата!");
            Console.ReadKey();
            return;
        }
        newUser.DateOfBirth = birthDate;

        users.Add(newUser);
        Console.WriteLine("Регистрация успешна!");
        Console.ReadKey();
    }

    static void UserMenu()
    {
        Console.Clear();
        Console.WriteLine($"Добро пожаловать, {currentUser.Login}!\n" +
                          "1. Новая викторина\n2. Мои результаты\n3. Топ-20\n4. Настройки\n5. Выход");

        switch (Console.ReadLine())
        {
            case "1": StartQuiz(); break;
            case "2": ShowResults(); break;
            case "3": ShowTop20(); break;
            case "4": Settings(); break;
            case "5": currentUser = null; break;
        }
    }

    static void StartQuiz()
    {
        Console.Clear();
        Console.WriteLine("Выберите категорию:");
        for (int i = 0; i < quizzes.Count; i++)
            Console.WriteLine($"{i + 1}. {quizzes[i].Name}");
        Console.WriteLine($"{quizzes.Count + 1}. Смешанная");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > quizzes.Count + 1)
        {
            Console.WriteLine("Ошибка выбора!");
            Console.ReadKey();
            return;
        }

        List<Question> questions = new List<Question>();
        if (choice == quizzes.Count + 1)
            questions = quizzes.SelectMany(q => q.Questions).ToList();
        else
            questions = quizzes[choice - 1].Questions;

        if (questions.Count < 20)
        {
            Console.WriteLine("Недостаточно вопросов!");
            Console.ReadKey();
            return;
        }

        var random = new Random();
        var selectedQuestions = questions.OrderBy(q => random.Next()).Take(20).ToList();
        int score = 0;

        foreach (var q in selectedQuestions)
        {
            Console.Clear();
            Console.WriteLine(q.Text);
            for (int i = 0; i < q.Options.Count; i++)
                Console.WriteLine($"{i + 1}. {q.Options[i]}");

            var answers = Console.ReadLine()?
                .Split(' ')
                .Select(a => int.TryParse(a, out int num) ? num : -1)
                .Where(a => a > 0 && a <= q.Options.Count)
                .OrderBy(a => a)
                .ToList();

            if (answers != null && q.CorrectAnswers.OrderBy(a => a).SequenceEqual(answers))
                score++;
        }

        var result = new QuizResult
        {
            QuizName = choice <= quizzes.Count ? quizzes[choice - 1].Name : "Смешанная",
            Score = score,
            DateTaken = DateTime.Now,
            UserLogin = currentUser.Login
        };

        currentUser.QuizResults.Add(result);
        Console.WriteLine($"Ваш результат: {score}/20");
        Console.ReadKey();
    }

    static void ShowResults()
    {
        Console.Clear();
        foreach (var result in currentUser.QuizResults)
            Console.WriteLine($"{result.QuizName}: {result.Score} баллов ({result.DateTaken})");
        Console.ReadKey();
    }

    static void ShowTop20()
    {
        Console.Write("Название викторины: ");
        var name = Console.ReadLine();

        var results = users
            .SelectMany(u => u.QuizResults)
            .Where(r => r.QuizName == name)
            .OrderByDescending(r => r.Score)
            .ThenBy(r => r.DateTaken)
            .Take(20)
            .ToList();

        Console.Clear();
        for (int i = 0; i < results.Count; i++)
            Console.WriteLine($"{i + 1}. {results[i].UserLogin} - {results[i].Score} баллов");
        Console.ReadKey();
    }

    static void Settings()
    {
        Console.Clear();
        Console.WriteLine("1. Сменить пароль\n2. Изменить дату рождения");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Новый пароль: ");
                currentUser.Password = Console.ReadLine();
                break;
            case "2":
                Console.Write("Новая дата (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                    currentUser.DateOfBirth = newDate;
                else
                    Console.WriteLine("Ошибка даты!");
                break;
        }
    }

    static void AdminMenu()
    {
        Console.Clear();
        Console.WriteLine("Админ-панель\n1. Создать викторину\n2. Добавить вопрос\n3. Сохранить и выйти");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Название викторины: ");
                quizzes.Add(new Quiz { Name = Console.ReadLine() });
                break;

            case "2":
                Console.WriteLine("Выберите викторину:");
                for (int i = 0; i < quizzes.Count; i++)
                    Console.WriteLine($"{i + 1}. {quizzes[i].Name}");

                if (int.TryParse(Console.ReadLine(), out int quizIndex) && quizIndex > 0 && quizIndex <= quizzes.Count)
                {
                    var quiz = quizzes[quizIndex - 1];

                    // Запрос количества вопросов с валидацией
                    int questionsCount;
                    Console.WriteLine("Сколько вопросов желаете добавить:");
                    while (!int.TryParse(Console.ReadLine(), out questionsCount) || questionsCount <= 0)
                    {
                        Console.WriteLine("Некорректное число. Введите положительное число:");
                    }

                    for (int i = 0; i < questionsCount; i++)
                    {
                        Console.WriteLine($"\nВопрос {i + 1}/{questionsCount} (для выхода введите 'exit' в любое поле)");
                        var question = new Question();
                        bool exitRequested = false;

                        Console.Write("Категория: ");
                        var categoryInput = Console.ReadLine();
                        if (CheckForExit(categoryInput)) { exitRequested = true; break; }
                        question.Category = categoryInput;

            
                        Console.Write("Текст вопроса: ");
                        var textInput = Console.ReadLine();
                        if (CheckForExit(textInput)) { exitRequested = true; break; }
                        question.Text = textInput;

                        
                        question.Options = new List<string>();
                        Console.WriteLine("Варианты ответов (пустая строка для завершения):");
                        for (int j = 1; ; j++)
                        {
                            Console.Write($"{j}. ");
                            var option = Console.ReadLine();

                            if (CheckForExit(option)) { exitRequested = true; break; }
                            if (string.IsNullOrWhiteSpace(option)) break;

                            question.Options.Add(option);
                        }
                        if (exitRequested) break;
                        if (question.Options.Count == 0)
                        {
                            Console.WriteLine("Нужен хотя бы один вариант ответа! Вопрос отменен.");
                            continue;
                        }

                     
                        Console.Write("Правильные ответы (через пробел): ");
                        var answersInput = Console.ReadLine();
                        if (CheckForExit(answersInput)) { exitRequested = true; break; }

                        try
                        {
                            question.CorrectAnswers = answersInput.Split()
                                .Select(int.Parse)
                                .Select(n => n - 1)
                                .ToList();

                          
                            if (question.CorrectAnswers.Any(ans => ans < 0 || ans >= question.Options.Count))
                            {
                                Console.WriteLine("Ошибка в номерах ответов! Вопрос отменен.");
                                continue;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка формата ответов! Вопрос отменен.");
                            continue;
                        }

                        quiz.Questions.Add(question);
                        Console.WriteLine("Вопрос успешно добавлен!");
                    }

                    Console.WriteLine($"\nДобавлено вопросов: {quiz.Questions.Count}");
                }
                break;

            
                bool CheckForExit(string input)
                {
                    return input?.Trim().ToLower() == "exit";
                }
                

            case "3":
                SaveData();
                currentUser = null;
                break;
        }
    }
}