
//int counter = 15;

// This will get printed 
//int counter = 15;
// It runs at least once even if the condition is not true | checkout the code above | do while is a post test loop
//do
//{
//    Console.WriteLine(counter);
//    counter++;
//}
//while (counter<10);

int currentScore;
int sum = 0;
int counter = 0;

do
{
    Console.WriteLine("Enter your students score. Enter -1 to finish!");
    currentScore = int.Parse(Console.ReadLine());
    if (currentScore != -1)
    {
        sum = sum + currentScore;
        counter++;
    }
   
}
while (currentScore != -1);

int average = sum / counter;



Console.WriteLine($"The average is: {average}");

// DO NOT DELETE
Console.ReadKey();