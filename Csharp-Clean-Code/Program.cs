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

        // for method names it is best to use: Is, Get,Set,Has,Can

        public void SetCustomerName()
        {

        }

        public bool HasErrors()
        {
            return false;
        }

        public bool CanReceiveEmails()
        {
            return false; 
        }


        // bad approach
        public void Save()
        {

        }
        

        // good | because it is super obvious
        public void SaveCustomer()
        {

        }

        public void SaveCustomerName()
        {

        }

    }
  
}
