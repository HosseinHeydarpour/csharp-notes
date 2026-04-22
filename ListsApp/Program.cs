namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {10,5,6,12,34,12,13 };


            // Define a predicate to check if a number is greater than or equal 10
            // A Predicate is just a function that takes one value (here: an int)
            // and returns TRUE or FALSE. It's used to test/check something.
            //
            // In this case:
            // "isGreaterThan10" will return true if x is 10 or more,
            // and false if x is less than 10.
            Predicate<int> isGreaterThan10 = x => x >= 10;

            // This will return a list of numbers that are 10 or higher
            List<int> biggerThanEqualTen = numbers.FindAll(isGreaterThan10);
            Console.WriteLine("10 or hihger numbers");
            // All numbers ten or higher in numbers list
            DisplayList(biggerThanEqualTen);
            Console.WriteLine("===============");




            Console.WriteLine("Unsorted List");
            DisplayList(numbers);

            Console.WriteLine("===============");

            numbers.Sort();

            Console.WriteLine("Sorted List");
            DisplayList(numbers);
            
            


            Console.ReadLine();
        }

        // A lambda expression consists of 2 Parts
        // 1. Parameters
        // 2. Expression or Statement Block

        // Parameters are written on the left side of =>
        // (this symbol is read as "goes to" or "becomes")
        // The expression or action to perform is on the right side

        // This reads as:
        // " Take an input x and turn it into x multiplied by x. "
        // x => x * x;
        // Lambda expression : =>

        // Equivalant method for --> x => x * x;
        static int Squaring(int num) 
        { 
            return num*num;
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
