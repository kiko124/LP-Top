using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _4_задание
{
   
    internal class Program
    {
        
        static void Main(string[] args)
        {
           
            Console.WriteLine("Введите 6 значное число");
            int b = int.Parse(Console.ReadLine());
            if ((b < 100000) || (b > 999999)) 
            {
                Console.WriteLine("Введенно не 6 знач число");
                return;
            }
            Console.WriteLine("Введите два числа");
            int d = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            string str = b.ToString();
            char[] bArr = str.ToCharArray();
            string result = string.Empty;
            (bArr[d - 1], bArr[c - 1]) = (bArr[c - 1], bArr[d - 1]);
            foreach (char item in bArr)
            {
                result += item;
            }


            Console.WriteLine(result);

        }
    }
    }