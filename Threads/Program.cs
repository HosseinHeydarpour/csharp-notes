using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The main thread started! ");

            Thread thread1 = new Thread(ThreadFunction);
            Thread thread2 = new Thread(Thread2Function);

            thread1.Start();
            thread2.Start();

            // joins thread 1 and the main thread
            //thread1.Join();
            //Console.WriteLine("Thread 1 func is done");
            //thread2.Join();
            //Console.WriteLine("Thread 2 func is done");

            // Only blocks the main thread for 1 second
            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread1 func is done");
            }
            else
            {
                Console.WriteLine("Thread1 func was not done within 1 sec");
            }
            thread2.Join();

            Console.WriteLine("Thread 2 func is done");

            for (int i = 0; i < 10; i++)
            {
                // Is the thread done or not done
                if (thread1.IsAlive)
                {
                    Console.WriteLine("Thread1 is still doing stuff");
                    Thread.Sleep(300);
                }
                else
                {
                    Console.WriteLine("Thread 1 is completed.");
                }

            }




            Console.WriteLine("The main thread ended! ");
           
        }

        public static void ThreadFunction()
        {
            Console.WriteLine("Thread1Function started.");
            Thread.Sleep(3000);
            Console.WriteLine("Thread 1 func coming back to caller");
        }


        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started.");
        }
    }
}
