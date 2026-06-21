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


    // class naming follow PascalCase 
    // starts always with CAPITAL letter and the second word is also in Capital
    class CustomerService
    {
        public const int MAX_CUSTOMERS = 100; // ALL_CAPS 

        // Props in the classes follow PascalCase naming convention
        public int CustomerCount { get; set; }

        // for private fields we use the camelCase naming convetion
        private string lastCustomerName = "John";

        // Again for methods we use PascalCase
        public string GetCustomerName(int customerId) // customerId is with camelCase too 
        {

            // we use camelCase for loacl variables too
            string customerName = "John Doe";

            return name;
        }
    }
}
