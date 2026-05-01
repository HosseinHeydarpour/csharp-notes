namespace InterfaceApp
{
    internal class Program
    {
        // What is an Interface?
        //
        // An interface in C# is like a blueprint that defines methods and 
        // properties a class must have, but it doesn't provide the actual 
        // code for them. 
        //
        // It's used to ensure different classes follow the same rules.

        // Why use an Interface?
        //
        // 1. Abstraction:
        //
        // Defines what methods a class should implement without specifying how.
        //
        // Interfaces tell classes what they need to do, but not how to do it.


        // Why use an Interface?
        //
        // 2. Polymorphism:
        //
        // Allows different classes to be treated as instances of the interface type.
        //
        // Interfaces let different classes be used in the same way.

        // Why use an Interface?
        //
        // 3. Decoupling:
        //
        // Reduces dependencies between classes, making the code more modular 
        // and easier to maintain.
        //
        // Interfaces help keep classes separate so the code is easier to 
        // manage and update.

        // Why use an Interface?
        //
        // 4. Reusability:
        //
        // Ensures that different classes can use common methods, 
        // enhancing code reusability.
        //
        // Interfaces make it easy to reuse code across different classes.

        // Why use an Interface?
        //
        // 5. Testability:
        //
        // Facilitates unit testing by allowing mock implementations of interfaces.
        //
        // Interfaces make testing easier by allowing fake versions of classes 
        // for testing purposes.

        // I in the IAnimal indicates that this is an interface
        public interface IAnimal
        {
            void MakeSound();
            void Eat(string food);

        }

        public class Dog : IAnimal
        {
            public void Eat(string food)
            {
                Console.WriteLine("Dog ate "+food);
            }

            public void MakeSound()
            {
                Console.WriteLine("Bark");
            }
        }


        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Eat("Treat");


            Console.ReadKey();
        }


      

    }
}
