using System.Collections;

namespace ListsApp
{
    internal class Program
    {

        


        static void Main(string[] args)

        {

            var codes = new Dictionary<string, string> 
            {
                ["NY"]= "New York",
                ["CA"]= "California",
                ["TX"] = "Texas"
            };


          

            //string state;
            // you pass the key if it is there it will output value in the state
            // TryGetValue returns a boolean
            if (codes.TryGetValue("NY", out string state))
            {
                Console.WriteLine(state);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var code in codes)
            {   
                Console.WriteLine("----------");
                Console.WriteLine($"{code.Value} code is: {code.Key}");
            }
            Console.ResetColor();


            Console.ReadLine();
        }



    }
}