using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._04
{



    public interface IShawarma
    {
        string GetDescription();
        double GetCost();
    }


    public class BasicShawarma : IShawarma
    {
        public string GetDescription()
        {
            return "Лаваш";
        }

        public double GetCost()
        {
            return 50.0;
        }
    }


    public abstract class ShawarmaDecorator : IShawarma
    {
        protected readonly IShawarma _shawarma;

        protected ShawarmaDecorator(IShawarma shawarma)
        {
            _shawarma = shawarma;
        }

        public virtual string GetDescription()
        {
            return _shawarma.GetDescription();
        }

        public virtual double GetCost()
        {
            return _shawarma.GetCost();
        }
    }

    public class ChickenDecorator : ShawarmaDecorator
    {
        public ChickenDecorator(IShawarma shawarma) : base(shawarma) { }

        public override string GetDescription()
        {
            return _shawarma.GetDescription() + ", курица";
        }

        public override double GetCost()
        {
            return _shawarma.GetCost() + 35.0;
        }
    }

    public class BeefDecorator : ShawarmaDecorator
    {
        public BeefDecorator(IShawarma shawarma) : base(shawarma) { }

        public override string GetDescription()
        {
            return _shawarma.GetDescription() + ", говядина";
        }

        public override double GetCost()
        {
            return _shawarma.GetCost() + 45.0;
        }
    }

    public class VegetablesDecorator : ShawarmaDecorator
    {
        public VegetablesDecorator(IShawarma shawarma) : base(shawarma) { }

        public override string GetDescription()
        {
            return _shawarma.GetDescription() + ", овощи";
        }

        public override double GetCost()
        {
            return _shawarma.GetCost() + 15.0;
        }
    }

    public class CheeseDecorator : ShawarmaDecorator
    {
        public CheeseDecorator(IShawarma shawarma) : base(shawarma) { }

        public override string GetDescription()
        {
            return _shawarma.GetDescription() + ", сыр";
        }

        public override double GetCost()
        {
            return _shawarma.GetCost() + 20.0;
        }
    }

    public class SauceDecorator : ShawarmaDecorator
    {
        public SauceDecorator(IShawarma shawarma) : base(shawarma) { }

        public override string GetDescription()
        {
            return _shawarma.GetDescription() + ", соус";
        }

        public override double GetCost()
        {
            return _shawarma.GetCost() + 10.0;
        }
    }

    public class SpicyDecorator : ShawarmaDecorator
    {
        public SpicyDecorator(IShawarma shawarma) : base(shawarma) { }

        public override string GetDescription()
        {
            return _shawarma.GetDescription() + ", острое";
        }

        public override double GetCost()
        {
            return _shawarma.GetCost() + 5.0;
        }
    }


    public static class DecoratorFactory
    {
        private static readonly Dictionary<int, Func<IShawarma, IShawarma>> Decorators =
            new Dictionary<int, Func<IShawarma, IShawarma>>
        {
        {1, sh => new ChickenDecorator(sh)},
        {2, sh => new BeefDecorator(sh)},
        {3, sh => new VegetablesDecorator(sh)},
        {4, sh => new CheeseDecorator(sh)},
        {5, sh => new SauceDecorator(sh)},
        {6, sh => new SpicyDecorator(sh)}
        };

        public static IShawarma AddIngredient(int choice, IShawarma shawarma)
        {
            if (Decorators.TryGetValue(choice, out var decorator))
            {
                return decorator(shawarma);
            }
            return shawarma;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в конструктор шаурмы!");
            Console.WriteLine("База: лаваш (50 руб)");
            Console.WriteLine("\nДоступные добавки:");
            Console.WriteLine("1. Курица (+35 руб)");
            Console.WriteLine("2. Говядина (+45 руб)");
            Console.WriteLine("3. Овощи (+15 руб)");
            Console.WriteLine("4. Сыр (+20 руб)");
            Console.WriteLine("5. Соус (+10 руб)");
            Console.WriteLine("6. Острое (+5 руб)");
            Console.WriteLine("0. Завершить выбор\n");

            IShawarma shawarma = new BasicShawarma();

            while (true)
            {
                Console.Write("Выберите добавку (0-6): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Ошибка ввода. Попробуйте снова.");
                    continue;
                }

                if (choice == 0) break;

                if (choice < 1 || choice > 6)
                {
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    continue;
                }

                IShawarma newShawarma = DecoratorFactory.AddIngredient(choice, shawarma);

                if (newShawarma == shawarma)
                {
                    Console.WriteLine("Ошибка добавления ингредиента");
                }
                else
                {
                    shawarma = newShawarma;
                    Console.WriteLine($"Добавлен: {GetIngredientName(choice)}");
                }
            }

            Console.WriteLine("\nВаша шаурма:");
            Console.WriteLine(shawarma.GetDescription());
            Console.WriteLine($"Стоимость: {shawarma.GetCost():F2} руб");
        }

        private static string GetIngredientName(int choice)
        {
            switch (choice)
            {
                case 1: return "курица";
                case 2: return "говядина";
                case 3: return "овощи";
                case 4: return "сыр";
                case 5: return "соус";
                case 6: return "острое";
                default: return "неизвестный ингредиент";
            }
        }
    }
}
    
