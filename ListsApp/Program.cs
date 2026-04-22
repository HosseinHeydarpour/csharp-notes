namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring a list and initializing 
            List<string> colors = new List<string>();



            colors.Add("Red");
            colors.Add("Blue");
            colors.Add("Pink");
            colors.Add("Green");

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




            Console.ReadLine();
        }
    }
}
