using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// By using a LINQ Query Operation you can get data from different types of data sources
// Arrays, Databases, XML files and many more sources are valid for a query operation

// Example usage: You should print out the entries of a string array sorted by name

// Three parts of a query operation:
// 1. obtain a data source
// 2. create the query
// 3. execute the query



namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            OddNumbers(numbers);

            Console.ReadKey();
        }

        static void OddNumbers(int[] numbers) 
        {
            //foreach (int num in numbers) 
            //{ 
            //    if(num % 2 != 0)
            //    {
            //        Console.WriteLine($"ODD Number: {num}");
            //    }
            //}

            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;

            Console.WriteLine(oddNumbers);

            foreach (int num in oddNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
