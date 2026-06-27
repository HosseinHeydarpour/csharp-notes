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
            Predicate<int> isEven = (x) =>
            {
                return x % 2 == 0; 
            };

       
            //Console.WriteLine(isEven(7) ? "Even" : "Odd");
            //Console.WriteLine(isEven(8) ? "Even" : "Odd");

            List<int> list = new List<int>() {1,2,3,4,5,6,7,8 };


            //foreach (int x in list)
            //{
            //    Console.WriteLine(isEven(x) ? "Even" : "Odd");
            //}

            var evenInts = list.FindAll(isEven);

            foreach (int i in evenInts)
            {
                Console.WriteLine(i);
            }

 

}}}



