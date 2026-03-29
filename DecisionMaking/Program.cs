
// Two different values a bool can have

int num1 = 5;
int num2 = 6;

bool isEqual = num1 == num2;
bool isNotEqual = num1 != num2;

Console.WriteLine("Please enter a whole number: ");

if (num1 == int.Parse(Console.ReadLine())) 
{
    Console.WriteLine("Numbers are Equal!");


    Console.WriteLine("Please enter your age: ");

    int age = int.Parse(Console.ReadLine());
    if(age >= 18)
    {
        Console.WriteLine("Please enter your address, so we can send you the prize: ");
        string address = Console.ReadLine();
    } else Console.WriteLine("Sorry, you cannot get your prize due to your age");
}
else Console.WriteLine("Numbers are not Equal!");


    


/*

// relational operator > >=  _  < <=
// The default value for a bool is false
bool isGreater = num1 > num2;
int age = 18;
bool isWithParents = true;

// Greate or EQUAL 18
// always goes from top to bottom
if(age >= 13 && isWithParents)
{
    Console.WriteLine("Go party in the club with your parents!");
} else if (age >= 18)
{
    Console.WriteLine("Go party in the club!");
}
else
{
    Console.WriteLine("Go party in the kindergarten!");
}

*/
    Console.ReadKey();