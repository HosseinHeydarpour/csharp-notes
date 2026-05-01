using System.Xml.Serialization;

namespace InterfaceApp
{

    public class Hammer
    {
        public void Use()
        {
            Console.WriteLine("Hammering nails!");
        }

      
    }

    public class Saw
    {
        public void Use() 
        {
            Console.WriteLine("Sawing wood!");
        
        }
    }


    // Dependency here is that the Builder here depends on the hammer and the saw
    public class Builder
    {
        private Hammer _hammer;
        private Saw _saw;

        public Builder() {

            _hammer = new Hammer(); // Builder is responsible for creating its dependencies
            _saw = new Saw();
        }

        public void BuildHouse()
        {
            _hammer.Use();
            _saw.Use();
            Console.WriteLine("The house is built! ");
        }
    }



    internal class Program
    {

        
        public interface ILogger
        {
            void Log(string message);
        }


        public class FileLogger : ILogger
        {
            public void Log(string message)
            {
                // In C# strings, the backslash '\' is an escape character used to represent special characters 
                // like '\n' (newline) or '\t' (tab). Because of this, a single '\' cannot be written directly 
                // inside a normal string literal. To represent an actual backslash character, it must be escaped 
                // by writing it twice: '\\'. Therefore "C:\\Logs" represents the path C:\Logs.
                //string directoryPath = "C:\\Logs";

                // The @ symbol creates a *verbatim string literal* in C#. In verbatim strings, the backslash '\' 
                // is not treated as an escape character, so you can write file paths with single backslashes 
                // (e.g., C:\Logs) without needing to escape them. This makes it easier and more readable for paths.
                string directoryPath = @"C:\Logs";
            

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, "log.txt");

                // everytime we run this code this will add hello word to the text file
                File.AppendAllText(filePath, message + "\n");
            }
        }


        public class DatabaseLogger : ILogger
        {
            public void Log(string message)
            {
                // Implement the logic to log a message to a database
                Console.WriteLine($"Logging to database. {message}");
            }

        }

        public class Application
        {
            private readonly ILogger _logger;
            public Application(ILogger logger)
            {
                _logger = logger;
            }


            public void DoWork() {

                _logger.Log("Work started!");
                // Do all the work!
                _logger.Log("Work done good job! ");
            }

        }
        static void Main(string[] args)
        {

            ILogger fileLogger = new FileLogger();
            Application application = new Application(fileLogger);

            application.DoWork();

            ILogger dbLogger = new DatabaseLogger();
            application = new Application(dbLogger);
            application.DoWork();


            Console.ReadKey();
        }


      

    }
}
