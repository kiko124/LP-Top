using System;
using System.Collections.Generic;

class Book : IEquatable<Book>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override bool Equals(object obj) => Equals(obj as Book);
    public bool Equals(Book other) => other != null && Title == other.Title && Author == other.Author;
    public override int GetHashCode() => HashCode.Combine(Title, Author);

    public static bool operator ==(Book left, Book right) => EqualityComparer<Book>.Default.Equals(left, right);
    public static bool operator !=(Book left, Book right) => !(left == right);

    public override string ToString() => $"{Title} ({Author}, {Year}г.)";
}

class ReadingList
{
    private List<Book> books = new List<Book>();

    public int Count => books.Count;

    // Индексатор
    public Book this[int index]
    {
        get
        {
            if (index < 0 || index >= books.Count)
                throw new IndexOutOfRangeException("Книга с таким индексом не найдена");
            return books[index];
        }
        set
        {
            if (index < 0 || index >= books.Count)
                throw new IndexOutOfRangeException("Книга с таким индексом не найдена");
            books[index] = value;
        }
    }

    // Основные методы
    public void AddBook(Book book) => books.Add(book);
    public bool RemoveBook(Book book) => books.Remove(book);
    public bool Contains(Book book) => books.Contains(book);

    // Перегрузка оператора + (возвращает новый список)
    public static ReadingList operator +(ReadingList list, Book book)
    {
        list.AddBook(book);
        return list;
    }

    // Перегрузка оператора - (возвращает новый список)
    public static ReadingList operator -(ReadingList list, Book book)
    {
        var newList = new ReadingList();
        foreach (var b in list.books)
        {
            if (b != book)
                newList.AddBook(b);
        }
        return newList;
    }

    // Перегрузка операторов сравнения
    public static bool operator ==(ReadingList left, ReadingList right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        if (left.Count != right.Count) return false;

        for (int i = 0; i < left.Count; i++)
        {
            if (left[i] != right[i]) return false;
        }
        return true;
    }

    public static bool operator !=(ReadingList left, ReadingList right) => !(left == right);

    public override bool Equals(object obj) => obj is ReadingList other && this == other;
    public override int GetHashCode() => books.GetHashCode();

    public void PrintList()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст!");
            return;
        }

        Console.WriteLine("\nВаш список книг для прочтения:");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ReadingList myList = new ReadingList();

        while (true)
        {
            Console.WriteLine("\n--- Меню управления списком книг ---");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Проверить наличие книги");
            Console.WriteLine("4. Показать все книги");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddBookMenu(myList);
                    break;
                case "2":
                    RemoveBookMenu(myList);
                    break;
                case "3":
                    CheckBookMenu(myList);
                    break;
                case "4":
                    myList.PrintList();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddBookMenu(ReadingList list)
    {
        Console.Write("Введите название: ");
        string title = Console.ReadLine();

        Console.Write("Введите автора: ");
        string author = Console.ReadLine();

        Console.Write("Введите год издания: ");
        int year = int.Parse(Console.ReadLine());

        Book newBook = new Book(title, author, year);
        list.AddBook(newBook);
        Console.WriteLine($"Книга '{title}' добавлена в список!");
    }

    static void RemoveBookMenu(ReadingList list)
    {
        Console.Write("Введите название книги для удаления: ");
        string title = Console.ReadLine();

        Console.Write("Введите автора: ");
        string author = Console.ReadLine();

        Book bookToRemove = new Book(title, author, 0);

        if (list.RemoveBook(bookToRemove)) // Используем метод, возвращающий bool
        {
            Console.WriteLine($"Книга '{title}' удалена из списка!");
        }
        else
        {
            Console.WriteLine("Книга не найдена в списке.");
        }
    }

    static void CheckBookMenu(ReadingList list)
    {
        Console.Write("Введите название книги: ");
        string title = Console.ReadLine();

        Console.Write("Введите автора: ");
        string author = Console.ReadLine();

        Book bookToFind = new Book(title, author, 0);
        Console.WriteLine(list.Contains(bookToFind)
            ? $"Книга '{title}' есть в вашем списке"
            : "Этой книги нет в вашем списке");
    }
}