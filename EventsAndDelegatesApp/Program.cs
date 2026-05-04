namespace EventsAndDelegatesApp
{

    // Generics in C#?
    //
    // What are Generics?
    //
    // Generics are a way to make your code more flexible and reusable
    // by allowing it to work with any data type.
    //
    // Think of generics as templates that you can fill in with different types
    // when you use them.

    // Generics in C#?
    //
    // Why would you use Generics?
    //
    // • Flexibility.
    //   You can write one method, class, or interface and use it with
    //   different data types without writing multiple versions.
    //
    // • Type Safety.
    //   Generics help catch errors at compile time rather than at runtime,
    //   making your code safer.
    //
    // • Performance.
    //   Generics avoid the need for boxing and unboxing when working
    //   with value types, which can improve performance.

    internal class Program
    {



        static void Main(string[] args)
        {
            int[] intArray = { 1, 2, 3, 4, 5 };
            string[] stringArray = { "One", "Two", "Three", "Four" };

            // PrintArray method works with both types
            PrintArray(intArray);
            PrintArray(stringArray);


            Console.ReadKey();
        }


        public static void PrintIntArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintStringArray(string[] array)
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }


        // a generic Method, that accepts a generic datatype
        // this will allow us to send any datatype
        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
                Console.WriteLine(item);
            }
        }



    }
}
