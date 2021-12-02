﻿using AventStack.ExtentReports;
using System.Threading;
using WebDriver;
using Xunit;
using XunitPOM.Pages;
using XunitPOM.Utilities;

namespace XunitPOM.Test
{
    public class BookingFlightTest : BaseTest, IClassFixture<ReportHelper>
    {
        private readonly HomePage HomePage;
        private readonly FlightPage FlightPage;
        private readonly FlightSearchPage FlightSearchPage;
        private readonly BookingPage BookingPage;
        private readonly BookingInvoicePage BookingInvoicePage;
        private readonly BankTransferPage BankTransferPage;

        /// <summary>
        /// Init pages
        /// </summary>
        public BookingFlightTest()
        {
            HomePage = new HomePage(browserFactory.driver);
            FlightPage = new FlightPage(browserFactory.driver);
            FlightSearchPage = new FlightSearchPage(browserFactory.driver);
            BookingPage = new BookingPage(browserFactory.driver);
            BookingInvoicePage = new BookingInvoicePage(browserFactory.driver);
            BankTransferPage = new BankTransferPage(browserFactory.driver);
        }

        /// <summary>
        /// Booking flight test case
        /// </summary>
        [Fact(DisplayName = "Booking Flight Test")]
        public void BookingFlight()
        {
            // Create new test case report
            XunitHelper.CreateTestReport();

            // Validate home page open successfully
            Assert.True(HomePage.ValidateWebOpenSuccess());

            // Change language to english
            HomePage.SelectLanguageEnglish();
            HomePage.NavigateToFlightPage();

            // Validate flight page open successfully
            Assert.True(FlightPage.ValidateWebOpenSuccess());

            // Input search flight and click on search button
            FlightPage.InputSearchFlight();
            FlightPage.ClickOnSearchFlight();

            // Validate flight search page open successfully
            Assert.True(FlightSearchPage.ValidateWebOpenSuccess());

            // Click on first item from index
            FlightSearchPage.ClickOnFirstItem();

            // Validate booking page open successfully
            Assert.True(BookingPage.ValidateWebOpenSuccess());

            // Input booking information
            // BookingPage.InputPersonalInformation();
            BookingPage.InputFlightTravellersInformation();

            // Choose payment method
            BookingPage.ChoosePaymentMethod();

            // Click on confirm booking
            BookingPage.FlightClickOnConfirmBooking();

            // Validate booking invoice page open successfully
            Assert.True(BookingInvoicePage.ValidateWebOpenSuccess());

            // Click on proceeed check out button
            BookingInvoicePage.ClickOnProceedCheckOut();

            // Validate booking success
            BrowserFactory.AssertBool(BankTransferPage.ValidateCheckOut(), true);
        }
    }
}
