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
            DiscountCalculator discountCalculator = new DiscountCalculator();

            double regularCustomerDiscount = discountCalculator.CalculateDiscount(CustomerType.Regular, 1200);
            Console.WriteLine($"Regular Customer Discount: {regularCustomerDiscount}$" );


            double premiumCustomerDiscount = discountCalculator.CalculateDiscount(CustomerType.Premium, 800);
            Console.WriteLine($"Premium Customer Discount: {premiumCustomerDiscount}$");


            double employeeCustomerDiscount = discountCalculator.CalculateDiscount(CustomerType.Employee,1500);
            Console.WriteLine($"Employee Customer Discount: {employeeCustomerDiscount}$");

        }

    }


    


}
