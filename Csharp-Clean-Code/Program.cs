using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Csharp_Clean_Code
{
    internal class Program
    {

        // Liskov substitution principle


        static void Main(string[] args)
        {
            Bird sparrow = new Sparrow();
            sparrow.MakeSound();
            ((IFlyable)sparrow).Fly();

            Bird penguin = new Penguin();
            // penguin.Fly(); // This will throw and exception
            penguin.MakeSound();
            
        }


        public class Bird 
        {
            public virtual void MakeSound() 
            {
                Console.WriteLine("Chirp Chirp!");
            }
        }


        public class Sparrow: Bird, IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Flying...");
            }
        }


        public class Penguin : Bird
        {
            public override void MakeSound()
            {
                base.MakeSound();
            }
        }


        public interface IFlyable
        {
            void Fly();
        }

    }


    
}
