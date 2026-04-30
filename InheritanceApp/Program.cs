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


            Dog myDog = new Dog();
            myDog.MakeSound();


            Cat myCat = new Cat();
            myCat.MakeSound();
           


            Console.ReadKey();
        }
    }


    class Animal 
    {
       public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public virtual void MakeSound()
        {
       
            Console.WriteLine("Animal is making sound... ");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            // access what this method in base class do PLUS
            // what we want to add to this method

            base.MakeSound();
            Console.WriteLine("Barking...");
        }

     
    }


    class Cat: Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meowing... ");
        }
    }
}
