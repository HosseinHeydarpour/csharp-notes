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

            Box<string> boxStr = new Box<string>("Hossein");
            boxStr.UpdateContent("Reza");
            Console.WriteLine(boxStr.GetContent());

      
        }
    }
}
