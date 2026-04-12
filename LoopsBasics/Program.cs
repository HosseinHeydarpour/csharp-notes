// The While Loop
//Console.WriteLine("---- Coming from for loop ----");
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}

Console.WriteLine("---- Coming from while loop ----");

int counter = 0;
while (counter<10)
{
    Console.WriteLine(counter);
    counter++; // IMPORTANT: if we do not do this we will have an infinite loop
}

Console.ReadKey();