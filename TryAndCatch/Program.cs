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
        

            try
            {
                Console.WriteLine("Please enter a number: ");

                //int num1 = 0;


                int num1 = int.Parse(Console.ReadLine());

                int num2 = 2;
          

                result = num2 / num1;

               

            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(ex.ToString());
                Console.WriteLine("Error: "+ex.Message);
                Console.ResetColor();
                
            }



            Console.WriteLine("Result is: "+result);
           
            Console.ReadKey();

        }
    }
}
