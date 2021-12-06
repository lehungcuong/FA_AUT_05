using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using Xunit;
using XUnitTest_POM.APIRestSharp;
using XUnitTest_POM.Constraints;
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

        //Because the data of this test don't work anymore, so we can't test it

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
        //[Fact(DisplayName = "Booking Flight")]
        public void BookingFlight()
        {
            //Assert Homepage
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "HomePage fail");

            //Click on Flights page
            homePage.ClickFlightsPage();

            //Assert Flights page
            BrowserFactory.FluentAssert(SearchFlightPage.VerifyFlightsPageTitle, "Search Flight page fail");

            //Choose a Flight
            searchFlightPage.ChooseFlight();

            //Assert flight was choosen
            BrowserFactory.FluentAssert(chooseFlightPage.VerifyFlightWasChoosen, "Choose flight page fail");

            //Book a trip
            chooseFlightPage.BookATrip();

            //Assert Flights Booking page title
            BrowserFactory.FluentAssert(bookingFlightsPage.VerifyFlightsBookingPageTitle, "Booking flight page fail");

            //Fill personal information
            bookingFlightsPage.FillPersonalInformation();

            //Fill all traveller information
            bookingFlightsPage.FillTravellersInformation();

            //Comfirm your booking information
            bookingFlightsPage.ConfirmBooking();

            //Assert proceed booking status and payment
            BrowserFactory.FluentAssert(ProceedBookFlightPage.VerifyProceedPageTitle, "Proceed book flight page fail");

            // Click on proceed button
            proceedBookFlightPage.ClickOnProceedBtn();
        }
    }
}
