using System.Xml.Serialization;

namespace InterfaceApp
{
    // Why Interface Dependency Injection?
    //
    // Flexibility!
    // - Interface Injection provides flexibility because the class
    //   receives its dependencies through an interface-defined method.
    // - This means the class does NOT control how the dependency is created.
    //   Instead, an external source injects it at runtime.
    //
    // Explanation:
    // - The interface defines a method like SetDependency(...).
    // - Any class that needs the dependency must implement this method.
    // - This makes switching or updating dependencies easy,
    //   because the injector only depends on the interface,
    //   not on concrete implementations.
    //
    // Real-world example:
    //
    // Imagine a modular application with plugins.
    // Each plugin may need a Logger, but the core system doesn't want
    // to hard‑code how each plugin gets its logger.
    //
    // public interface ILoggerInjector
    // {
    //     void SetLogger(ILogger logger);
    // }
    //
    // public class PaymentPlugin : ILoggerInjector
    // {
    //     private ILogger _logger;
    //
    //     public void SetLogger(ILogger logger)
    //     {
    //         _logger = logger;
    //     }
    //
    //     public void Process()
    //     {
    //         _logger.Log("Payment plugin processing");
    //     }
    // }
    //
    // Why this is useful:
    // - The main system creates the Logger service only once.
    // - Each plugin receives the same logger instance via the interface method.
    // - Plugins stay flexible, loosely coupled, and easy to extend.
    //
    // Summary:
    // - Interface Injection = flexibility + external dependency control
    // - Especially useful in extensible systems like plugins or modules.


    // Types of Dependency Injection (DI)
    //
    // Constructor Injection
    // - Dependencies are provided through the class constructor.
    // - This ensures that a class receives all required dependencies
    //   at the time of its creation (instantiation).
    // - It is the most common and recommended approach for mandatory dependencies,
    //   because it enforces dependency availability and promotes immutability.
    //
    // Example:
    //
    // public class MyClass
    // {
    //     private readonly IDependency _dependency;
    //
    //     // Dependency is passed through the constructor
    //     public MyClass(IDependency dependency)
    //     {
    //         _dependency = dependency;
    //     }
    // }
    //
    // Benefits:
    // - Guarantees that the dependency is available when the object is created.
    // - Makes the object easy to test because dependencies can be mocked.
    // - Promotes clean architecture by separating dependency creation from usage.
    //
    // Real-world example:
    // Suppose we have a ReportGenerator that relies on a DatabaseService.
    //
    // public class ReportGenerator
    // {
    //     private readonly IDatabaseService _databaseService;
    //
    //     public ReportGenerator(IDatabaseService databaseService)
    //     {
    //         _databaseService = databaseService;
    //     }
    //
    //     public void GenerateReport()
    //     {
    //         var data = _databaseService.GetData();
    //         Console.WriteLine("Report generated with data: " + data);
    //     }
    // }
    //
    // Usage:
    //
    // IDatabaseService dbService = new SqlDatabaseService();
    // var reportGenerator = new ReportGenerator(dbService);
    // reportGenerator.GenerateReport();
    //
    // - Here, all necessary dependencies (like IDatabaseService)
    //   are injected when creating ReportGenerator.
    // - This follows Dependency Inversion Principle (DIP)
    //   and ensures the class depends on abstractions, not implementations.


    // Types of Dependency Injection (DI)
    //
    // Setter Injection
    // - Dependencies are assigned through public setter methods or properties.
    // - This allows dependencies to be injected after the object has been created.
    // - It is typically used when a dependency is optional or can be changed later.
    //
    // Example:
    //
    // public class MyClass
    // {
    //     // Dependency can be set after object creation
    //     public IDependency Dependency { private get; set; }
    // }
    //
    // Benefits:
    // - The object can be created without immediately providing the dependency.
    // - Useful for optional services or features.
    // - Dependencies can be changed at runtime if needed.
    //
    // Real-world example:
    // Imagine a ReportService that can optionally use a Logger.
    //
    // public class ReportService
    // {
    //     public ILogger Logger { private get; set; }
    //
    //     public void GenerateReport()
    //     {
    //         Logger?.Log("Generating report...");
    //         Console.WriteLine("Report generated");
    //     }
    // }
    //
    // Usage:
    //
    // var reportService = new ReportService();
    // reportService.Logger = new FileLogger(); // dependency injected after creation
    //
    // reportService.GenerateReport();
    //
    // - Here, the Logger is not mandatory for creating the ReportService.
    // - It can be injected later using the setter property.






    internal class Program
    {

        public interface IToolUser
        {
            void SetHammer(Hammer hammer);
            void SetSaw(Saw saw);
        }


        public class Hammer
        {
            public void Use()
            {
                Console.WriteLine("Hammering nails!");
            }


        }

        public class Saw
        {
            public void Use()
            {
                Console.WriteLine("Sawing wood!");

            }
        }


        // Dependency here is that the Builder here depends on the hammer and the saw
        public class Builder: IToolUser
        {

            private Hammer _hammer;
            private Saw _saw;




            public void BuildHouse()
            {
                
                _hammer.Use();
                _saw.Use();

                Console.WriteLine("The house is built! ");
            }

            public void SetHammer(Hammer hammer)
            {
                _hammer = hammer;
            }

            public void SetSaw(Saw saw)
            {
                _saw = saw;
            }
        }





        static void Main(string[] args)
        {

            // this is for constructor DI
            //Hammer hammer = new Hammer();
            //Saw saw = new Saw();
            //Builder builder = new Builder(hammer, saw);


            Hammer hammer = new Hammer();
            Saw saw = new Saw();


            Builder builder = new Builder();

            // Dependency injection using interface
            builder.SetHammer(hammer);
            builder.SetSaw(saw);


            builder.BuildHouse();

            Console.ReadKey();
        }


      

    }
}
