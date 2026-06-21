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
            

        }




    }


    
    class OrderProcessor
    {

        // for boolean values - props - fields we always use and start with has or is
        private bool hasErrors = false;

        private bool isValid = true;

        public bool HasErrors { get; set; }

        public bool IsValid()
        {
            return true;
        }
        

    }
  
}
