using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        abstract class Shawarma
        {
            public Shawarma(string n)
            {
                this.Name = n;
            }
            public string Name { get; protected set; }
            public abstract int GetCost();
        }

        class IShawarma : Shawarma
        {
            public IShawarma() : base("Шаверма")
            { }
            public override int GetCost()
            {
                return 10;
            }
        }
        class ChickenShawarma : Shawarma
        {
            public ChickenShawarma()
                : base("Болгарская пицца")
            { }
            public override int GetCost()
            {
                return 8;
            }
        }
        abstract class ShawarmaDecorate : Shawarma
        {
            protected Shawarma shawarma;
            public ShawarmaDecorate(string n, Shawarma shawarma) : base(n)
            {
                this.shawarma = shawarma;
            }
        }
        class TomatoShawarma : ShawarmaDecorate
        {
            public TomatoShawarma(Shawarma p)
                : base(p.Name + ", с томатами", p)
            { }

            public override int GetCost()
            {
                return shawarma.GetCost() + 3;
            }
        }
        class CheeseShawarma : ShawarmaDecorate
        {
            public CheeseShawarma(Shawarma p)
                : base(p.Name + ", с сыром", p)
            { }

            public override int GetCost()
            {
                return shawarma.GetCost() + 5;
            }
        }

        static void Main(string[] args)
        {
            Shawarma order = new ChickenShawarma();

            order = new CheeseShawarma(order);
            order = new TomatoShawarma(order);
            PrintOrder(order);
            
        }
        static void PrintOrder(Shawarma shawarma)
            {
                Console.WriteLine($"стоимость: {shawarma.GetCost()} руб.");
            }
    }
}

