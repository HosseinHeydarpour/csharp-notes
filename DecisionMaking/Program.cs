
// Two different values a bool can have
bool isRaining = true;
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

// Variants of AND statements
// true && true -> true 
// true && flase -> false
// false && true -> false
// flase && false -> false

// negation
if (isRaining && !hasUmberella)
{
    Console.WriteLine("I'm getting WET!");
}



Console.WriteLine("Ay OK");
Console.ReadKey();