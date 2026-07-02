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

        [Theory]
        [InlineData(3,1,1,3)]
        [InlineData(4, 2, 1, 3)]
        [InlineData(4, 2, 2, 4)]
        public void Canceling_bookings_frees_up_the_saets(
            int initialCapacity,
            int numberOfSeatsToBook,
            int numberOfSeatsToCancel,
            int remainingNumberOfSeats
            )
        {
            
            // Given
            var flight = new Flight(seatCapicity: initialCapacity);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToBook);

            // When
            flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToCancel);


            // Then
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);



        }

        [Fact]
        public void Does_not_cancel_bookings_for_passengers_who_have_not_booked()
        {
            // Given
            var flight = new Flight(seatCapicity:3);

            // When
            var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 2);

            // Then
            error.Should().BeOfType<BookingNotFoundError>();

        }


        [Fact]
        public void Returns_null_when_successfully_cancel_booking()
        {
            // Given
            var flight = new Flight(seatCapicity: 3);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: 1);
            
            // When
            var error = flight.CancelBooking(passengerEmail:"a@b.com",numberOfSeats: 1);

            //Then
            error.Should().BeNull();
        }


    }

    
}
