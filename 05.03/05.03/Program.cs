//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _05._03
//{
//    internal class Program
//    {
//        //задача 1
//        public class Journal
//        {
//            private int _numberOfEmployees;

//            public int NumberOfEmployees
//            {
//                get => _numberOfEmployees;
//                set
//                {
//                    if (value < 0)
//                        throw new ArgumentException("Количество сотрудников не может быть отрицательным");
//                    _numberOfEmployees = value;
//                }
//            }

//            public Journal(int numberOfEmployees)
//            {
//                NumberOfEmployees = numberOfEmployees;
//            }

//            public static Journal operator +(Journal journal, int increase)
//            {
//                if (increase < 0)
//                    throw new ArgumentException("Увеличение не может быть отрицательным");
//                return new Journal(journal.NumberOfEmployees + increase);
//            }

//            public static Journal operator -(Journal journal, int decrease)
//            {
//                if (decrease < 0)
//                    throw new ArgumentException("Уменьшение не может быть отрицательным");
//                return new Journal(journal.NumberOfEmployees - decrease);
//            }

//            public static bool operator ==(Journal a, Journal b)
//            {
//                if (ReferenceEquals(a, b)) return true;
//                if (a is null || b is null) return false;
//                return a.NumberOfEmployees == b.NumberOfEmployees;
//            }

//            public static bool operator !=(Journal a, Journal b) => !(a == b);

//            public static bool operator <(Journal a, Journal b)
//            {
//                if (a is null || b is null)
//                    throw new ArgumentNullException("Объект журнала не может быть null");
//                return a.NumberOfEmployees < b.NumberOfEmployees;
//            }

//            public static bool operator >(Journal a, Journal b)
//            {
//                if (a is null || b is null)
//                    throw new ArgumentNullException("Объект журнала не может быть null");
//                return a.NumberOfEmployees > b.NumberOfEmployees;
//            }

//            public override bool Equals(object obj)
//            {
//                Journal other = obj as Journal;
//                if (ReferenceEquals(other, null))
//                    return false;

//                return this.NumberOfEmployees == other.NumberOfEmployees;
//            }

//            public override int GetHashCode() => _numberOfEmployees.GetHashCode();

//            public override string ToString() => $"Журнал [Сотрудники: {NumberOfEmployees}]";
//        }
//        //2 задача
//        public class Shop
//        {
//            private double _area;

//            public double Area
//            {
//                get => _area;
//                set
//                {
//                    if (value < 0)
//                        throw new ArgumentException("Площадь не может быть отрицательной");
//                    _area = value;
//                }
//            }

         
//            public Shop(double area)
//            {
//                Area = area;
//            }

         
//            public static Shop operator +(Shop shop, double increase)
//            {
//                if (increase < 0)
//                    throw new ArgumentException("Увеличение не может быть отрицательным");
//                return new Shop(shop.Area + increase);
//            }

     
//            public static Shop operator -(Shop shop, double decrease)
//            {
//                if (decrease < 0)
//                    throw new ArgumentException("Уменьшение не может быть отрицательным");
//                double newArea = shop.Area - decrease;
//                if (newArea < 0)
//                    throw new ArgumentException("Результирующая площадь не может быть отрицательной");
//                return new Shop(newArea);
//            }

//            public static bool operator ==(Shop a, Shop b)
//            {
//                if (ReferenceEquals(a, b)) return true;
//                if (a is null || b is null) return false;
//                return Math.Abs(a.Area - b.Area) < double.Epsilon;
//            }

    
//            public static bool operator !=(Shop a, Shop b) => !(a == b);

//            public static bool operator <(Shop a, Shop b)
//            {
//                if (a is null || b is null)
//                    throw new ArgumentNullException("Объект магазина не может быть null");
//                return a.Area < b.Area;
//            }

//            public static bool operator >(Shop a, Shop b)
//            {
//                if (a is null || b is null)
//                    throw new ArgumentNullException("Объект магазина не может быть null");
//                return a.Area > b.Area;
//            }


//            public override bool Equals(object obj)
//            {
//                Shop other = obj as Shop;
//                if (ReferenceEquals(other, null))
//                    return false;
//                return Math.Abs(this.Area - other.Area) < double.Epsilon;
//            }

         
//            public override int GetHashCode() => _area.GetHashCode();

        
//            public override string ToString() => $"Магазин [Площадь: {Area} м²]";
//        }
//        static void Main(string[] args)
//        {
//            //1 задача
//            var journal1 = new Journal(10);
//            var journal2 = new Journal(5);

//            var journal3 = journal1 + 3;
//            var journal4 = journal2 - 2;

//            Console.WriteLine(journal1 > journal2);
//            Console.WriteLine(journal3 == new Journal(13));
//            Console.WriteLine(journal4.Equals(new Journal(3)));
//            Console.WriteLine();
//            // 2 задача
//            var shop1 = new Shop(150.5);
//            var shop2 = new Shop(75.3);

      
//            var expandedShop = shop1 + 25.5;  
//            var reducedShop = shop2 - 15.3; 

            
//            Console.WriteLine(shop1 > shop2);     
//            Console.WriteLine(expandedShop == new Shop(176.0)); 
//            Console.WriteLine(reducedShop.Equals(new Shop(60.0))); 


//            try
//            {
//                var invalidShop = shop1 - 200.0;
//            }
//            catch (ArgumentException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }
//    }
//}
