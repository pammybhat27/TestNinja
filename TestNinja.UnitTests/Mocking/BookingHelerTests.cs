using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking {
    [TestFixture]
    public class BookingHelerTests {
        private Booking _booking;
        private Mock<IBookingRepository> _repositoryMock;

        [SetUp]
        public void setup()
        { _booking = new Booking
            {
                ArrivalDate =  ArriveOn(2017,1,15),
                DepartureDate = DepartOn(2017,1,20),
                Id = 2,
                Reference = "a"
            };

            _repositoryMock = new Mock<IBookingRepository>();
           
            _repositoryMock.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _booking


            }.AsQueryable());
        }

        [Test]
        public void BookingStartsandFinishesBeforeExistingBooking_ReturnEmptyString()
        {
          

           var result =  BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),


            }, _repositoryMock.Object);

            Assert.That(result,Is.Empty);
        }

        private DateTime ArriveOn(int year,int month,int day)
        {
            return new DateTime(year,month,day,14,0,0);
        }

        private DateTime DepartOn(int year,int month,int day)
        {
            return new DateTime(year,month,day,10,0,0);
        }

        private DateTime Before(DateTime dateTime)
        {
            return dateTime.AddDays(-1);

        }

    }
}
