using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Clean_Code
{

    // We have multiple responsibilities here
    // so we create two new classes - and order service class remains as coordinator
    public class OrderService
    {

        private List<Order> orders = new List<Order>();

        private OrderLogger orderLogger  =  new OrderLogger();
        private OrderNotifier orderNotifier = new OrderNotifier();


        public void AddOrder(Order order)
        {
            orders.Add(order);
            orderLogger.LogOrder(order);
            orderNotifier.NotifyCustomer(order);
            
        }


    }

    // In the real word create these classes in a new file
    public class OrderLogger
    {
        public void LogOrder(Order order)
        {
            // Log the order to a file
            Console.WriteLine($"Order {order.Id} logged.");
        }
    }



    public class OrderNotifier
    {
        public void NotifyCustomer(Order order)
        {
            // Send a notification to the customer
            Console.WriteLine($"Customer notified for order {order.Id}. ");
        }
    }
}
