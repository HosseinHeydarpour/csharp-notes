string[,] ticTacToe = 
{
    { "O", "X", "X" },
    { "O", "O", "X" }, 
    { "X", "X", "O" } 
};

Console.WriteLine(ticTacToe[1,2]);

string[,] undrestandingIndexes =
{
    {"0,0", "0,1", "0,2" },
    {"1,0", "1,1", "1,2" },
    {"2,0", "2,1", "2,2" },
};

Console.WriteLine(undrestandingIndexes[1,2]);

// DO NOT DELETE
Console.WriteLine("\n\nPress any key to close the program...");
Console.ReadKey();