
//for (int counter = 0; counter <= 10; counter++)
//{
//    Console.WriteLine("Counter is: "+counter);
//}

// in Strings \ is an "Escape Character
// \n stands for new Line
// \r\n this will work on windows/mac/linux
// \r carriage return

string myString = "Hi \r\nHi";




for (int counter = 10; counter >= 0; counter--)
{
    //Console.WriteLine(myString);
    Console.WriteLine("Counter is: " + counter);

    // YOU SHOULD NOT USE IN PRODUCTION AND REAL WORD APPS | WHOLE PROGRAM SLEEPS
    Thread.Sleep(1000);
}




// DO NOT DELETE
Console.ReadKey();