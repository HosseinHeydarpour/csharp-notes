using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Clean_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Order> orders = new List<Order>
           {
               new Order { Id = 1, ProductName = "Laptop", Quantity = 2, Price = 1500 },
               new Order { Id = 2, ProductName = "Phone", Quantity = 5, Price = 500 }
           };

            OrderPrinter printer = new OrderPrinter();
            printer.PrintOrderDetails(orders);

        }

    }


    public class Order
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
    }


    // Implementing KISS(Keep It Simple Stupid) Principle
    class OrderPrinter
    {
        public void PrintOrderDetails(List<Order> orders)
        {
            double totalPrice = 0;
            foreach (var order in orders)
            {
              
                if (order.Quantity > 0 && order.Price > 0)
                {
                    double total = order.Quantity * order.Price;
                    Console.WriteLine("Order ID: "+ order.Id);
                    Console.WriteLine("Product: "+ order.ProductName);
                    Console.WriteLine("Quantity: "+ order.Quantity);
                    Console.WriteLine("Price: " + order.Price);
                    Console.WriteLine("Total: "+ total);
                    Console.WriteLine("------------");

                    totalPrice += order.Quantity * order.Price;

                }
            }
           
           
            //foreach (var order in orders)
            //{   
            //    if(order.Quantity>0 && order.Price > 0)
            //    {
            //        totalPrice += order.Quantity * order.Price;
            //    }
            //}

            Console.WriteLine("Total Price: " + totalPrice);

        }
    }

    


}
