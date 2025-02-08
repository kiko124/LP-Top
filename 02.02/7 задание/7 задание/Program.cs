using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            if (num1 < num2) {
                (num1, num2) = (num2, num1);
            }

            foreach (var i in Enumerable.Range(num1, num2))
            {
                if (i % 2 == 0)
                {
                    Console.Write("\t", i);

                }
            }
            //for (;num1 <= num2; num1++) {
            //if (num1 % 2 == 0)
            //{
            //    sum += num1;


            //}
            //else
            //    return;

        }

    }
}
    

