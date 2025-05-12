using System;
using System.Collections.Generic;
using System.Linq;

#region Задание 1
public static class SquareDrawer
{
    public static void DrawSquare(int length, char symbol)
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }
    }
}
#endregion

#region Задание 2
public static class PalindromeChecker
{
    public static bool IsPalindrome(int number)
    {
        string numStr = number.ToString();
        return numStr.SequenceEqual(numStr.Reverse());
    }
}
#endregion

#region Задание 3
public static class ArrayFilter
{
    public static int[] FilterArray(int[] original, int[] filter)
    {
        return original.Where(x => !filter.Contains(x)).ToArray();
    }
}
#endregion

#region Задание 4
public class Website
{
    private string _name;
    private string _url;
    private string _description;
    private string _ip;

    public void SetData(string name, string url, string description, string ip)
    {
        _name = name;
        _url = url;
        _description = description;
        _ip = ip;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Название: {_name}");
        Console.WriteLine($"URL: {_url}");
        Console.WriteLine($"Описание: {_description}");
        Console.WriteLine($"IP: {_ip}");
    }

    public string GetName() => _name;
    public string GetUrl() => _url;
    public string GetDescription() => _description;
    public string GetIp() => _ip;
}
#endregion

#region Задание 5
public class Magazine
{
    private string _name;
    private int _year;
    private string _description;
    private string _phone;
    private string _email;

    public void SetData(string name, int year, string description, string phone, string email)
    {
        _name = name;
        _year = year;
        _description = description;
        _phone = phone;
        _email = email;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Название: {_name}");
        Console.WriteLine($"Год основания: {_year}");
        Console.WriteLine($"Описание: {_description}");
        Console.WriteLine($"Телефон: {_phone}");
        Console.WriteLine($"Email: {_email}");
    }

    public string GetName() => _name;
    public int GetYear() => _year;
    public string GetDescription() => _description;
    public string GetPhone() => _phone;
    public string GetEmail() => _email;
}
#endregion

#region Задание 6
public class Shop
{
    private string _name;
    private string _address;
    private string _profile;
    private string _phone;
    private string _email;

    public void SetData(string name, string address, string profile, string phone, string email)
    {
        _name = name;
        _address = address;
        _profile = profile;
        _phone = phone;
        _email = email;
    }

    public void DisplayData()
    {
        Console.WriteLine($"Название: {_name}");
        Console.WriteLine($"Адрес: {_address}");
        Console.WriteLine($"Профиль: {_profile}");
        Console.WriteLine($"Телефон: {_phone}");
        Console.WriteLine($"Email: {_email}");
    }

    public string GetName() => _name;
    public string GetAddress() => _address;
    public string GetProfile() => _profile;
    public string GetPhone() => _phone;
    public string GetEmail() => _email;
}
#endregion

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание (1-6):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Введите длину стороны: ");
                int length = int.Parse(Console.ReadLine());
                Console.Write("Введите символ: ");
                char symbol = Console.ReadLine()[0];
                SquareDrawer.DrawSquare(length, symbol);
                break;

            case 2:
                Console.Write("Введите число: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(PalindromeChecker.IsPalindrome(number) ? "Палиндром" : "Не палиндром");
                break;

            case 3:
                int[] original = { 1, 2, 6, -1, 88, 7, 6 };
                int[] filter = { 6, 88, 7 };
                int[] result = ArrayFilter.FilterArray(original, filter);
                Console.WriteLine("Результат: " + string.Join(" ", result));
                break;

            case 4:
                Website site = new Website();
                site.SetData("Google", "https://google.com", "Поисковик", "142.250.185.206");
                site.DisplayData();
                break;

            case 5:
                Magazine mag = new Magazine();
                mag.SetData("National Geographic", 1888, "Научный журнал", "+123456789", "contact@natgeo.com");
                mag.DisplayData();
                break;

            case 6:
                Shop shop = new Shop();
                shop.SetData("Пятерочка", "ул. Ленина 1", "Продуктовый", "+78005553535", "shop@5ka.ru");
                shop.DisplayData();
                break;

            default:
                Console.WriteLine("Неверный выбор");
                break;
        }
    }
}