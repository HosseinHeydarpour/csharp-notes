namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {10,5,6,12,34,12,13 };

            Console.WriteLine("Unsorted List");
            DisplayList(numbers);

            Console.WriteLine("===============");

            numbers.Sort();

            Console.WriteLine("Sorted List");
            DisplayList(numbers);
            
            


            Console.ReadLine();
        }

        static void DisplayList<T>(List<T> list) 
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
