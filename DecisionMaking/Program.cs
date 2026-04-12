
// Creating an instance of the Random Class
Random random = new Random();
// Max value is exclusive 
int randomNumber = random.Next(1, 11);



Console.WriteLine("Guess the number: ");
string inputString = Console.ReadLine();
// integers by default get set to 0
int num1;
bool isNumber = int.TryParse(inputString, out num1);

if (isNumber)
{
    if(num1 == randomNumber)
    {
        Console.WriteLine("You guessed right!");
    } else
    {
        Console.WriteLine("You guessed wrong! try again!");
    }
}else
{
    Console.WriteLine("Input is not a number!");
}

    num1++;
Console.WriteLine("User entered number +1 is: " + num1);




Console.ReadKey();
