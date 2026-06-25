using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We cannot do this because of the constraint we have set for AreEqual method
            // Comparer.AreEqual(2, 3);

            var productOne = new Product();
            var productTwo = new Product();
            var res1 = Comparer.AreEqual(productOne, productOne);
            var res2 = Comparer.AreEqual(productOne, productTwo);
            Console.WriteLine($"Result 1: {res1}, Result 2: {res2}");
   
            
         
        }

    }


    public class Product
    {

    }

  


    
}  



