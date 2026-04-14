// Declare an array and set the array element values
int[] myIntArray = [0,1,2,3,4];
string[] weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];


Console.WriteLine($"Length of weekdays Array is: {weekDays.Length}");

// Iterate with for loop
//for (int i = 0; i < weekDay.Length; i++)
//{
//    Console.WriteLine(weekDay[i]);
//}


foreach (string day in weekDays)
{
    Console.WriteLine(day);
}




// Indexes [0][1][2][3][4]
// Content [5][12][13][14][15]


// DO NOT DELETE
Console.WriteLine("\n\nPress a key to close the program...");
Console.ReadKey();