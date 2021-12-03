using DemoPOM.DataTest;
using DemoPOM.Pages;
using System;
using System.Collections.Generic;
using Xunit;

namespace DemoPOM.Test
{
    public class BookingFlightTest : BaseTest
    {
        
        readonly HomePage homePage;
        readonly BookingPage bookingPage;
        readonly FlightPage flightPage; 
        readonly ConfirmBookingPage confirmBookingPage; 
        readonly BookingSuccessPage bookingSuccessPage;
       
        public BookingFlightTest()
        {
            homePage = new HomePage(browser);
            bookingPage = new BookingPage(browser);  
            flightPage = new FlightPage(browser);    
            confirmBookingPage = new ConfirmBookingPage(browser);
            bookingSuccessPage = new BookingSuccessPage(browser);    

        }

        public static IEnumerable<Object[]> Data => new List<Object[]>
        {
            new Object[]
            {
                "DUB",
                "LCG",
                "04-12-2021"
            },
            new Object[]
            {
                "DJO",
                "LOO",
                "04-12-2021"
            }
        };

        [Theory]
        [JsonReader("jsconfig.json", "data")]
        public void BookingFlightPage(string flightFrom, string flightTo, string dateTime)
        {
            homePage.NavigatePageSuccess("PHPTRAVELS - PHPTRAVELS");
            homePage.NavigateToFlightPage();
            flightPage.NavigatePageSuccess("Search Hotels - PHPTRAVELS");
            flightPage.InputFlightInformation(flightFrom, flightTo, dateTime);
            flightPage.ClickToSearchButton();
            bookingPage.NavigatePageSuccess("Flights - PHPTRAVELS");
            bookingPage.NavigateToConfirmBookingpage();
            confirmBookingPage.NavigatePageSuccess("Flight Booking - PHPTRAVELS");
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.NavigatePageSuccess("Flight Invoice - PHPTRAVELS");           
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void BookingFlightPage1(string flightFrom, string flightTo, string dateTime)
        {
            homePage.NavigatePageSuccess("PHPTRAVELS - PHPTRAVELS");
            homePage.NavigateToFlightPage();
            flightPage.NavigatePageSuccess("Search Hotels - PHPTRAVELS");
            flightPage.InputFlightInformation(flightFrom, flightTo, dateTime);
            flightPage.ClickToSearchButton();
            bookingPage.NavigatePageSuccess("Flights - PHPTRAVELS");
            bookingPage.NavigateToConfirmBookingpage();
            confirmBookingPage.NavigatePageSuccess("Flight Booking - PHPTRAVELS");
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.NavigatePageSuccess("Flight Invoice - PHPTRAVELS");
        }

        [Theory]
        [InlineData("DUB", "LCG", "04-12-2021")]
        [InlineData("DJO", "LOO", "04-12-2021")]
        public void BookingFlightPage2(string flightFrom, string flightTo, string dateTime)
        {
            homePage.NavigatePageSuccess("PHPTRAVELS - PHPTRAVELS");
            homePage.NavigateToFlightPage();
            flightPage.NavigatePageSuccess("Search Hotels - PHPTRAVELS");
            flightPage.InputFlightInformation(flightFrom, flightTo, dateTime);
            flightPage.ClickToSearchButton();
            bookingPage.NavigatePageSuccess("Flights - PHPTRAVELS");
            bookingPage.NavigateToConfirmBookingpage();
            confirmBookingPage.NavigatePageSuccess("Flight Booking - PHPTRAVELS");
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.NavigatePageSuccess("Flight Invoice - PHPTRAVELS");
        }

        [Fact(DisplayName = "Booking Flight")]
        public void BookingFlight()
        {
            homePage.NavigatePageSuccess("PHPTRAVELS - PHPTRAVELS");
            homePage.NavigateToFlightPage();
            flightPage.NavigatePageSuccess("Search Hotels - PHPTRAVELS");
            flightPage.InputFlightInformation1();
            flightPage.ClickToSearchButton();
            bookingPage.NavigatePageSuccess("Flights - PHPTRAVELS");
            bookingPage.NavigateToConfirmBookingpage();
            confirmBookingPage.NavigatePageSuccess("Flight Booking - PHPTRAVELS");
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.NavigatePageSuccess("Flight Invoice - PHPTRAVELS");
        }
    }

}
