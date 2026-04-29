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
            employees.Add(104, "Megan Fox");
            employees.Add(105, "Jon Snow");
            employees.Add(106, "Arya Stark");
          

            // we can treat a dict just like an array to access a value
            string name = employees[101];
            Console.WriteLine(name);

            // Update data in a dictionary
            employees[102] = "Bob Dylan";

            // Remove an item from a dictionary
            //employees.Remove(106);

            // This will give us an error because we cannot add an item with the same key
            //employees.Add(104, "Ned Stark");

            // But this is only updating
            //employees[104] = "Ned Stark";

            // This is how you can handle duplicates
            //if (!employees.ContainsKey(104))
            //{
            //    employees.Add(104, "Ned Stark");
            //} else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Error... This key already exists");
            //    Console.ResetColor();
            //}

            /* This is just a workaround
            int counter = 101;
            while (employees.ContainsKey(counter))
            {
                counter++;
            }
            employees.Add(counter, "Jon Snow");
            */

            // TryAdd here returns a bool | we can use it
            bool added = employees.TryAdd(102, "Mike Joe");
            if (!added) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error... This Employee id already exists");
                Console.ResetColor();
            }



            // Iterating over a Dictionary
            foreach (KeyValuePair<int, string> employee in employees)
                {
                    Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value}");
                }

            Console.ReadLine();
        }



    }
}