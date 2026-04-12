int num = 0;

Console.WriteLine($"Num is {num}");
// incrementing of int
num++;

// String interpolation
Console.WriteLine($"Num is {num}");

// String Formatting
// increment num before use | pre incrementing
Console.WriteLine("Num is {0}", ++num);

// increment num after use | post incrementing
Console.WriteLine("Num is {0}", num++);

Console.WriteLine("Num is {0}", num);


Console.ReadKey();