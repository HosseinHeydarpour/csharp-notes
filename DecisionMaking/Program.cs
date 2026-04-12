double num1 = 0, num2=0, result=0;
string op = "";
bool isValid = true;
string userInput;

Console.WriteLine("Welcome to CLI Calculator");
Console.WriteLine("---------------");

Console.WriteLine("Please enter the first number: ");
userInput = Console.ReadLine();


if (!double.TryParse(userInput, out num1))
{
    Console.WriteLine("Input is not a number please try again!");
    isValid = false;
}

if(isValid)
{
    Console.WriteLine("Please enter the second number: ");
    userInput = Console.ReadLine();
    if(!double.TryParse(userInput, out num2))
    {
        Console.WriteLine("Input is not a number please try again!");
        isValid = false;
    }
}


if (isValid) 
{
    Console.WriteLine("Please enter the operator: ");
    op = Console.ReadLine();
    switch (op)
    {
        case "*":
            result = num1 * num2;
            break;
        case "+":
            result = num1 + num2;
            break;
        case "/":
            result = num1 / num2;
            if (num2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                isValid=false;
            } else
            {
                result = num1 / num2;
            }
                break;
        case "-":
            result = num1 - num2;
            break;
        default:
            Console.WriteLine("Error: Invalid operator.");
            isValid = false;
            break;
    }

}




if (isValid)
{
    Console.WriteLine($"Result is: {result}");
}






Console.ReadKey();