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
            Invoice invoice = new Invoice {Amount = 1000 };
            BillingsService billingsService = new BillingsService();

            double total = billingsService.CalculateTotal(invoice);

            Console.WriteLine($"Total: {total}");


            DiscountedInvoice discountedInvoice = new DiscountedInvoice {Amount = 100, Discount=5 };
            DiscountedBillingService discountedBillingService   = new DiscountedBillingService();
            Console.WriteLine("Total: "+discountedBillingService.CalculateTotal(discountedInvoice));
            
        }




    }


    public class Invoice
    {
        public double Amount { get; set;}
    }

    // We extend the app and do not change the functionalities
    public class DiscountedInvoice : Invoice
    {
        public double Discount { get; set; }
    }

    public class BillingsService
    {
        public virtual double CalculateTotal(Invoice invoice)
        {
            return invoice.Amount;
        }
    }
 

    public class DiscountedBillingService: BillingsService
    {
        public override double CalculateTotal(Invoice invoice)
        {

            if(invoice is DiscountedInvoice discountedInvoice)
            {
                return discountedInvoice.Amount - discountedInvoice.Discount;
            }

            return base.CalculateTotal(invoice);
        }
    }


}
