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
            //logHandler("Log this Info");

            // invokig methods in the delagte safely
            foreach (LogHandler  handler in logHandler.GetInvocationList())
            {
                try
                {
                    handler("Event occured with error handling");
                } catch (Exception ex) 
                {
                    Console.WriteLine("Exception caught: {0}", ex.Message);
                }
            }




            // delete a method from our multicast delegate
            //logHandler -= logger.LogToFile;

            // delete a method from our multicast delegate SAFELY
            if (isMethodInDelegate(logHandler, logger.LogToFile))
            {
                logHandler -= logger.LogToFile;
                Console.WriteLine("LogToFile method removed");
            } else
            {
                Console.WriteLine("LogToFile method not found");
            }

                // safe invoke
                InvokeSafely(logHandler, "After revoking log to file");

            // logHandler("After revoking log to file")


            Console.ReadKey();
        }


     
        static void InvokeSafely(LogHandler logHandler, string message)
        {
            LogHandler tempLogHandler = logHandler;
            if(tempLogHandler != null)
            {
                tempLogHandler(message);
            }
        }

        static bool isMethodInDelegate(LogHandler logHandler, LogHandler method)
        {
            if (logHandler == null) 
            {
              return false;
            }

            foreach (var d in logHandler.GetInvocationList())
            {
                // We cast it to make sure it is really celan and ok
                if(d == (Delegate)method)
                {
                    return true;
                }
            }

            return false;
          
        }

    }
}
