using System.Reflection.Emit;

namespace InheritanceApp
{
    internal class Program
    {

        /*
        ===========================
        1. PUBLIC
        ===========================
        public int publicField;
        
        - Accessible from ANYWHERE in the program.
        - Other classes, other files, even other projects (if referenced).
        - Most permissive access level.
        */



        /*
        ===========================
        2. PROTECTED
        ===========================
        protected int protectedField;

        - Accessible ONLY inside:
            • The class where it is declared
            • Any class that INHERITS from it (subclasses)
        - Not accessible from outside unless through inheritance.
        */



        /*
        ===========================
        3. PRIVATE
        ===========================
        private int privateField;

        - Accessible ONLY inside the SAME class.
        - Not accessible from subclasses.
        - Most restrictive access level.
        */



        /*
        ================================
        4. INTERNAL
        ===========================
        internal int internalField;

        - Accessible anywhere WITHIN THE SAME PROJECT (same assembly).
        - NOT accessible from other projects unless 'InternalsVisibleTo' is used.
        */



        /*
        ========================================
        5. PROTECTED INTERNAL
        ========================================
        protected internal int value;

        - Accessible in:
            • The same project (like internal)
            • Any derived class, even if the subclass is in another project
        - Combination of protected + internal rules.
        */



        /*
        ========================================
        6. PRIVATE PROTECTED
        ========================================
        private protected int value;

        - Accessible ONLY in:
            • The class itself
            • Derived classes that are in the SAME PROJECT

        - More restrictive version of protected internal.
        */

        // class DerivedClass : BaseClass1, BaseClass2 { }  // Not allowed



        static void Main(string[] args)
        {
            Employee joe = new Employee("Joe", 23);
            joe.DisplayPersonInfo();



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
    }


    public class Employee: Person
    {
        public Employee(string name, int age) : base(name,age)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee(Derived class) Constructor called!");
            Console.ResetColor();
        }
    }
   
}
