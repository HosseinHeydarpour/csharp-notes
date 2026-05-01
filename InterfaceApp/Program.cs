using System.Xml.Serialization;

namespace InterfaceApp
{
    internal class Program
    {


        


        /*
            Interfaces and Polymorphism in Payment Processing
            
            IPaymentProcessor
                - CreditCardProcessor: Implements and processes credit card payments
                - PaypalProcessor: Implements and processes PayPal payments
            
            PaymentService
                - Uses an IPaymentProcessor to process payments
                - ProcessOrderPayment: Delegates payment processing to IPaymentProcessor
            
            Program
                - Sets up and uses PaymentService
                - Main: Initiates payment processing with different processors
        */



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
            
            // Polymorphism line
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
