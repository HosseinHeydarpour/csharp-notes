
// Two different values a bool can have
bool isRaining = false;
bool hasUmberella = false;


// Logical Operatos  --> && || !
// AND &&
// OR ||
// NOT !


if(isRaining && hasUmberella)
{
    Console.WriteLine("I'm protected against rain!");    
}


// Variants of OR statements
// true || true -> true 
// true || flase -> true
// false || true -> true
// flase || false -> false

// negation
if (!isRaining  || hasUmberella)
{
    Console.WriteLine("I'm not getting WET!");
}



Console.WriteLine("Ay OK");
Console.ReadKey();