using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.TestPage;
using Xunit;

namespace PageObjectModel.TestBookFlight
{
    public class TestBookingFlight : BookFlightBase
    {

        HomePage homePage;
        BookFlightPages bookFlightPage;
        InformationPage informationPage;
        SearchBookFlightPage searchBookFlightPage;

        
        public  TestBookingFlight()
        {
            homePage = new HomePage(browserFactory.Driver);
            bookFlightPage = new BookFlightPages(browserFactory.Driver);
            searchBookFlightPage = new SearchBookFlightPage(browserFactory.Driver);
            informationPage = new InformationPage(browserFactory.Driver);
        }


        // inlines test booking flight
    [Theory (DisplayName  = "TestBookingFlightProcess")]

    [InlineData("Le", "Cuong", "cuonglv@live.com", "0909090909", "22 Nam Ky Khoi Nghia,Ho Chi Minh city",
            "Le","cuong", "15", "1996", "03032894829", "29", "2020", "10", "2024")]

    [InlineData("Tran", "Trong", "TrongTT@live.com", "09092334909", "33 Nam Ky Khoi Nghia,Ho Chi Minh city",
            "Tran", "Trong", "23", "1996", "03032854329", "2", "2019", "13", "2022")]



    public void CheckBookingFlightProcess(string InFirstName, string InLastName, string InpEmail, string InpPhone, string InpAddress,
        string InputFirstName, string InputLastName, string Selectday, string SelectYear, string InpPassport, string Selectday_1,
        string SelectYear_1, string Selectday_2, string SelectYear_2)
    {
            homePage.GotoFlightBooking();

            // FluentAssertion
            Assert.Equal("Search Hotels - PHPTRAVELS", browserFactory.Driver.Title );
            "Search Hotels - PHPTRAVELS".Should().Be(browserFactory.Driver.Title, "Can't navigate to serach hotel");

            bookFlightPage.InputBookingFlightValues();
            Assert.Equal("Search hotel - PHPTRAVELS", browserFactory.Driver.Title);

            // FluentAssertion
            searchBookFlightPage.ChooseTicketFlight();
            Assert.True(browserFactory.Driver.Equals("Flight - PHPTRAVELS"));
            browserFactory.Driver.Equals("Flight - PHPTRAVELS").Should().BeTrue("Can't navigate to serach hotel");

            informationPage.InputInformation();
            informationPage.Scrolldown();
            Assert.True(browserFactory.Driver.Equals("Flight Booking - PHPTRAVELS "));
    }
    }
}
