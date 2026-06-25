using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    // We add a constraint here we want the class to be generic only for classes not ints or strings
    internal class Box<T> where T : class
    {
      

    }
        
}
