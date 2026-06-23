using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace Csharp_Clean_Code
{

    // Interface segregation prnciple


    internal class Program
    {

        

        static void Main(string[] args)
        {
            IWorkable human = new Worker();

            human.Work();
            ((IEatable)human).Eat(); // We need to cast because we are using Iwrokable to create human instance
            

            IWorkable robot = new Robot();
            robot.Work();

        }



    }


    
    public interface IWorkable
    {
        void Work();
       
    }


    public interface IEatable
    {
        void Eat();
    }

    public class Worker : IWorkable, IEatable
    {
        public void Work()
        {
            Console.WriteLine("Working...");
        }

        public void Eat()
        {
            Console.WriteLine("Eating...");
        }


    }

    public class Robot : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Working...");
        }

        public void Eat()
        {
            // Robots do not eat, but are forced to implement this method
            throw new NotImplementedException();
        }
    }


}
