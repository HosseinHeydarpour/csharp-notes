
for (int i = 0; i < 4; i++)
{
    Console.WriteLine(i);
    if(i==2)
    {
        //Console.WriteLine("I have had enough!");
        // It gets out of the for loop
        //break;

        continue;
    }
    Console.WriteLine(i);
}



// DO NOT DELETE
Console.WriteLine("\n\nPress a key to close the program...");
Console.ReadKey();