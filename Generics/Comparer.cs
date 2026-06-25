using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Comparer
    {

        /// <summary>
        /// Compares two reference type objects for reference equality.
        /// </summary>
        /// <remarks>
        /// The 'where T : class' constraint ensures that the '==' operator performs 
        /// a reference comparison (or uses a class-defined operator overload) rather 
        /// than throwing a compilation error, as '==' is not defined for open generic types.
        /// </remarks>
        public static bool AreEqual<T>(T first, T second) where T: class
        {
            return first == second; 
        }


    }
}
