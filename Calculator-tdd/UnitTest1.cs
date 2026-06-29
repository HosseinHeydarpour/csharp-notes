
using Xunit;
using System;
using Domain;


namespace Calculator_test
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_of_2_and_2_must_be_4()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(2, 2);
            if(result != 4)
            {
                throw new Exception("Sum of 2 and 2 is not 4!");
            }
        }


        






    }
}
