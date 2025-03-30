using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._02
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            
            int[] a = new int[5];
            double[,] b = new double[3, 4];
            for (int i = 0; i < a.Length; i++)
            { 
                a[i] = int.Parse(Console.ReadLine());
            }
            foreach (int item in a)
                Console.Write($"{item}\t");
            Console.WriteLine();

            Random random = new Random();
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i,j] = random.NextDouble() + random.Next(-100, 111);

                }


            }
            
            for (int j = 0; j < a.Length - 1; j++) /*i.Length-1 т.к. нумерация начинается с нуля, а Length показывает число объектов массива, если не написать -1, будет исключение*/
                textBox1.AppendText(a[j].ToString());

            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    Console.Write($"{b[i, j]}\t");
                }
                Console.WriteLine();

            }
            }
    }
}
