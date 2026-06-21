using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Clean_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // bad - you should not do it in this way
            // Someone else will not undrestand your code | it must be as obvious as possible
            int n = 100;
            string s = "John";

            // good
            // This is a good practice because later people will undrestand 
            int studentCount = 100;
            string studentName = "John";

        }
    }
}
