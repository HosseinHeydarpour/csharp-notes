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


            /*
Why try/catch is preferred over if/else for error handling

Example using if/else:

if (File.Exists("example.txt"))
{
    string content = File.ReadAllText("example.txt");
    Console.WriteLine(content);
}
else
{
    Console.WriteLine("File not found.");
}

Problem:
Even if File.Exists("example.txt") returns true, the file could be
deleted, moved, or become inaccessible right after the check but
before File.ReadAllText() runs.

This creates a race condition and may still throw an exception
that the if/else block does NOT handle.

Because of this, checking conditions with if/else does not guarantee
safety when working with external resources like files, networks,
or databases.


Correct approach: try/catch

try
{
    string content = File.ReadAllText("example.txt");
    Console.WriteLine(content);
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found.");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("No permission to access the file.");
}
catch (IOException ex)
{
    Console.WriteLine("File error: " + ex.Message);
}

Explanation:
- try: attempt the operation that might fail
- catch: handle the error if it occurs
- this safely handles unexpected runtime problems
*/



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
            /*
                The finally keyword is used in a try/catch block to ensure that
                certain code runs no matter what, whether an error happens or not.
                Think of it as a cleanup crew that always comes in to tidy up,
                like closing files or releasing resources, so your program stays
                neat and doesn't leave any loose ends.
            */
            finally
            {
                // Code to cleanup or finalize
                // ideal for cleaning up resources
                // like closing file streams or database connections.

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This always executes!");
                Console.ResetColor();

            }




            Console.WriteLine("Result is: " + result);
            Console.ReadKey();

        }
    }
}
