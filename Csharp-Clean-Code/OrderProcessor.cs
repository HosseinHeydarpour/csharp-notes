using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Clean_Code
{
    internal class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
           
            if (IsOrderValid(order))
            {
                SaveOrder(order);
                NotifyCustomer(order);
            }

            
        }


        public bool IsOrderValid(Order order)
        {
            // TODO: Validate order logic
            return false;
        }

        private void SaveOrder(Order order)
        {
            // TODO: Save order logic
        }

        private void NotifyCustomer(Order order)
        {
            // TODO: Notify Customer
        }
    }
}
