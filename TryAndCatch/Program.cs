using System.Diagnostics;

namespace TryAndCatch
{
    /*
      TRY / CATCH

      Purpose:
      Try/Catch blocks are used to handle exceptions and runtime errors in a controlled way
      so the program does not crash unexpectedly.

      try
       - Contains the code where an exception might occur.

      catch
       - Handles the exception if it happens.
       - You can catch a specific exception type or a general one.

      finally (optional)
       - A block that always executes whether an exception occurs or not.
       - Commonly used for cleanup operations like closing files or database connections.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
         



            /*
                THE "throw" KEYWORD (C#)

                Purpose:
                The throw keyword is used to signal that an exception has occurred.
                It allows a method to report an error so it can be handled by a
                try/catch block.

                How It Works:
                When an exception is thrown, the normal flow of the program stops,
                and control is transferred to the nearest enclosing try/catch block
                that can handle that exception.
            */
            Console.WriteLine("Please enter your age: ");
            GetUserAge(Console.ReadLine());


            
            Console.ReadKey();

        }

        // What Does throw Do?
        // The throw keyword in C# is used to indicate that a problem
        // has occurred in your program
        // When you use throw, you're essentially saying,
        // "Hey, something went wrong here, and I can't handle it by myself." 
        // You're creating an error on purpose, which is called an exception.

        // Why use throw?
        /*
         * 1. To Stop Bad Things from Happening: If something in your program 
         * isn't right, like if a necessary file is missing or a number
         * that should never be zero is zero, using throw stops the program
         * before any more damage can happen.
         * 
         * 2. To Tell Other Parts of Your Program about the Problem: 
         * Sometimes, one part of your program might not know 
         * how to fix a problem, but another part does. By using throw,
         * the first part can let the second part handle the issue.
         * 
         */

        static int GetUserAge(string input)
        {
            int age;
            if (!int.TryParse(input, out age)) 
            {
                throw new Exception("The age is not in valid format");
            }
            if(age < 0 || age > 120)
            {
                throw new Exception("The age must be between 0 and 120");
            }
            return age;
        }

    }
}
