using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // set a break point at the next like
            // Type type = typeof(ConfigurationManager<>);

            string myName = "Hossein";


            if(myName.GetType() == typeof(string))
            {
                Console.WriteLine("Hey this is a string");
            }

        }

    }

    public class ConfigurationManager<T>
    {
        public T LoadedConfiguration { get; set; }

        public ConfigurationManager(T config) 
        {
            LoadedConfiguration = config;
        }



        public static void SaveConfig(T configToSave)
        {
            // Logic
        }

    }

}



