using System.Collections;

namespace ListsApp
{
    internal class Program
    {

        


        static void Main(string[] args)

        {
                // key - value
                // key is unique and only exists once
                // Key cannot be null nad also cannot be nullable type
                // Declaring and initializing a Dictionary
                Dictionary<int,string> employees = new Dictionary<int,string>();


                // Adding items to the Dictionary
                employees.Add(101, "John Doe");
                employees.Add(102, "Bob Smith");
                employees.Add(103, "Arthur Morgan");

            // we can treat a dict just like an array to access a value
            string name = employees[101];
            Console.WriteLine(name);

                Console.ReadLine();
        }



    }
}