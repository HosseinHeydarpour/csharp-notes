using System.Xml.Serialization;

namespace InterfaceApp
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // everytime we run this code this will add hello word to the text file
            File.AppendAllText("log.text","Hello World"+ "\n");
           
          
            Console.ReadKey();
        }


      

    }
}
