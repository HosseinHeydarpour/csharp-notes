using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Box<string, int> toyBox = new Box<string, int>("Tommy Shelby Toy", 1);

            toyBox.Display();



      
        }
    }
}
