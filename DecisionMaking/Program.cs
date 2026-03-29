int month = 5;
string monthName;

if (month == 1)
{
    monthName = "January";
}
else if (month == 2) monthName = "February";
else if (month == 3) monthName = "March";
else monthName = "Unknown";






















/*
// Two different values a bool can have

int num1 = 5;
int num2 = 6;
// to access age || the scope is entire program.cs file
int age = 0;

//string address = "";

bool isEqual = num1 == num2;
bool isNotEqual = num1 != num2;

Console.WriteLine("Please enter a whole number: ");

if (num1 == int.Parse(Console.ReadLine())) 
{
    Console.WriteLine("Numbers are Equal!");


    Console.WriteLine("Please enter your age: ");

    age = int.Parse(Console.ReadLine());

    if(age >= 18)
    {
        Console.WriteLine("Please enter your address, so we can send you the prize: ");

        //string address = Console.ReadLine();

        string address = Console.ReadLine();
    } else Console.WriteLine("Sorry, you cannot get your prize due to your age");
}
else
{
    Console.WriteLine("Numbers are not Equal!");

    // address is not accessible in this scope
}




// reset age to 0
age = 0;
*/

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


/*

Console.WriteLine("Please enter your age: ");
int age = int.Parse(Console.ReadLine());
bool isWithParents;

if(age>=18)
{
    Console.WriteLine("Go party in the club!");
} else if (age >= 13)
{
    Console.WriteLine("Are you with your parents? Answer with y or n");
    string isWithParentsString = Console.ReadLine();
    if(isWithParentsString == "y")
    {
        Console.WriteLine("Go party in the club with your parents!");
    } else Console.WriteLine("No Party For You!");
}
else
{
    Console.WriteLine("Go party in the kindergarten!");
}

*/






Console.ReadKey();