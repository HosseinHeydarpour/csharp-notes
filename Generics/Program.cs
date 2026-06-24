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

            Logger logger = new Logger();
            logger.Log<int>(10);
            logger.Log<string>("Hello Fucking World!");

            logger.Log("We can call this method without specifying type!");

            logger.Log(new { Name="Hossein", Age=28});

        }
    }
}
