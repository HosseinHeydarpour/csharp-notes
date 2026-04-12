Console.WriteLine("Give me a number: ");
string inputString = Console.ReadLine();
// integers by default get set to 0
int num1;
bool isNumber = int.TryParse(inputString, out num1);

if (isNumber)
{
    Console.WriteLine("Well done you entered a number!");
}else
{
    Console.WriteLine("Input is not a number!");
}

    num1++;
Console.WriteLine("User entered number +1 is: " + num1);




Console.ReadKey();
