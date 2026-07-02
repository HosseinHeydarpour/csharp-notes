using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;



namespace Applictaion.Tests
{
    public class FlighApplicationSpecification
    {
        [Fact]
        public void Books_flights()
        {
           var bookingService = new BookingService();

            bookingService.Book(new BookDto());

            bookingService.FindBookings().Should().ContainEquivalentOf(new BookingRm());


        }
    }


  

    public class BookingService
    {


        public void Book(BookDto bookDto) { 
        
            throw new NotImplementedException();
        }

        public IEnumerable<BookingRm> FindBookings()
        {
            throw new NotImplementedException();
        }

    }

    // For transfering data
    public class BookDto
    {

    }

    // For reading data
    public class BookingRm
    {

    }

}
