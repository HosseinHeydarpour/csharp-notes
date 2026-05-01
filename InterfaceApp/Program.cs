using System.Xml.Serialization;

namespace InterfaceApp
{
    // Dependency Injection (DI)
    //
    // What is Dependency Injection?
    // - Dependency Injection is a programming technique that makes a class
    //   independent of how its dependencies are created.
    // - Instead of a class creating its own dependencies (new SomeService()),
    //   those dependencies are provided (injected) from the outside
    //   via constructors, properties, or methods.
    //
    // Why is this important?
    // - It helps you follow SOLID principles, especially:
    //     * Dependency Inversion: depend on abstractions (interfaces), not
    //       concrete implementations.
    //     * Single Responsibility: object creation is handled elsewhere
    //       (e.g., a DI container), so classes focus only on their main job.
    //
    // Real-world example:
    // - Imagine an OrderProcessor class that sends confirmation emails
    //   when an order is placed.
    //   Bad (no DI, tightly coupled):
    //    

    // Types of Dependency Injection (DI)
    //
    // Constructor Injection
    // - Dependencies are provided through a class constructor.
    // - This ensures that the class receives all required dependencies
    //   at the moment the object is created (instantiation).
    // - It is the most commonly used form of DI because it guarantees
    //   that the object cannot exist without its required dependencies.
    //
    // Example:
    //
    // public class MyClass
    // {
    //     private readonly IDependency _dependency;
    //
    //     // Dependency is injected through the constructor
    //     public MyClass(IDependency dependency)
    //     {
    //         _dependency = dependency;
    //     }
    // }
    //
    // Real-world example:
    // - Imagine a ReportGenerator class that needs a database service
    //   to fetch data.
    // - Instead of creating the database service inside the class,
    //   it receives it through the constructor.
    //
    // public class ReportGenerator
    // {
    //     private readonly IDatabaseService _database;
    //
    //     public ReportGenerator(IDatabaseService database)
    //     {
    //         _database = database;
    //     }
    //
    //     public void Generate()
    //     {
    //         var data = _database.GetReportData();
    //         // generate report using the data
    //     }
    // }
    //
    // - Now you can inject different implementations like:
    //     SqlDatabaseService
    //     MongoDatabaseService
    //     FakeDatabaseService (for unit testing)


    // Types of Dependency Injection (DI)
    //
    // Setter Injection
    // - Dependencies are assigned through public setter methods or properties.
    // - This allows dependencies to be injected after the object has been created.
    // - It is typically used for optional dependencies that are not required
    //   during object construction.
    //
    // Example:
    //
    // public class MyClass
    // {
    //     // Dependency can be set after object creation
    //     public IDependency Dependency { private get; set; }
    // }
    //
    // Real-world example:
    // - Imagine a ReportService that can optionally log its operations.
    // - Logging is helpful but not required for the service to function.
    //
    // public class ReportService
    // {
    //     public ILogger Logger { private get; set; }
    //
    //     public void GenerateReport()
    //     {
    //         Logger?.Log("Generating report...");
    //         // report generation logic
    //     }
    // }
    //
    // Usage:
    //
    // var reportService = new ReportService();
    // reportService.Logger = new FileLogger(); // injected after creation
    //
    // - This approach is useful when the dependency is optional,
    //   but it is less strict than constructor injection because
    //   the object can exist without the dependency being set.

    // Types of Dependency Injection (DI)
    //
    // Interface Injection
    // - Dependencies are provided through an interface.
    // - The class must implement an interface that defines a method
    //   specifically for injecting the dependency.
    //
    // Example:
    //
    // public interface IDependencyInjector
    // {
    //     void SetDependency(IDependency dependency);
    // }
    //
    // public class MyClass : IDependencyInjector
    // {
    //     private IDependency _dependency;
    //
    //     // Dependency is injected through the interface method
    //     public void SetDependency(IDependency dependency)
    //     {
    //         _dependency = dependency;
    //     }
    // }
    //
    // Real-world example:
    // - Imagine a Plugin system where different plugins need access
    //   to a Logger service.
    //
    // public interface ILoggerInjector
    // {
    //     void SetLogger(ILogger logger);
    // }
    //
    // public class AnalyticsPlugin : ILoggerInjector
    // {
    //     private ILogger _logger;
    //
    //     public void SetLogger(ILogger logger)
    //     {
    //         _logger = logger;
    //     }
    //
    //     public void Run()
    //     {
    //         _logger.Log("Analytics plugin running");
    //     }
    // }
    //
    // - When the application loads plugins, it injects the logger
    //   through the interface method.
    // - This ensures that every plugin that requires logging
    //   implements the injection method defined by the interface.




  

    internal class Program
    {


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
        public class Builder
        {

            // Setter dependency injection
            public Hammer Hammer { get; set; }
            public Saw Saw { get; set; }


            private Hammer _hammer;
            private Saw _saw;

            // Construnctor Dependency Injection (DI)
            //public Builder(Hammer hammmer, Saw saw)
            //public Builder()
            //{

                //_hammer = new Hammer(); // Builder is responsible for creating its dependencies
                //_saw = new Saw();


                //_hammer = hammmer; // Now we inject and give the builder its dependencies and the builder is no longer responsible for it
                //_s aw = saw;
            //}

            public void BuildHouse()
            {
                 // This is for Constructor DI
                //_hammer.Use();
                //_saw.Use();

                // Setter DI
                Hammer.Use();
                Saw.Use();

                Console.WriteLine("The house is built! ");
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

            builder.Hammer = hammer; // Inject dependencies via setters
            builder.Saw = saw;  // Inject dependencies via setters

            builder.BuildHouse();


            Console.ReadKey();
        }


      

    }
}
