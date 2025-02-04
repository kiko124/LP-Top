using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LP_02._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            int b = Convert.ToInt32(a);
            if (100 >= b || b >= 1) { }
            else
            {
                throw new Exception("Число вызло за диапозон!");
            }
                if (b % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (b % 5 == 0) {
            
                Console.WriteLine("Buzz");
            }
            else
                {
                    Console.WriteLine(b);
                }


        }
    }
}
