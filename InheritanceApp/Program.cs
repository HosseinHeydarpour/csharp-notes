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

            carl.BecomeOlder(5);

            carl.DisplayPersonInfo();


            Console.ReadKey();
        }
    }

    

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

        // XML comments
        /// <summary>
        /// Makes our object(Person) older 
        /// </summary>
        /// <param name="years">The parameter which indicates the amount of years the object should age</param>
        /// <returns>Returns the new age after aging / becoming older</returns>
        public int BecomeOlder(int years)
        {
            Age = years + Age;
            return Age;
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
