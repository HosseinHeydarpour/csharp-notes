using System.Xml.Serialization;

namespace InterfaceApp
{
    internal class Program
    {

        static void Main(string[] args)
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
            string message = "This is a log entry";

            if (!Directory.Exists(directoryPath)) 
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "log.txt");

            // everytime we run this code this will add hello word to the text file
            File.AppendAllText(filePath, message + "\n");
           
          
            Console.ReadKey();
        }


      

    }
}
