using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Csharp_Clean_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 1,
                ProductName = "Test",
                Quantity = 1,
                Price = 100,
            };

            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            
        }




    }


 


}
