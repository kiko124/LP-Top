using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _13._04
{
    internal class Program
    {

        public interface IDiscountStrategy
        {
            void DiscountCalculate(double price);
        }

       
        class ClubCart : IDiscountStrategy
        {
            private string _cardNumber;
            private string _currencyCode;
            public int _count;
            public ClubCart(string cardNumber, string currencyCode)
            {
                _cardNumber = cardNumber;
                _currencyCode = currencyCode;
             }

            public void DiscountCalculate(double price)
            {
                Console.WriteLine($"С суммы {price}, была снята скидка равная сумме ваших баллов: {_count} ");
                _count++;
            }
        }
        class DiscountCart : IDiscountStrategy
        {
            private string _discardNumber;

            public DiscountCart(string discardNumber)
            {
                _discardNumber = discardNumber;
            }

            public void DiscountCalculate(double price)
            {
                
                Console.WriteLine($"С суммы {price}, была снята скидка по карте {_discardNumber} ");
                
                
                
            }
            
        } 

        class ShoppingCart
        {
           private IDiscountStrategy _strategy;
            private int _totalAmount;

            public ShoppingCart(IDiscountStrategy strategy, int totalAmount)
            {
                _strategy = strategy;
                _totalAmount = totalAmount;
            }

            public void AddItem(int amount)
            {
                _totalAmount += amount;
                Console.WriteLine($"Добавлен товар стоимостью {amount}. Общая стоимость корзины {_totalAmount}");
            }
            public void DiscountUse(int discount)
            {
               _totalAmount -= discount;
                Console.WriteLine($"Использованна скидка {discount}. Общая стоимость корзины {_totalAmount}");
            }
            public void Checkout()
            {
                if (_strategy == null)
                {
                    Console.WriteLine("Выберите вашу скидочную карту");
                    return;
                }
                _strategy.DiscountCalculate(_totalAmount);
               
            }
        }
 
        static void Main(string[] args)
        {





            IDiscountStrategy strategy = new DiscountCart("231232332");
                ShoppingCart cart = new ShoppingCart(strategy, 0);

                cart.AddItem(1000);
                cart.AddItem(100);
                cart.AddItem(10);
                cart.Checkout();
            cart.DiscountUse(1000);
            
        }
    }
}
