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
            
            int result = 0;

            Debug.WriteLine("Main method is running!");


            try
            {
                Console.WriteLine("Please enter two numbers to divide: ");
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                result = num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Do not divide by zero!\n"+ex.Message);
                Console.ResetColor();
            }
            catch(FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Entery must be a number!\n" + ex.Message);
                Console.ResetColor();
            }
            //catch(OverflowException ex)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"Number is too big!\n" + ex.Message);
            //    Console.ResetColor();
            //}

            // If we comment the default catch block if an exception happens and we do not catch it the app will crash
            // This is the parent exception to all other exceptions
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.ToString()}");
                Console.ResetColor();

            }
            finally
            {
                Console.WriteLine("This always executes!");
            }



            Console.WriteLine(result);
            Console.ReadKey();

        }


    }
}
