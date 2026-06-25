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
            // Now T is only accepts classes 
            // Box<int> intBox = new Box<int>();

            Box<Book> bookBox = new Box<Book>();
         
        }

    }





    class Book
    {

    }

    
}  



