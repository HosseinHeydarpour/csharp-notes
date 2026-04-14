Console.WriteLine("Guess the number i'm thinking of between 1 and 100: ");

Random random = new Random();
int secretNumber = random.Next(1, 101);
int userGuess = 0;
int counter = 0;

bool isUserRight = false;

while (userGuess != secretNumber)
{
    Console.WriteLine("Enter your guess: ");
    userGuess = int.Parse(Console.ReadLine());
    if(userGuess < secretNumber)
    {
        Console.WriteLine("Too low try again!");
        counter++;
    } else if (userGuess>secretNumber) {
        Console.WriteLine("Too high try again");
        counter++;
    } else
    {
        Console.WriteLine("Congrats! guess is right!");
        Console.WriteLine($"It took you {counter} tries!");
    }
}



Console.ReadKey();