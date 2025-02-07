using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace _5_задание
{
    public enum DayOfWeek
    {
        Понедельник = 0,
        Вторник = 1,
        Среда = 2,
        Четверг = 3,
        Пятниццо = 4,
        Суббота = 5,
        Воскресенье = 6
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dob;
            string input;
            do
            {
                Console.WriteLine("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));
            int year = dob.Year;
            int month = dob.Month;
            int day = dob.Day;
            int dayofweek = (int)dob.DayOfWeek;
            int mon = month;
            Console.WriteLine($"{day}.{month}.{year}");
            if (mon == 12 || mon == 01 || mon == 02)
            {
                Console.WriteLine("Зима");
            }

            else if (mon == 03 || mon == 04 || mon == 05)
            {
                Console.WriteLine("Весна");
            }
            else if (mon == 09 || mon == 10 || mon == 11)
            {
                Console.WriteLine("Осень");
            }

            else if (mon == 07 || mon == 08 || mon == 09)
            {
                Console.WriteLine("Лето");
            }


          Console.WriteLine((DayOfWeek)((dayofweek - 1) % Enum.GetValues(typeof(DayOfWeek)).Length));
            Console.WriteLine(mon);
        }
    }
}
