using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {

            static void Main(string[] args)
        {
            Console.WriteLine("Выберите что вы желаете сделать: ");
            Console.WriteLine("1. Регистрация");
            Console.WriteLine("2. Вход");
            Console.WriteLine("3. Выход из программы");
            int var = int.Parse(Console.ReadLine());

            switch (var)
            {
                case 1:
                    User user;
                    Person tom = new Person("Tom", 37);

                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<Person>(tom, options);
                    Console.WriteLine(json);
                    Person? restoredPerson = JsonSerializer.Deserialize<Person>(json);
                    Console.WriteLine(restoredPerson?.Name);
                    break;
                case 2:

                    break;
                case 3:

                    return;
                    

            }

            
        }
    }
}
