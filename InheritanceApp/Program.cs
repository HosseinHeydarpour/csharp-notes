using System.Reflection.Emit;

namespace InheritanceApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Employee joe = new Employee("Joe", 23, "Sales Rep", 23456);
            // joe.DisplayEmployeeInfo();

            Manager carl = new Manager("Carl",45,"Manager",231564,50);
            carl.DisplayManagerInfo();

            // This tostring method comes from Object not the carl object which is a Manager instance
            // every single class in C# iherits from Object class
            Console.WriteLine(carl.ToString());


            Console.ReadKey();
        }
    }

    // --------------------------------------------
    // Things to Remember - Constructor Chaining
    // --------------------------------------------
    //
    // Constructor chaining ensures proper setup
    // when working with inheritance.
    //
    // When creating an object from a derived class,
    // its constructor should call the base class
    // constructor.
    //
    // This guarantees that the base class is
    // properly initialized before the derived
    // class performs its own initialization.
    //
    // --------------------------------------------

    // --------------------------------------------
    // Things to Remember - Order of Execution
    // --------------------------------------------
    //
    // Order of Execution: Base Class First
    //
    // The base class constructor runs before the
    // derived class constructor.
    //
    // This guarantees that all necessary
    // initializations in the base class are
    // completed before any setup in the derived
    // class begins.
    //
    // --------------------------------------------


    // --------------------------------------------
    // Custom Initialization - Adding Unique Setup
    // --------------------------------------------
    //
    // Derived classes can include their own
    // initialization code in addition to what
    // the base class provides.
    //
    // This allows derived classes to extend
    // functionality while still reusing the
    // common setup code from the base class.
    //
    // --------------------------------------------

    // --------------------------------------------
    // Flexibility and Reuse - Promotes Clean Code
    // --------------------------------------------
    //
    // Using constructor inheritance increases
    // flexibility and code reuse.
    //
    // It helps build complex class hierarchies
    // while keeping the code clean and
    // maintainable.
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
            Console.WriteLine($"Job Title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
    }



    public class Manager : Employee
    {

        public int TeamSize { get; private set; }

        public Manager(string name, int age, string jobTitle, int employeeID, int teamSize) : base(name, age, jobTitle, employeeID)
        {
            TeamSize = teamSize;
        }

        public void DisplayManagerInfo()
        {
          
            DisplayEmployeeInfo();   // call this method from the base class
            Console.WriteLine($"Team Size: {TeamSize}");
        }
    }

}
