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



    class CustomerService
    {
        // _camleCase
        private string _customerName = "JohnDoe";

        // another way for private fields
        //private string customerName = "JohnDoe";

        public CustomerService(string customerName) 
        { 
            _customerName = customerName;

            // another way for private fields | using this to avoid conflict and error
            //this.customerName = customerName;
        }

    }
}
