using System.Reflection.Emit;

namespace InheritanceApp
{
    internal class Program
    {
        /*
            TYPES OF INHERITANCE IN C# (WITH EXAMPLES)

            Note:
                C# supports several forms of inheritance, but *does NOT* allow
                multiple inheritance of classes directly. However, multiple
                inheritance is possible through interfaces.

        ========================
         1. SINGLE INHERITANCE
        ========================
                Single inheritance means a class inherits from ONE base class.
                The derived class gets access to the public and protected members
                (methods, properties, etc.) of the base class.

        ========================
        2. MULTILEVEL INHERITANCE
        ========================
                Multilevel inheritance happens when a class is derived from another
                derived class, forming a chain of inheritance.
        
                Example chain:
                BaseClass → DerivedClass → FurtherDerivedClass

                The last class inherits features from BOTH previous classes.

            ========================
            3. HIERARCHICAL INHERITANCE
            ========================
            Hierarchical inheritance means MULTIPLE classes inherit
            from the SAME base class.
            
            Example:
            BaseClass
               |---- DerivedClassA
               |---- DerivedClassB
            
            Both derived classes share the same base functionality.



        ========================
        4. MULTIPLE INHERITANCE
        ========================
        Multiple inheritance means a class inherits from MORE THAN ONE
        base class.
        
        C# DOES NOT allow multiple inheritance with classes because it can
        create ambiguity problems (for example if both base classes have
        the same method).
        
        Example below would cause a compile error in C#.


        ========================
        MULTIPLE INHERITANCE USING INTERFACES
        ========================
        Although C# does not support multiple inheritance with classes,
        it allows a class to implement multiple interfaces.
        
        Interfaces only contain method declarations, so there is no conflict.
*/

// class DerivedClass : BaseClass1, BaseClass2 { }  // Not allowed
            
      

        static void Main(string[] args)
        {

            Dog myDog = new Dog();

            // This Eat method comes from the Animal class
            myDog.Eat();
            // This method comes from the Dog class 
            myDog.Bark();


            Console.ReadKey();
        }
    }


    // Base Class (Parent Class - Super Class)
    class Animal
    {
        public void Eat()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Eating...");
            Console.ResetColor();
        }
    }


    class Dog : Animal
    {

        public void Bark()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WOOF! WOOF!");
            Console.ResetColor();
        }

    }

    // This is HIERARCHICAL INHERITANCE | one base class and multiple deriving classes
    class Cat : Animal { 
    
        public void Meow()
        {
            Console.WriteLine("Cat is MEOWING");
        }
    
    }








    // a breed of Dog | this is a multi level inheritance
    class Collie : Dog
    {
        public void GoingNuts()
        {
            Console.WriteLine("I AM GOING nUTS");
        }
    }



}
