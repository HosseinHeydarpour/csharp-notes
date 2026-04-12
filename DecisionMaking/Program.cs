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

Console.WriteLine("---- Dec ----");

// Decrementing
num--;
Console.WriteLine("Num is {0}",num);

// Decrement num before use | pre incrementing
Console.WriteLine("Num is {0}", --num);

// Decrement num after use | post incrementing
Console.WriteLine("Num is {0}", num--);
Console.WriteLine("Num is {0}", num);

Console.WriteLine("--------");
num += 30;
Console.WriteLine("Num is {0}", num);
num -= 10;
Console.WriteLine("Num is {0}", num);

num *= 10;
Console.WriteLine("Num is {0}", num);

num /= 20;
Console.WriteLine("Num is {0}", num);

Console.WriteLine("--------");
int num1 = 10;
int num2 = 3;

// Modulo Operator
int result = num1 % num2;
// 10/3 = 3 remainder 1
Console.WriteLine(result);



Console.ReadKey();