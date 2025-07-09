using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GameConfig
        {
            public string Difficulty { get; set; } = "Medium";
            public int PlayerCount { get; set; } = 1;
            public bool EnableSound { get; set; } = true;
            public int GameDuration { get; set; } = 60; 

            public void DisplayConfig()
            {
                Console.WriteLine("Текущая конфигурация игры:");
                Console.WriteLine($"• Сложность: {Difficulty}");
                Console.WriteLine($"• Количество игроков: {PlayerCount}");
                Console.WriteLine($"• Звук: {(EnableSound ? "Включен" : "Выключен")}");
                Console.WriteLine($"• Продолжительность игры: {GameDuration} мин");
                Console.WriteLine();
            }
        }


        public sealed class GameConfigManager
        {
            private static readonly Lazy<GameConfigManager> instance =
                new Lazy<GameConfigManager>(() => new GameConfigManager());

            public static GameConfigManager Instance => instance.Value;

            public GameConfig CurrentConfig { get; private set; }

            private GameConfigManager()
            {
              
                CurrentConfig = new GameConfig();
            }

       
            public void UpdateConfig(GameConfig newConfig)
            {
                if (newConfig == null)
                    throw new ArgumentNullException(nameof(newConfig));

                CurrentConfig = newConfig;
            }

           
            public void UpdateConfig(Action<GameConfig> updateAction)
            {
                if (updateAction == null)
                    throw new ArgumentNullException(nameof(updateAction));

                updateAction(CurrentConfig);
            }
        }
    internal class Program
    {
            static void Main()
            {
             
                var configManager = GameConfigManager.Instance;

                configManager.CurrentConfig.DisplayConfig();

            
                var newConfig = new GameConfig
                {
                    Difficulty = "Hard",
                    PlayerCount = 4,
                    EnableSound = false,
                    GameDuration = 90
                };

                configManager.UpdateConfig(newConfig);
                Console.WriteLine("Конфигурация полностью обновлена:");
                configManager.CurrentConfig.DisplayConfig();
                configManager.UpdateConfig(config => {
                    config.Difficulty = "Easy";
                    config.PlayerCount = 2;
                    config.EnableSound = true;
                });

                Console.WriteLine("Конфигурация частично обновлена:");
                configManager.CurrentConfig.DisplayConfig();

                var anotherInstance = GameConfigManager.Instance;
                Console.WriteLine($"Один и тот же экземпляр? {configManager == anotherInstance}");
            }
        }
    }

