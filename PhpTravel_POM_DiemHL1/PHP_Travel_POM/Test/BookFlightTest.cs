using System;
using System.Threading;
using FluentAssertions;
using OpenQA.Selenium;
using PHP_Travel_POM.Pages;
using TestPOM.Test;
using Xunit;

namespace PHP_Travel_POM.Test
{
    public class BookFlightTest : BaseTest
    {
        private readonly HomePage HomePage;
        private readonly FlightBookingPage FlightBookingPage;
        private readonly SearchFlightPage SearchFlightPage;
        private readonly BookingPage BookingPage;
        private readonly InvoicePage InvoicePage;

        public BookFlightTest()
        {
            HomePage = new HomePage(browserFactory.Driver);
            FlightBookingPage = new FlightBookingPage(browserFactory.Driver);
            SearchFlightPage = new SearchFlightPage(browserFactory.Driver);
            BookingPage = new BookingPage(browserFactory.Driver);
            InvoicePage = new InvoicePage(browserFactory.Driver);
        }

        /// <summary>
        /// Test case Book Flight Function
        /// </summary>
        [Fact(DisplayName = "Test case Book Flight Function")]
        public void BookFlight()
        {
            // Step 1. Click the flight booking function
            HomePage.ClickOnFlightButton();

            // Step 2. Flight search
            SearchFlightPage.TxtSearchFlight();

            // Step 3: Choose a flight
            SearchFlightPage.ClickOnSearchFlight();

            // Used for accurate comparison of flight search information
            // Because the flight booking website has an error, I cannot perform Assert Fluent for the BookFlight testcase
            IWebElement Compare_DUB_LCG = browserFactory.Driver.FindElement(By.XPath("//h2[@class='sec__title_list']"));
            Assert.Equal("DUB LCG", Compare_DUB_LCG.Text);

            // Step 5: Confirm flight selection
            SearchFlightPage.ClickOnBookNow();

            // Use assert to correctly compare Flight Booking - PHPTRAVELS titles
            // Because the flight booking website has an error, I cannot perform Assert Fluent for the BookFlight testcase
            Assert.True(browserFactory.Driver.Title == "Flight Booking - PHPTRAVELS");

            // Step 6: Enter your flight booking information
            BookingPage.InputFlightBookingInfomation();

            // Step 7: Scroll down the screen and wait 1 second before doing it
            IJavaScriptExecutor ScrollPay = (IJavaScriptExecutor)browserFactory.Driver;
            ScrollPay.ExecuteScript("scroll(0, 1200);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 8: Select the booking button on the screen
            BookingPage.ClickOnBookingPage();

            // Use assert to correctly compare Flight Invoice - PHPTRAVELS titles
            // Because the flight booking website has an error, I cannot perform Assert Fluent for the BookFlight testcase
            Assert.True(browserFactory.Driver.Title == "Flight Invoice - PHPTRAVELS");

            // Step 9: Click the Confirm Booking button
            InvoicePage.ClickOnCorfimBookingButton();
            browserFactory.Driver.Quit();
        }
    }
}
