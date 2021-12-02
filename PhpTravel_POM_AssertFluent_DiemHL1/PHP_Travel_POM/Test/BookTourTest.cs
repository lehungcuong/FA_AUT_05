using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using PHP_Travel_POM.DataTest;
using PHP_Travel_POM.Pages;
using TestPOM.Test;
using Xunit;
using FluentAssertions;

namespace PHP_Travel_POM.Test
{
    public class BookTourTest : BaseTest
    {
        readonly HomePage HomePage;
        readonly SearchToursPage SearchToursPage;
        readonly BookingPage BookingPage;
        readonly TourBookingPage TourBookingPage;

        public BookTourTest()
        {
            HomePage = new HomePage(browserFactory.Driver);
            SearchToursPage = new SearchToursPage(browserFactory.Driver);
            TourBookingPage = new TourBookingPage(browserFactory.Driver);
            BookingPage = new BookingPage(browserFactory.Driver);

        }
        /// <summary>
        /// Initialize the input data list for TestCase Member Data
        /// </summary>
        public static IEnumerable<Object[]> Data => new List<Object[]>
        {
            new Object[]
            {
                "Long",
                "Diem",
                "longdiem0211@gmail.com",
                "0855265663",
                "222/3 Bui Dinh Tuy P12 Binh Thanh"
            },
            new Object[]
            {
                "Diem",
                "HL1",
                "DiemHL1@fsoft.com.vn",
                "0862800704",
                "90/12 An Nhon P17 Go Vap"
            }
        };
        /// <summary>
        /// Use Member Data for Data Driven testing
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        [Theory(DisplayName = "Testcase about MemberData")]
        [MemberData(nameof(Data))]
        public void BookingTourMemberData(string FirstName, string LastName, string Email, string Phone, string Address)
        {
            // Step 1. Click the Tours booking function
            HomePage.ClickOnToursButton();

            // Step 2. Parser out the ListTour list and Choose the 3rd tour location
            SearchToursPage.ClickOnThirdItem();
            IWebElement TXT_BookName = browserFactory.Driver.FindElement(By.XPath("//h3[@class='title font-size-26']"));

            // Step 3. Use Assert Fluent for exact comparison
            browserFactory.AssertFluent("Day Visit of Petra from Oman", TXT_BookName.Text, "Validate item fail");

            // Step 4: Scroll down the screen
            IJavaScriptExecutor scrollInBookNow = (IJavaScriptExecutor)browserFactory.Driver;
            scrollInBookNow.ExecuteScript("scroll(0, 200);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 5. Click Book now
            TourBookingPage.ClickOnBookNow();
            string TourBookingInfomationPageURL = browserFactory.Driver.Url;

            // Step 6. Input Flight Booking Infomation and Scroll down the screen
            BookingPage.InputTourBookingInfomation(FirstName, LastName, Email, Phone, Address);
            IJavaScriptExecutor ScrollPay = (IJavaScriptExecutor)browserFactory.Driver;
            ScrollPay.ExecuteScript("scroll(0, 1100);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 7. Click BookingPage
            BookingPage.ClickOnBookingPage();
            // Pause the screen for 5 seconds
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // End Function
            browserFactory.Driver.Quit();
        }
        /// <summary>
        /// Use Inline Data for Data Driven testing
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        [Theory(DisplayName = "Testcase about InlineData")]
        [InlineData("Diem",
                "HL1",
                "DiemHL1@fsoft.com.vn",
                "0862800704",
                "90/12 An Nhon P17 Go Vap")]
        [InlineData("Long",
                "Diem",
                "longdiem0211@gmail.com",
                "0855265663",
                "222/3 Bui Dinh Tuy P12 Binh Thanh")]
        public void BookingTourInlineData(string FirstName, string LastName, string Email, string Phone, string Address)
        {
            // Step 1. Click the Tours booking function
            HomePage.ClickOnToursButton();

            // Step 2. Parser out the ListTour list and Choose the 3rd tour location
            SearchToursPage.ClickOnThirdItem();
            IWebElement TXT_BookName = browserFactory.Driver.FindElement(By.XPath("//h3[@class='title font-size-26']"));

            // Step 3. Use Assert Fluent for exact comparison
            browserFactory.AssertFluent("Day Visit of Petra from Oman", TXT_BookName.Text, "Validate item fail");

            // Step 4: Scroll down the screen
            IJavaScriptExecutor scrollInBookNow = (IJavaScriptExecutor)browserFactory.Driver;
            scrollInBookNow.ExecuteScript("scroll(0, 200);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 5. Click Book now
            TourBookingPage.ClickOnBookNow();
            string TourBookingInfomationPageURL = browserFactory.Driver.Url;

            // Step 6. Input Flight Booking Infomation and Scroll down the screen
            BookingPage.InputTourBookingInfomation(FirstName, LastName, Email, Phone, Address);
            IJavaScriptExecutor ScrollPay = (IJavaScriptExecutor)browserFactory.Driver;
            ScrollPay.ExecuteScript("scroll(0, 1100);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 7. Click BookingPage
            BookingPage.ClickOnBookingPage();
            // Pause the screen for 5 seconds
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // End Function
            browserFactory.Driver.Quit();
        }

        /// <summary>
        /// Use Json Reader for Data Driven testing
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        [Theory(DisplayName = "Testcase about JsonReader")]
        [JsonReader("data.json", "data")]
        public void BookingToursJsonReader(string FirstName, string LastName, string Email, string Phone, string Address)
        {
            // Step 1. Click the Tours booking function
            HomePage.ClickOnToursButton();

            // Step 2. Parser out the ListTour list and Choose the 3rd tour location
            SearchToursPage.ClickOnThirdItem();
            IWebElement TXT_BookName = browserFactory.Driver.FindElement(By.XPath("//h3[@class='title font-size-26']"));

            // Step 3. Use Assert Fluent for exact comparison
            browserFactory.AssertFluent("Day Visit of Petra from Oman", TXT_BookName.Text, "Validate item fail");

            // Step 4: Scroll down the screen
            IJavaScriptExecutor scrollInBookNow = (IJavaScriptExecutor)browserFactory.Driver;
            scrollInBookNow.ExecuteScript("scroll(0, 200);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 5. Click Book now
            TourBookingPage.ClickOnBookNow();
            string TourBookingInfomationPageURL = browserFactory.Driver.Url;

            // Step 6. Input Flight Booking Infomation and Scroll down the screen
            BookingPage.InputTourBookingInfomation(FirstName, LastName, Email, Phone, Address);
            IJavaScriptExecutor ScrollPay = (IJavaScriptExecutor)browserFactory.Driver;
            ScrollPay.ExecuteScript("scroll(0, 1100);");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Step 7. Click BookingPage
            BookingPage.ClickOnBookingPage();
            // Pause the screen for 5 seconds
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // End Function
            browserFactory.Driver.Quit();
        }
    }
}
