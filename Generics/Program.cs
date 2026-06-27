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


            Action<int> numPrint = x =>
            {
                Console.WriteLine(x);
            };

            numPrint(10);


            Action<float, float, float> sum = (x, y, z) =>
            {
                Console.WriteLine(x + y + z);
            };

            sum(1.2f, 1.3f, 1.2f);

        }

    }

 

}



