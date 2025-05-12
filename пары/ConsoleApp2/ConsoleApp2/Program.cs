using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        class GameConfig
        {
            public enum Config
            {
                Dif, Players
            }
            private static GameConfig instance;
            private GameConfig() { }
            public static GameConfig Instance
            {
                get {
                    if (instance == null) 
                        instance = new GameConfig();
                    return instance;
            }

        }
            public List<string>
                messages = new List<string>();
            public void Con(string messages, Config config)
            {
                Console.WriteLine($"ЛОГ {config}{messages}");
                messages 
            }

             

        static void Main(string[] args)
        {

        }
    }
}
