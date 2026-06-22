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
            OrderProcessor processor = new OrderProcessor();

            Order order = new Order();

            // Bad way - we have to use braces even if we have only a single statement
            //if (processor.IsOrderValid(order))
            //Console.WriteLine("Order is valid");

            // Good way - we have to use braces even if we have only a single statement
            if (processor.IsOrderValid(order))
            {
                Console.WriteLine("Order is valid");
            }

            // Good way - we have to use braces even if we have only a single statement
            foreach (int i in int[1,2,3])
            {
                Console.WriteLine(i);
            }

        }

    }


    


}
