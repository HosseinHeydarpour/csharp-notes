using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace StructsApp
{
    internal class Program
    {


        static void Main(string[] args)
        {

            // C# Garbage Collection

            // The .NET Framework provides automatic memory management.
            // For example, this line allocates memory for a new object:
            // Human denis = new Human(); // allocates Memory

            // The Framework takes care of reclaiming memory for reuse in the system, 
            // once objects are no longer being used.

            // VISUAL REPRESENTATION OF MEMORY MANAGEMENT:
            // 1. System Memory Pool: This is where objects (the black boxes) physically reside.
            // 2. Program: This is your code, which holds "References" to those objects.
            // 3. References: Arrows pointing from your program to the memory pool. 

            // The Framework takes care of reclaiming memory for reuse in the system, 
            // once objects are no longer being used (i.e., when the program no longer 
            // holds a reference to that object in the memory pool).

            // 3. RECLAMATION (The Garbage Collector):
            // When your program no longer holds a reference to an object (as shown by 
            // the missing arrow for the top object in the slide):
            // - The object is no longer being used.
            // - The "Garbage Collector" identifies these unreferenced objects.
            // - It automatically reclaims that memory so it can be reused by the system.

            // --- Key Facts about C# Garbage Collection ---

            // - AUTOMATION: You don't HAVE to manually call the garbage collector, though it is possible (e.g., GC.Collect()).
            // - PERFORMANCE: The GC requires processing power. 
            // - BALANCE: The GC's primary goal is to free up memory while trying not to consume too much processing power.
            // - TIMING: Memory isn't necessarily reclaimed the exact moment a reference is lost; it happens when the GC runs.
            // - FINALIZERS: You can implement a 'finalizer' method (~Human()) to execute specific code 
            //   just before an object is officially released from memory by the GC.

            // --- When does the Garbage Collector run? ---

            // The GC triggers automatically under the following conditions:
            // 1. LOW MEMORY: When the system has low physical memory.
            // 2. THRESHOLD: When the memory allocated to objects exceeds a pre-set threshold.
            // 3. MANUAL CALL: When GC.Collect() is called (though this is considered a 
            //    "tricky" method and is generally discouraged in standard practice).



            Console.ReadLine();
        }

       

    }
}
