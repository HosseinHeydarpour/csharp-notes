namespace EventsAndDelegatesApp
{


    // Multicast Delegates

    // What are Multicast Delegates in C#?
    // A multicast delegate in C# is a delegate
    // that holds references to and can invoke
    // multiple methods.

    // Why use Multicast Delegates in C#?
    // You would use a multicast delegate to allow 
    // multiple methods to be called in sequence 
    // through a single delegate invocation.

    // When use Multicast Delegates in C#?

    // You would use a multicast delegate when
    // you need to notify multiple event handlers
    // or execute multiple related methods
    // in response to a single event or operation.


    public delegate void LogHandler(string message);

    public class Logger
    {
        public void LogToConsole(string message) 
        {
            Console.WriteLine("Console Log: "+message);
        }

        public void LogToFile(string message) 
        {
          Console.WriteLine("File Log: "+ message);
        }

    }


    

    internal class Program
    {



        static void Main(string[] args)
        {

            Logger logger = new Logger();

            // Creating a multi cast delegate
            LogHandler logHandler = logger.LogToConsole;
            // This += makes our logHanfler a multicast handler
            logHandler += logger.LogToFile;


            // This will invoke both methods console method and file method
            // invoking multicast
            logHandler("Log this Info");

            // delete a method from our multicast delegate
            logHandler -= logger.LogToFile;

            logHandler("One method active");


            Console.ReadKey();
        }


     


    }
}
