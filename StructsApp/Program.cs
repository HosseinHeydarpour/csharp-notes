using Microsoft.VisualBasic;

namespace StructsApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // DateTime dateTime = new DateTime(1998,3,20);

            DateTime dateTime = new DateTime(1998, 3, 20);
            Console.WriteLine("My birthday is: {0}", dateTime);

            Console.WriteLine("----------------");

            // Write today on screen
            Console.WriteLine(DateTime.Today);

            Console.WriteLine("----------------");

            // Write current time on screen
            Console.WriteLine(DateTime.Now);

            Console.WriteLine("----------------");

            // Write tomorrow date on screen
            DateTime tomorrow = GetTomorrow();
            Console.WriteLine($"Tomorrow will be the: {tomorrow}");

            Console.WriteLine("----------------");
            Console.WriteLine($"Today is {DateTime.Today.DayOfWeek}");

            Console.WriteLine("----------------");
            Console.WriteLine(GetFirstDayOfTheYear(1998));

            Console.WriteLine("----------------");
            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine("Days in February 2000: "+days); // leap year
             days = DateTime.DaysInMonth(2001, 2);
            Console.WriteLine("Days in February 2001: " + days);
             days = DateTime.DaysInMonth(2004, 2);
            Console.WriteLine("Days in February 2004: " + days); // leap year


            DateTime now = DateTime.Now;
            Console.WriteLine($"Minute is -{now.Minute}- ");


            // Display the time in this structure -> x o'clock and y minutes and z seconds
            Console.WriteLine($"{now.Hour} o'clock and {now.Minute} minutes and {now.Second} seconds. ");


            Console.WriteLine("Write a date in this format: (yyyy-mm-dd)");
            string input = Console.ReadLine();

            if(DateTime.TryParse(input, out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = now.Subtract(dateTime);
                Console.WriteLine($"Days passed since: {daysPassed.Days}");
            } else
            {
                Console.WriteLine("Wrong input! ");
            }


            Console.WriteLine("Enter your birthday in this format: (yyyy-mm-dd)");
            string birthday = Console.ReadLine();

            if(DateTime.TryParse(birthday, out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = now.Subtract(dateTime);
                Console.WriteLine($"Days passed since your birthday: {daysPassed.Days}");
            } else
            {
                Console.WriteLine("Wrong format!");
            }




                Console.ReadLine();
        }

        static DateTime GetTomorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        static DateTime GetFirstDayOfTheYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

    }
}
