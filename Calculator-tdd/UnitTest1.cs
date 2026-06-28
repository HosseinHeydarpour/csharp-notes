
using Xunit;
using System;
using Domain;

namespace Calculator_test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calculator = new Calculator();
            // Testing Condition
            if(calculator.Sum(2,2) != 4)
            {
                throw new Exception("Test failed: 2 + 2 did not equal 4.");
            }
        }



        


    }
}
