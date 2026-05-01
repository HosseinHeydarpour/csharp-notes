using System.Xml.Serialization;

namespace InterfaceApp
{
    /*
        Interfaces: Where, Why, and When to Use
        
        1) Where to use interfaces
        - In systems with interchangeable components or varying implementations
        - To decouple clients from concrete classes and rely on abstractions
        - When you need a common contract across disparate types or modules
        
        2) Why use interfaces
        - Promote loose coupling and easier substitution of implementations
        - Improve testability by enabling mocks/stubs and isolated testing
        - Support adherence to SOLID principles, especially Dependency Inversion
        
        3) When to use interfaces
        - In extensible architectures that support plugins or extensions
        - When you want to swap implementations without changing clients
        - When a stable, shared API is needed across multiple classes or services
        - When enforcing a consistent contract across a family of related types

        4) Facilitating Unit Testing with Mock Implementations

        Where:
        - When writing unit tests for classes that depend on external services or components.
        - When isolating a class from infrastructure concerns such as databases, APIs, or file systems.
        
        Why:
        - To test classes in isolation without relying on real implementations.
        - To simulate specific behaviors (success, failure, edge cases) in a controlled way.
        - To improve reliability and speed of automated tests.
        
        When:
        - When a class has external dependencies that should not be invoked during testing.
        - When predictable and repeatable behavior is required in test scenarios.
        
        
        5) Achieving Multiple Inheritance (via Interfaces)
        
        Where:
        - When a class needs to implement multiple distinct behaviors.
        - When combining different roles or capabilities in a single class.
        
        Why:
        - To allow a class to conform to multiple contracts.
        - To separate capabilities into clear, focused abstractions.
        - To avoid tight coupling that would result from deep inheritance hierarchies.
        
        When:
        - When a class must expose multiple independent responsibilities.
        - When different parts of the system rely on different aspects of the same class through separate contracts.
        
      */



    internal class Program
    {
        public interface IPrintable
        {
            void Print();
        }
       
        public interface IScannable
        {
            void Scan();
        }


        // This is multiple inheritance to a degree
        public class MultiFunctionPrinter : IPrintable, IScannable
        {
            public void Print()
            {
                Console.WriteLine("Printing Document");
            }

            public void Scan()
            {
                Console.WriteLine("Scanning Document");
            }
        }


        static void Main(string[] args)
        {
            MultiFunctionPrinter printer = new MultiFunctionPrinter();
            printer.Print();
            printer.Scan();
            

            Console.ReadKey();
        }


      

    }
}
