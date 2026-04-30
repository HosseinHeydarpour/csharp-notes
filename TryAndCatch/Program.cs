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

            Console.WriteLine("App running before the try block!");

            try
            {
                LevelOne();
            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Execption caught in Main: "+ex.Message);
                Console.ResetColor();
            }

            Console.WriteLine("App is still running!");
            Console.ReadKey();

        }


        static void LevelOne()
        {
            LevelTwo();
        }


        static void LevelTwo()
        {
            Console.WriteLine("Level 2 before the throw!");
            throw new Exception("Oops! something went wrong!");
            Console.WriteLine("Level 2 after the throw!"); // this will not get exceuted because it is after throw line
        }


    }
}
