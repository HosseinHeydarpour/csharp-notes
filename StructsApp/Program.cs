namespace StructsApp
{

    enum Day { Mo, Tu, We, Th, Fr, Sa, Su };

    // Now indexing starts at 1
    enum Month
    {
        Jan=1,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul = 12,
        Aug,
        Sep,
        Oct,
        Nov,
        Dec
    };
    internal class Program
    {


        static void Main(string[] args)
        {
            Day fr = Day.Fr;
            Day su  = Day.Su;

            Day a = Day.Fr;

            // This is true because both have the value of Fr
            Console.WriteLine(fr==a);

            Console.WriteLine(Day.Mo);

            // We can also get the index of MO
            Console.WriteLine((int)Day.Mo);

            // Feb is at index 2 now because we set the indexing to start from 1
            Console.WriteLine((int)Month.Feb);

            // August is now 13 because we changed july index to 12
            Console.WriteLine((int)Month.Aug);

            Console.ReadLine();
        }
    }
}
