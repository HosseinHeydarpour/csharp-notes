using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Applictaion.Tests
{
    public class FlighApplicationSpecification
    {
        [Theory]
        [InlineData("m@m.com",2)]
        [InlineData("a@m.com", 3)]
        [InlineData("c@f.com", 5)]
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {


            var entities = new Entities
            (
                new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options
            );
            var flight = new Flight(3);

            entities.Flights.Add(flight);

           var bookingService = new BookingService(entities: entities);


            bookingService.Book(new BookDto(
                flighId: flight.Id,
              passengerEmail,
                numberOfSeats: numberOfSeats
             ));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail: passengerEmail, numberOfSeats: numberOfSeats)
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
