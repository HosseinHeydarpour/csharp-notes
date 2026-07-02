using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Data;
using Domain;


namespace Applictaion.Tests
{
    public class FlighApplicationSpecification
    {
        [Fact]
        public void Books_flights()
        {


            var entities = new Entities();
            var flight = new Flight(3);

            entities.Flights.Add(flight);

           var bookingService = new BookingService(entities: entities);


            bookingService.Book(new BookDto(
                flighId: flight.Id,
                passengerEmail: "a@b.com",
                numberOfSeats: 2
             ));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail: "a@b.com", numberOfSeats:2)
                );


        }
    }


  

    public class BookingService
    {

        public BookingService(Entities entities)
        {
            
        }

        public void Book(BookDto bookDto) { 
        
            
        }

        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return new[]
            {
                 new BookingRm(passengerEmail: "a@b.com", numberOfSeats:2)
            };
        }

    }

    // For transfering data
    public class BookDto
    {
        public BookDto(Guid flighId, string passengerEmail, int numberOfSeats)
        {
            
        }
    }

    // For reading data
    public class BookingRm
    {

        public string PassengerEmail { get; set; }
        public int NumberOfSeats { get; set; }


        public BookingRm(string passengerEmail, int numberOfSeats)
        {
            PassengerEmail = passengerEmail;    
            NumberOfSeats = numberOfSeats;
        }
    }

}
