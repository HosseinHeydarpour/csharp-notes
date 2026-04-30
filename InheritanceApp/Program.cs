using System.Reflection.Emit;

namespace InheritanceApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 23, "Sales Rep", 23456);
            joe.DisplayEmployeeInfo();



            Console.ReadKey();
        }
    }

    // --------------------------------------------
    // Constructors
    // --------------------------------------------
    //
    // Constructors are special methods in a class 
    // that are called when an instance of the class 
    // is created.
    //
    // In the context of inheritance,
    // constructors of the base class are called 
    // before the constructors of the derived class.
    //
    // This ensures that the base class is properly 
    // initialized before any additional initialization 
    // in the derived class takes place.
    //

    // --------------------------------------------
    // Constructors - Proper Initialization
    // --------------------------------------------
    //
    // Proper initialization ensures that all fields
    // and properties of the base class are correctly
    // set up before any operations of the derived
    // class can take place.
    //
    // This means that when creating an object of a
    // derived class, the constructor of the base
    // class runs first to initialize its members.
    //
    // --------------------------------------------

    // --------------------------------------------
    // Constructors - Consistent State
    // --------------------------------------------
    //
    // Constructors help maintain a consistent and
    // valid state across the object hierarchy.
    //
    // This ensures that both the base class and
    // the derived class remain in a valid state
    // throughout the object's lifetime.
    //
    // By running the base class constructor first,
    // any dependencies or required initial states
    // are properly established.
    //
    // --------------------------------------------

    // --------------------------------------------
    // Constructors - Reuse of Initialization Code
    // --------------------------------------------
    //
    // Constructors help avoid duplication of
    // initialization code by reusing the base
    // class constructor.
    //
    // Common setup tasks needed by both the
    // base class and the derived class are
    // handled once in the base class constructor.
    //
    // The derived class does not need to repeat
    // this setup, which keeps the code cleaner
    // and reduces the chance of errors.
    //
    // --------------------------------------------

    // Base Class
    public class Person
    {
        // Properties
        public string Name { get; private set; }
        public int Age { get; private set; }

        // Base class constructor
        public Person(string name, int age) 
        {
            Name = name;
            Age = age;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Person constructor called... ");
            Console.ResetColor();
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");

        }
    }


    public class Employee: Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }


        public Employee(string name, int age, string jobTitle, int employeeID) : base(name, age) // calling the base class constructor
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee(Derived class) Constructor called!");
            Console.ResetColor();
            JobTitle = jobTitle;
            EmployeeID = employeeID;
        }


        public void DisplayEmployeeInfo()
        {
            DisplayPersonInfo(); // call this method from the base class
            Console.WriteLine($"Jon Title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
    }
   
}
