namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring a list and initializing 
            List<string> colors = 
            [
               // Adding items to the list | The simpler way
               "Red","Blue","Green","Cyan","Red"
            ];


            // Adding items to the list | but it can be simpler
            colors.Add("Purple");
            //colors.Add("Blue");
            //colors.Add("Green");
            //colors.Add("Red");

            Console.WriteLine("Current colors in the colors list: ");
            foreach (string color in colors)
            {
               
                if (Enum.TryParse<ConsoleColor>(color, true, out var consoleColor)) 
                {
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White; // fallback color
                }
                Console.WriteLine(color);
            }

            // This removes the first occurence of an item in the list | jusr first occurence | if we have red blue red --> blue red
            // Also returns a bool if removal was successful we get true otherwise we get false
            Console.ResetColor();
            bool isDeletingSuccess =  colors.Remove("Red");  // True
            //Console.WriteLine(isDeletingSuccess);
            // isDeletingSuccess = colors.Remove("Some color which is not in list"); // False
            //Console.WriteLine(isDeletingSuccess);

            // Delete all "Red" colors
            while (isDeletingSuccess) {
                isDeletingSuccess = colors.Remove("Red");
            }
   

            Console.WriteLine("\n=============\n");
            foreach (string color in colors)
            {

                if (Enum.TryParse<ConsoleColor>(color, true, out var consoleColor))
                {
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White; // fallback color
                }
                Console.WriteLine(color);
            }




            Console.ReadLine();
        }
    }
}
