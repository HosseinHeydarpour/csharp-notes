
//int counter = 15;

// This will get printed 
//int counter = 15;
// It runs at least once even if the condition is not true | checkout the code above | do while is a post test loop
//do
//{
//    Console.WriteLine(counter);
//    counter++;
//}
//while (counter<10);

int number;

do
{
    Console.WriteLine("Enter a positive whole number: ");
    number = int.Parse(Console.ReadLine());
}
while (number <= 0);
Console.WriteLine("Finally!");


// DO NOT DELETE
Console.ReadKey();