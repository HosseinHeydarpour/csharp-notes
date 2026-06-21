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



    public class  MathUtils
    {

        // Comment (inline comment)

        /*
         * Multiple 
         * Line
         * Comment
        */



        // Bad: Calculates the factorial number | it is bad because it is so obvious! | Not what but why!
        // Using a recursive approach for calculation | bad also we must say why is this happening
        // We are using a recursive approach here BECAUSE it's more intuitive(GOOD way)
        public int CalculateFactorial(int number)
        {
            if(number <= 1)
            {
                return 1; 
            }
            else
            {
                 return number * CalculateFactorial(number - 1);
            }
        }


        // Using binary search beacuse we want to Improve the performance for the large datasets
        public int BinarySearch(int[] sortedArray, int target) 
        {
            int left = 0;
            int right = sortedArray.Length-1;

            while (left <= right) 
            { 
                int middle = (left + right)/2;

                if (sortedArray[middle] == target) return middle;
                else if (sortedArray[middle] < target) left = middle + 1;
                else right = middle - 1;
            
            }

            return -1;
        }
    }

}
