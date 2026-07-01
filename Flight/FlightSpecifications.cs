using System;
using Xunit;
using FluentAssertions;
using Domain;

namespace FlightTest
{
    public class FlightSpecifications
    {
        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(6, 3, 3)]
        [InlineData(10, 6, 4)]
        [InlineData(100, 1, 99)]
        [InlineData(100, 100, 0)]
        public void Booking_reduces_the_number_of_seats(int seatCapacity, int numberOfSeats, int remainingNumOfSeats)
        {
            // Given
            var flight = new Flight(seatCapicity: seatCapacity);

            flight.Book("Hossein@gmail.com", numberOfSeats);

            flight.RemainingNumberOfSeats.Should().Be(remainingNumOfSeats);
        }





        [Fact]
        public void Avoids_overbooking()
        {
            // Given
            var flight = new Flight(seatCapicity: 3);

            // When
            var error = flight.Book("hossein@g.com", numberOfSeats: 4);

            // Then
            error.Should().BeOfType<OverbookingError>();
        }


        [Fact]
        public void Books_flight_successfully()
        {
            // Given
            var flight = new Flight(seatCapicity: 3);

            // When
            var error = flight.Book("A@g.com", 1);

            // Then
            error.Should().BeNull();

        }

        [Fact]
        public void Remembers_bookings()
        {
            // Given
            var flight = new Flight(seatCapicity: 100);

            // When
            flight.Book("Joe@j.me", 5);

            // Then
            flight.BookingList.Should().ContainEquivalentOf(new Booking( "Joe@j.me", 5 ));
        }

    }

    
}
