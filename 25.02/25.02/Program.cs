using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#region Задание 1
public static class NumberConverter
{
    public static void ConvertNumber()
    {
        try
        {
            Console.WriteLine("Выберите направление конвертации:");
            Console.WriteLine("1. Десятичная -> Двоичная");
            Console.WriteLine("2. Десятичная -> Шестнадцатеричная");
            Console.WriteLine("3. Двоичная -> Десятичная");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    int dec = Convert.ToInt32(input);
                    Console.WriteLine($"Результат: {Convert.ToString(dec, 2)}");
                    break;
                case 2:
                    int decHex = Convert.ToInt32(input);
                    Console.WriteLine($"Результат: {decHex:X}");
                    break;
                case 3:
                    int bin = Convert.ToInt32(input, 2);
                    Console.WriteLine($"Результат: {bin}");
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка формата ввода");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Число вне диапазона int");
        }
    }
}
#endregion

#region Задание 2
public static class WordToNumberConverter
{
    private static readonly Dictionary<string, int> WordMap = new Dictionary<string, int>
    {
        {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
        {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
    };

    public static void ConvertWord()
    {
        Console.Write("Введите число словами (англ): ");
        string input = Console.ReadLine().ToLower();

        if (WordMap.TryGetValue(input, out int number))
        {
            Console.WriteLine($"Результат: {number}");
        }
        else
        {
            Console.WriteLine("Неизвестное слово");
        }
    }
}
#endregion

#region Задание 3
public class ForeignPassport
{
    private string _number;
    private string _fullName;
    private DateTime _issueDate;

    public ForeignPassport(string number, string fullName, DateTime issueDate)
    {
        if (string.IsNullOrWhiteSpace(number) || number.Length != 9)
            throw new ArgumentException("Неверный формат номера");

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("ФИО не может быть пустым");

        _number = number;
        _fullName = fullName;
        _issueDate = issueDate;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Номер: {_number}");
        Console.WriteLine($"ФИО: {_fullName}");
        Console.WriteLine($"Дата выдачи: {_issueDate:dd.MM.yyyy}");
    }
}
#endregion

#region Задание 4
public static class BooleanEvaluator
{
    public static void EvaluateExpression()
    {
        try
        {
            Console.Write("Введите выражение (например 3>2): ");
            string input = Console.ReadLine();

            var parts = input.Split(new[] { '<', '>', '=', '!' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) throw new FormatException();

            int a = int.Parse(parts[0]);
            int b = int.Parse(parts[1]);
            string op = new string(input.Where(c => !char.IsDigit(c)).ToArray()).Trim();

            bool result;
            switch (op)
            {
                case "<":
                    result = a < b;
                    break;
                case ">":
                    result = a > b;
                    break;
                case "<=":
                    result = a <= b;
                    break;
                case ">=":
                    result = a >= b;
                    break;
                case "==":
                    result = a == b;
                    break;
                case "!=":
                    result = a != b;
                    break;
                default:
                    throw new ArgumentException("Неверный оператор");
            }

            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
        {
            Console.WriteLine("Ошибка ввода выражения");
        }
    }
}
#endregion

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание (1-4):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                NumberConverter.ConvertNumber();
                break;

            case 2:
                WordToNumberConverter.ConvertWord();
                break;

            case 3:
                try
                {
                    var passport = new ForeignPassport(
                        "AB1234567",
                        "Иванов Иван Иванович",
                        new DateTime(2020, 5, 15)
                    );
                    passport.DisplayInfo();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                break;

            case 4:
                BooleanEvaluator.EvaluateExpression();
                break;

            default:
                Console.WriteLine("Неверный выбор");
                break;
        }
    }
}