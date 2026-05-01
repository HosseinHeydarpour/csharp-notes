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


        

        public class Animal
        {
            // With virtual keyword we are allowed to override this method 
            public virtual void MakeSound()
            {
                Console.WriteLine("Some generic animal sound... ");
            }
        }

        public class Dog : Animal
        {
            public override void MakeSound() 
            {
                Console.WriteLine("WOOOOF! WOOOOF!");
            } 
        }


        public class Cat : Animal 
        {
            public override void MakeSound()
            {
                Console.WriteLine("Meow Meow");
            }

        }




        static void Main(string[] args)
        {
            // Part two of the ploymorphism
            // This is possible to store a Dog object in Animal object because Dog is inheritinng from Animal
            Animal myDog = new Dog();
            myDog.MakeSound();
             
            // But this is not possible
            //Dog my2ndDog = new Animal();




          
            Console.ReadKey();
        }


      

    }
}
