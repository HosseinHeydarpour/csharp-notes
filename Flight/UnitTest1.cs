using System;
using Xunit;
using FluentAssertions;
using Domain.Tests;

namespace FlightTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var flight = new Domain.Tests.Flight(seatCapicity: 3);

            flight.Book("Hossein@gmail.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);   
        }
    }

    
}
