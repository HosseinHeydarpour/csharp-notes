using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Clean_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
          
        }




    }


    // Good indentation
    public class  Customer 
    {
        // props, fields at top
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void PrintFullName()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }

    }

    // Bad indentation
    //public class User
    //{
    //public int Id { get; set; }

    //public string FirstName { get; set; }

    //public string LastName { get; set; }

    //public void PrintFullName()
    //{
    //Console.WriteLine($"{FirstName} {LastName}");
    //}

    //}


    // Good indentation
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void PrintFullName()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }

    }


}
