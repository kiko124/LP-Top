
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите желаемую температуру: ");
            Console.WriteLine("1. Фаренгейт");
            Console.WriteLine("2. Цельсии");
            int a = int.Parse(Console.ReadLine());
            double itogc, itogf;

            switch (a)
            {
                case 1:
                    Console.WriteLine("Введите температуру в Цельсиях: ");
                    int temp = int.Parse(Console.ReadLine());
                    itogf = (temp * 9 / 5) + 32;
                    Console.WriteLine("Ваша температура в Фаренгейтах: " + itogf);
                    break;
                case 2:
                    Console.WriteLine("Введите температуру в Фаренгейтах: ");
                    int temp2 = int.Parse(Console.ReadLine());
                    itogc = ((temp2 - 32) * 5) / 9;
                    Console.WriteLine("Ваша температура в Цельсиях: " + itogc);
                    break;
                default:
                    break;
            }

        }
    }
}
