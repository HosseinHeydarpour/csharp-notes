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

            // Excecutes one row after another
            /*
            Console.WriteLine("Hello World 1");
            Thread.Sleep(1000); // Pause our whoel program for 1 second
            Console.WriteLine("Hello World 2");
            Thread.Sleep(1000); // Pause our whoel program for 1 second
            Console.WriteLine("Hello World 3");
            Thread.Sleep(1000); // Pause our whoel program for 1 second
            Console.WriteLine("Hello World 4");
         

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1");
            }).Start();
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 2");
            }).Start();
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 3");
            }).Start();
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            }).Start();

            */

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            })
            {IsBackground=true }.Start();


            // This will create 1000 threads
            // Order will be different 
            Enumerable.Range(0,1000).ToList().ForEach(f => 
            {
                // Thread pool takes a lot of time but is more smooth
                // DO NOT RANDOMLY USE THREADS
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(5000);

                    Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} ended");
                });
                //new Thread(() =>
                //{
                //    Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} started");
                //Thread.Sleep(5000);

                //Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} ended");
                //}).Start();
            });


            
    
            

           

            Console.ReadLine();
        }
    }
}
