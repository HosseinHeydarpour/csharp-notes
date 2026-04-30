using System.Reflection.Emit;

namespace InheritanceApp
{
    internal class Program
    {
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

    /*
        INHERITANCE IN C#

        Class Animal { }
            ↓  (is inherited by)
            Class Dog : Animal { }

        Explanation:
            The class Dog inherits from the class Animal using the ":" symbol.
            This means Dog automatically gains access to all public and protected
            methods and properties of Animal.

        By inheriting Animal, Dog can:
            - Use existing Animal methods
            - Add its own methods and properties
            - Override Animal methods (if they are virtual)
    */

    // Derived Class(Child Class or Subclass):
    // the class that inherits the members of the base class.
    class Dog : Animal
    {

        public void Bark()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WOOF! WOOF!");
            Console.ResetColor();
        }

    }

    




}
