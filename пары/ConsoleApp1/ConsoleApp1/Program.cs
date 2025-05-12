using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        
        class Cletka : ICloneable
        {
            private string _gen;
            public Cletka (string gen)
            {
                _gen = gen;
            }
            public Cletka (Cletka c)
            {
                _gen = c._gen;
            }

            public object Clone()
            {
                return Cletka(_gen);
            }

        }
        static void Main(string[] args)
        {
            Cletka cletka = new Cletka("kik");
            Cletka cletka1 = Cletka()
        }
    }
}
