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
            
            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "Joe";


            CustomerService customerService = new CustomerService();
            customerService.GetCustomerById(1);
        }




    }

    /// <summary>
    /// Represents a customer with Id and Name
    /// </summary>

    public class Customer 
    {

        /// <summary>
        /// Gets the id of the customer
        /// </summary>
        public int Id { get;  }

        /// <summary>
        /// Gets or sets the name of the customer
        /// </summary>
        public string Name { get; set; }

    }

    /// <summary>
    /// Provides functionalities for handling customers
    /// </summary>
    public class CustomerService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"> The id for the customer to retrieve </param>
        /// <returns>Returns a customer found by id</returns>
        public Customer GetCustomerById(int customerId)
        {
            return new Customer { Name = "John Doe" };
        }

        public void SaveCustomer(Customer customer) 
        { 
            // TODO: Implement customer save logic
        
        }
    }
    


}
