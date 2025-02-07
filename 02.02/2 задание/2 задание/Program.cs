using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            double num = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите проценты");
            int procent = int.Parse(Console.ReadLine());
            if (100 >= procent || procent >= 1) { }
            else
            {
                throw new Exception("Число вызло за диапозон!");
            }
            Console.WriteLine("Результат " + (num / 100 * procent));
           
        }
    }
}
