using System.Xml.Serialization;

namespace InterfaceApp
{
    internal class Program
    {


        // Why Polymorphic Interfaces?
        //
        // 1. Where:
        //
        // When you need different classes to implement the same
        // set of methods or properties.
        //
        // This ensures consistency and allows for flexible
        // implementations.


        // Why Polymorphic Interfaces?
        //
        // 2. Why:
        //
        // Promotes code reusability and flexibility.
        //
        // Different classes can implement the same interface
        // in various ways, allowing for diverse behavior while
        // maintaining a common contract.

        // Why Polymorphic Interfaces?
        //
        // 3. When:
        //
        // Use interfaces when you have multiple classes that
        // should provide the same functionality but might
        // implement it differently.
        //
        // Real-World Example: Payment Processing System


        public interface IPaymentProcessor 
        {
            void ProcessPayment(decimal amount);
        }

        public class CreditCardProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                Console.WriteLine("Processing credit card payment of: "+amount);
                // Implement the credit card payment logic
            }
        }


        public class PaypalProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                Console.WriteLine("Processing paypal payment of: " + amount);
                // Implement the paypal payment logic
            }

        
        }


        public class PaymentService
        {
            private readonly IPaymentProcessor _processor;


            public PaymentService(IPaymentProcessor processor)
            {
                _processor = processor;
            }

            public void ProcessOrederPayment(decimal amount) {
                _processor.ProcessPayment(amount);
            }
        }

        static void Main(string[] args)
        {
            
            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            PaymentService paymentService = new PaymentService(creditCardProcessor);

            // m for decimal
            paymentService.ProcessOrederPayment(100.30m);

            IPaymentProcessor paypalProcessor = new PaypalProcessor();  
            PaymentService paymentService1 = new PaymentService(paypalProcessor);

            paymentService1.ProcessOrederPayment(200m);
          
            Console.ReadKey();
        }


      

    }
}
