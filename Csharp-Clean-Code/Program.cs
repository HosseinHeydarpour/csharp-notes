using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Csharp_Clean_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ReadFile("c://");
        }


        public static void ReadFile(string filePath)
        {

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            // File not found
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Oops! File not found! " + ex.Message);
            }
            // Unauhtorized Access
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Oops! You are not allowed to access this file! " + ex.Message);
            }
            // Any Other Exception
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Something went wrong! " + ex.Message);
            }




        
       
            
        }


    }


 


}
