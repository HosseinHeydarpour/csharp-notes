
//for (int counter = 0; counter <= 10; counter++)
//{
//    Console.WriteLine("Counter is: "+counter);
//}

// in Strings \ is an "Escape Character
// \n stands for new Line
// \r\n this will work on windows/mac/linux
// \r carriage return

string rocket = "     |\r\n     |\r\n    / \\\r\n   / _ \\\r\n  |.o '.|\r\n  |'._.'|\r\n  |     |\r\n ,'|  | |`.\r\n/  |  | |  \\\r\n|,-'--|--'-.|";




for (int counter = 10; counter >= 0; counter--)
{
    Console.Clear();
    //Console.WriteLine(myString);
    Console.WriteLine("Counter is: " + counter);
    Console.WriteLine(rocket);
    // YOU SHOULD NOT USE IN PRODUCTION AND REAL WORD APPS | WHOLE PROGRAM SLEEPS
    rocket = "\r\n" + rocket;
    Thread.Sleep(1000);
}
Console.WriteLine("THE ROCKET HAS LANDED!");




// DO NOT DELETE
Console.ReadKey();