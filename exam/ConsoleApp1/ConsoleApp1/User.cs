using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    internal class User
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public int Date { get; set; }

        User(string login, string pass, int date)
        {
            Login = login;
            Password = pass;
            Date = date;
        }

        void Regis()
        {
            string json = JsonSerializer.Serialize(car);
            File.WriteAllText(path, json);

        }


    }
}
