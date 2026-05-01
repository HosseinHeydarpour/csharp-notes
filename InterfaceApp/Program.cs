namespace InterfaceApp
{
    internal class Program
    {
        // What is Polymorphism?
        //
        // Polymorphism, derived from Greek meaning "many shapes," refers to 
        // the ability in programming where a single interface or method can 
        // operate in multiple ways based on the object it interacts with.

        // What is Polymorphism?
        //
        // • One "play" button can operate a TV, DVD player, or stereo differently.
        //
        // • The same method works uniquely depending on the object it controls.

        // What is Polymorphism?
        //
        // One Interface, Many Implementations:
        //
        // A single function or method can handle objects of various types.
        // The implementation depends on the specific object being referenced.


        // What is Polymorphism?
        //
        // Different animals make different sounds.
        //
        // The MakeSound method will produce the appropriate sound 
        // for any given animal.

        // Why Polymorphism?
        //
        // Flexibility:
        //
        // • Write adaptable and reusable code.
        //
        // • Methods can work with different object types 
        //   without knowing the specific types in advance.


        // Why Polymorphism?
        //
        // Code Maintenance:
        //
        // • Simplifies maintenance and extension.
        //
        // • New object types can be added easily 
        //   if they conform to the expected interface or base class.

        // Why Polymorphism?
        //
        // Simplifies Code:
        //
        // • Enables treating different objects uniformly.
        //
        // • Reduces complexity by handling diverse objects 
        //   through a common interface.


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

        public class Cat : IAnimal
        {
            public void Eat(string food)
            {
                Console.WriteLine("Cat ate " + food);
            }

            public void MakeSound()
            {
                Console.WriteLine("Meow...");
            }
        }


        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("Treat");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("Fish");

            Console.ReadKey();
        }


      

    }
}
