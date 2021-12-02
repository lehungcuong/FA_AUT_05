using System.Threading;
using Xunit;
using XUnitTest_POM.Page;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Test
{
    public class BookingFlightsTest : BaseTest
    {
        readonly HomePage homePage;
        readonly SearchFlightPage searchFlightPage;
        readonly ChooseFlightPage chooseFlightPage;
        readonly BookingFlightsPage bookingFlightsPage;
        readonly ProceedBookFlightPage proceedBookFlightPage;

        #region Constructor
        /// <summary>
        /// Constructor of Booking Flights Test
        /// </summary>
        public BookingFlightsTest()
        {
            homePage = new HomePage(BrowserFactory.driver);
            searchFlightPage = new SearchFlightPage(BrowserFactory.driver);
            chooseFlightPage = new ChooseFlightPage(BrowserFactory.driver);
            bookingFlightsPage = new BookingFlightsPage(BrowserFactory.driver);
            proceedBookFlightPage = new ProceedBookFlightPage(BrowserFactory.driver);
        }
        #endregion

        /// <summary>
        /// Test of Booking Flights Test
        /// </summary>
        [Fact(DisplayName = "Booking Flight")]
        public void BookingFlight()
        {
            //Assert Homepage
            Assert.True(homePage.VerifyHomePage);

            //Click on Flights page
            homePage.ClickFlightsPage();

            //Assert Flights page
            Assert.True(SearchFlightPage.VerifyFlightsPageTitle);

            //Choose a Flight
            searchFlightPage.ChooseFlight();

            //Assert flight was choosen
            Assert.True(chooseFlightPage.VerifyFlightWasChoosen);

            //Book a trip
            chooseFlightPage.BookATrip();

            //Assert Flights Booking page title
            Assert.True(bookingFlightsPage.VerifyFlightsBookingPageTitle);

            //Fill personal information
            bookingFlightsPage.FillPersonalInformation();

            //Fill all traveller information
            bookingFlightsPage.FillTravellersInformation();

            //Comfirm your booking information
            bookingFlightsPage.ConfirmBooking();

            //Assert proceed booking status and payment
            Assert.True(ProceedBookFlightPage.VerifyProceedPageTitle);

            // Assert proceed booking status and payment
            proceedBookFlightPage.ClickOnProceedBtn();
            Thread.Sleep(2000);

            // Pay with transfer booking flight
            Assert.Equal("Payment with bank transfer", proceedBookFlightPage.VerifyPayWithBankTransferTitle());
            Thread.Sleep(1000);
        }
    }
}
