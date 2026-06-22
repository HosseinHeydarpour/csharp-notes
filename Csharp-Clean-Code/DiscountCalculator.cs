using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Clean_Code
{

    public enum CustomerType
    {
        Regular,
        Premium,
        Employee
    }


    internal class DiscountCalculator
    {

        private const int DISCOUNT_THERSHOLD = 1000;

        // Implementing DRY principle
        public double CalculateDiscount(CustomerType customerType,double totalAmount)
        {

            double discount = 0;

            switch(customerType)
            {
                case CustomerType.Regular:
                    discount = totalAmount >= DISCOUNT_THERSHOLD ? 0.1 : 0.05;
                    break;
                case CustomerType.Premium:
                    discount = totalAmount >= DISCOUNT_THERSHOLD ? 0.15 : 0.1;
                    break;
                case CustomerType.Employee:
                    discount = totalAmount >= DISCOUNT_THERSHOLD ? 0.2 : 0.15;
                    break;
            }


            return totalAmount * discount;
           
        }



        //public double CalculateDiscountForRegularCustomer(double totalAmount)
        //{
        //    if (totalAmount > 1000) 
        //    {
        //        return totalAmount * .1 ; // 10%  discount
        //    }
        //    else
        //    {
        //        return totalAmount * 0.05; // 5% discount
        //    }
        //}


        //public double CalculateDiscountForPremiumCustomer(double totalAmount)
        //{
        //    if (totalAmount > 1000) 
        //    {
        //        return totalAmount * .15; // 15%  discount
        //    } 
        //    else
        //    {
        //        return totalAmount * .1; // 10%  discount
        //    }
        
        //}

        //public double CalculateDiscountForEmployeeCustomer(double totalAmount)
        //{
        //    if (totalAmount > 1000)
        //    {
        //        return totalAmount * .2; // 20%  discount
        //    }
        //    else
        //    {
        //        return totalAmount * .15; // 15%  discount
        //    }

        //}
    }
}
