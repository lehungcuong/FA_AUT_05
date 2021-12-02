﻿using DemoPOM.DataTest;
using DemoPOM.Pages;
using FluentAssertions;
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
            Assert.True(homePage.NavigateWebSuccess());
            homePage.NavigateToFlightPage();
            flightPage.InputFlightInformation(flightFrom, flightTo, dateTime);
            Assert.True(bookingPage.ValidateWebTitle());
            bookingPage.NavigateToConfirmBookingpage();
            Assert.True(confirmBookingPage.ValidateWebTitle());
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.ValidateWebTitle();
            
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void BookingFlightPage1(string flightFrom, string flightTo, string dateTime)
        {
            Assert.True(homePage.NavigateWebSuccess());
            homePage.NavigateToFlightPage();
            flightPage.InputFlightInformation(flightFrom, flightTo, dateTime);
            Assert.True(bookingPage.ValidateWebTitle());
            bookingPage.NavigateToConfirmBookingpage();
            Assert.True(confirmBookingPage.ValidateWebTitle());
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.ValidateWebTitle();
        }

        [Theory]
        [InlineData("DUB", "LCG", "04-12-2021")]
        [InlineData("DJO", "LOO", "04-12-2021")]
        public void BookingFlightPage2(string flightFrom, string flightTo, string dateTime)
        {
            Assert.True(homePage.NavigateWebSuccess());
            homePage.NavigateToFlightPage();
            flightPage.InputFlightInformation(flightFrom, flightTo, dateTime);
            Assert.True(bookingPage.ValidateWebTitle());
            bookingPage.NavigateToConfirmBookingpage();
            Assert.True(confirmBookingPage.ValidateWebTitle());
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.ValidateWebTitle();
        }

        [Fact(DisplayName = "Booking Flight")]
        public void BookingFlight()
        {
            homePage.NavigatePageSuccess("PHPTRAVELS - PHPTRAVELS");
            //Assert.True(homePage.NavigateWebSuccess());
            homePage.NavigateToFlightPage();
            flightPage.InputFlightInformation1();
            flightPage.ClickToBookingButton();
            bool result1 = bookingPage.NavigateWebSuccess();
            result1.Should().BeTrue(because: "Go to page unsuccessful!");
            Assert.True(bookingPage.ValidateWebTitle());
            bookingPage.NavigateToConfirmBookingpage();
            bool result2 = confirmBookingPage.NavigateWebSuccess();
            result2.Should().BeTrue(because: "Go to page unsuccessful!");
            Assert.True(confirmBookingPage.ValidateWebTitle());
            confirmBookingPage.InputUserInformation();
            confirmBookingPage.InputTravellerInformation();
            confirmBookingPage.PaymentConfirm();
            confirmBookingPage.ClickToTermAndConditionButton();
            confirmBookingPage.NavigateToBookingSuccessPage();
            bookingSuccessPage.ValidateWebTitle();
        }
    }

}