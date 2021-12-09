using AventStack.ExtentReports;
using System;
using WebDriver;
using Xunit;
using Xunit.Abstractions;
using XunitPOM.Pages;
using XunitPOM.TestData;
using XunitPOM.Utilities;

namespace XunitPOM.Test
{
    [Collection("Test Collection")]
    public class BookingTourTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly TourPage TourPage;
        private readonly TourDetailPage TourDetailPage;
        private readonly BookingPage BookingPage;
        private readonly ErrorPage ErrorPage;

        /// <summary>
        /// Init pages
        /// </summary>
        public BookingTourTest(ITestOutputHelper output) : base(output)
        {
            homePage = new HomePage(BrowserFactory.driver);
            TourPage = new TourPage(BrowserFactory.driver);
            TourDetailPage = new TourDetailPage(BrowserFactory.driver);
            BookingPage = new BookingPage(BrowserFactory.driver);
            ErrorPage = new ErrorPage(BrowserFactory.driver);
        }

        [Theory(DisplayName = "Booking Tour Inline Data Test")]
        [InlineData("Dinh", "Thi", "DinhThi123@gmail.com", "0918023045", "8 King Gorden Cali", "Tung", "Son", "Son", "Tung")]
        [InlineData("Minh", "Thi", "MinhThi123@gmail.com", "0918023041", "9 King Gorden Cali", "Son", "Goku", "Goku", "Son")]
        public void BookingTourInlineData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
               BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
               firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
            });
        }

        [Theory(DisplayName = "Booking Tour Class Data Test")]
        [ClassData(typeof(TourClassData))]
        public void BookingTourClassData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
                firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
            });
        }

        [Theory(DisplayName = "Booking Tour Member Data Test")]
        [MemberData(nameof(TourMemberData.UserData), MemberType = typeof(TourMemberData))]
        public void BookingTourMemberData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
                firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
            });
        }

        [Theory(DisplayName = "Booking Tour Json Data Test")]
        [JsonReader("TestData.json", "Data")]
        public void BookingTourJsonData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
                firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
            });
        }

        public void BookingTour(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Validate home page open successfully
            BrowserFactory.AssertValueBool(homePage.ValidateWebOpenSuccess(), AssertType.True, "Can't load home page", "Home page loaded successfully");

            // choose language english
            homePage.SelectLanguageEnglish();
            homePage.NavigateToTourPage();

            // Validate tour page open successfully
            BrowserFactory.AssertValueBool(TourPage.ValidateWebOpenSuccess(), AssertType.True, "Can't nagivate to tour page", "Navigate to tour page successfully");

            // Get elements and click on third item
            TourPage.ClickOnThirdTour();

            // Validate tour detail page open successfully
            BrowserFactory.AssertValueBool(TourDetailPage.ValidateTourTitle(), AssertType.True, "Title of detail page not correct", "Navigate to tour detail page successfully");

            // Click on button book now
            TourDetailPage.ClickOnBookNow();

            // Validate booking page open successfully
            BrowserFactory.AssertValueBool(BookingPage.ValidateWebOpenSuccess(), AssertType.True, "Can't nagivate to booking page", "Navigate to booking page successfully");

            // Input booking information
            BookingPage.InputPersonalInformation(personalfirstname, personallastname, email, phone, address);
            BookingPage.InputTourTravellersInformation(firsttravellerfirstname, firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);

            BookingPage.ClickOnCookieGotIt();

            // Choose payment method
            BookingPage.ChoosePaymentMethod();

            // Click on confirm booking
            BookingPage.TourClickOnConfirmBooking();

            // Validate check out page
            BrowserFactory.AssertValueBool(ErrorPage.ValidateCheckOut(), AssertType.True, "Can't nagivate to check out page", "Checkout successfully");
        }
    }
}
