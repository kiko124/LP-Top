using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 число");
            string a = Console.ReadLine();
            Console.WriteLine("Введите 2 число");
            string b = Console.ReadLine();
            Console.WriteLine("Введите 3 число");
            string c = Console.ReadLine();
            Console.WriteLine("Введите 4 число");
            string d = Console.ReadLine();
            int num = int.Parse(a.ToString() + b.ToString() + c.ToString() + d.ToString());
            Console.WriteLine(num);
        }
    }
}
