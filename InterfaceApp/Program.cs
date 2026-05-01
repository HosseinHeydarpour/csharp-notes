using System.Xml.Serialization;

namespace InterfaceApp
{

    /*
     *  Decoupling: The Application class depends on the ILogger interface rather than the specific implementations
     *  like FileLogger or DatabaseLogger.
     *  This means you can easily switch the logging mechanism without changing the application class
     */




    internal class Program
    {

        // Interfaces: Why are decoupling and testability useful?
        //
        // Where is it useful?
        // - Interfaces are especially valuable in large applications where different
        //   components need to interact with each other in a loosely coupled way.
        // - By depending on abstractions instead of concrete implementations,
        //   components remain easier to test, replace, and extend.
        //
        // Real-world example:
        // - Suppose you have a PaymentService that processes customer payments.
        //   Without an interface, PaymentService might directly depend on a
        //   specific payment gateway like Stripe.
        //   This creates tight coupling.
        // - By creating an IPaymentGateway interface, PaymentService can work with
        //   *any* gateway (Stripe, PayPal, local bank API, mock service for tests)
        //   as long as it implements IPaymentGateway.
        // - This keeps the system flexible and makes testing easier because
        //   you can inject a fake or mock payment gateway in unit tests.


        // Interfaces: Decoupling and testability are useful
        //
        // Why is it useful?
        // - Interfaces help decouple code by reducing direct dependencies between classes.
        // - When classes depend on interfaces instead of concrete implementations,
        //   the code becomes easier to test, change, and maintain over time.
        //

        // Real-world example:
        // - Imagine an EmailNotificationService that sends emails to users.
        //   If EmailNotificationService directly depends on SmtpClient, it is
        //   tightly coupled to that specific email-sending implementation.
        // - By introducing an IEmailSender interface, EmailNotificationService
        //   only needs to know about IEmailSender, not SmtpClient.
        //   Any class that implements IEmailSender can be plugged in
        //   (e.g., SmtpEmailSender, SendGridEmailSender, FakeEmailSenderForTests).
        // - This makes it:
        //     * Easier to switch email providers without touching business logic.
        //     * Easier to unit test EmailNotificationService by injecting
        //       a FakeEmailSender that doesn’t send real emails.


        // Interfaces: Decoupling and testability are useful
        //
        // When is it useful?
        // - Use interfaces when you want to decouple the implementation details
        //   from the interface contract (the set of methods/properties a client
        //   can rely on).
        // - This is especially helpful in large and complex systems where
        //   implementations may change frequently, but the contract should stay stable.
        //
        // Real-world example:
        // - In an online store, you might define an IInventoryService interface
        //   with methods like ReserveItem, ReleaseItem, and GetStockLevel.
        // - At first, you implement it with a simple in-memory list
        //   (InMemoryInventoryService) for development.
        // - Later, you replace it with a DatabaseInventoryService that talks
        //   to a SQL database, and eventually with a MicroserviceInventoryClient
        //   that calls an external inventory microservice.
        // - Throughout these changes, the rest of the system (order processing,
        //   checkout, reporting) still depends only on IInventoryService,
        //   so you can swap implementations without rewriting your business logic.


        public interface ILogger
        {
            void Log(string message);
        }


        public class FileLogger : ILogger
        {
            public void Log(string message)
            {
                // In C# strings, the backslash '\' is an escape character used to represent special characters 
                // like '\n' (newline) or '\t' (tab). Because of this, a single '\' cannot be written directly 
                // inside a normal string literal. To represent an actual backslash character, it must be escaped 
                // by writing it twice: '\\'. Therefore "C:\\Logs" represents the path C:\Logs.
                //string directoryPath = "C:\\Logs";

                // The @ symbol creates a *verbatim string literal* in C#. In verbatim strings, the backslash '\' 
                // is not treated as an escape character, so you can write file paths with single backslashes 
                // (e.g., C:\Logs) without needing to escape them. This makes it easier and more readable for paths.
                string directoryPath = @"C:\Logs";
            

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, "log.txt");

                // everytime we run this code this will add hello word to the text file
                File.AppendAllText(filePath, message + "\n");
            }
        }


        public class DatabaseLogger : ILogger
        {
            public void Log(string message)
            {
                // Implement the logic to log a message to a database
                Console.WriteLine($"Logging to database. {message}");
            }

        }

        public class Application
        {
            private readonly ILogger _logger;
            public Application(ILogger logger)
            {
                _logger = logger;
            }


            public void DoWork() {

                _logger.Log("Work started!");
                // Do all the work!
                _logger.Log("Work done good job! ");
            }

        }
        static void Main(string[] args)
        {

            ILogger fileLogger = new FileLogger();
            Application application = new Application(fileLogger);

            application.DoWork();

            ILogger dbLogger = new DatabaseLogger();
            application = new Application(dbLogger);
            application.DoWork();


            Console.ReadKey();
        }


      

    }
}
