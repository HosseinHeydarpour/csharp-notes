// The While Loop
//Console.WriteLine("---- Coming from for loop ----");
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}

Console.WriteLine("---- Coming from while loop ----");

//bool isGood = true;

//while (isGood)
//{
//    Console.WriteLine("God is Good");
//    isGood = false;
//}

Console.WriteLine("Enter go or stay?");
string userChoice = Console.ReadLine();

while (userChoice.ToLower().Trim() =="go")
{
    Console.WriteLine("God for a mile!");
    Console.WriteLine("Wanna keep going? enrter go!");
    userChoice = Console.ReadLine();
}
Console.WriteLine("Oh! Finally!!");

Console.ReadKey();