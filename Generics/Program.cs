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
            Action action = () =>
            {
                Console.WriteLine("Hello World");
            };

            action();

            // Func returns a value but action does not
            // We have to explicitly put the string between angle brackets
            Func<string> getName = () =>
            {
                return "Hossien";
            };

            var myName = getName();

            Console.WriteLine(myName);

            // Third one is the return value type
            // you can add up to 16 params here Func<...here...>
            Func<int, int, string> sum = (a, b) =>
            {
                return (a + b).ToString();
            };

            Console.WriteLine(sum(2,3));


        }

    }

 

}



