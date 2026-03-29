
// Two different values a bool can have

int num1 = 5;
int num2 = 6;


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


    Console.ReadKey();