using WebDriver;
using Xunit;
using XunitPOM.Pages;
using XunitPOM.TestData;
using XunitPOM.Utilities;

namespace XunitPOM.Test
{
    public class BookingTourTest : BaseTest, IClassFixture<ReportHelper>
    {
        private readonly HomePage HomePage;
        private readonly TourPage TourPage;
        private readonly TourDetailPage TourDetailPage;
        private readonly BookingPage BookingPage;
        private readonly ErrorPage ErrorPage;

        /// <summary>
        /// Init pages
        /// </summary>
        public BookingTourTest()
        {
            HomePage = new HomePage(browserFactory.driver);
            TourPage = new TourPage(browserFactory.driver);
            TourDetailPage = new TourDetailPage(browserFactory.driver);
            BookingPage = new BookingPage(browserFactory.driver);
            ErrorPage = new ErrorPage(browserFactory.driver);
        }

        [Theory(DisplayName = "Booking Tour Inline Data Test")]
        [InlineData("Dinh", "Thi", "DinhThi123@gmail.com", "0918023045", "8 King Gorden Cali", "Tung", "Son", "Son", "Tung")]
        [InlineData("Minh", "Thi", "MinhThi123@gmail.com", "0918023041", "9 King Gorden Cali", "Son", "Goku", "Goku", "Son")]
        public void BookingTourInlineData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
            firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
        }

        [Theory(DisplayName = "Booking Tour Class Data Test")]
        [ClassData(typeof(TourClassData))]
        public void BookingTourClassData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
            firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
        }

        [Theory(DisplayName = "Booking Tour Member Data Test")]
        [MemberData(nameof(TourMemberData.UserData), MemberType = typeof(TourMemberData))]
        public void BookingTourMemberData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
            firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
        }

        [Theory(DisplayName = "Booking Tour Json Data Test")]
        [JsonReader("TestData.json", "Data")]
        public void BookingTourJsonData(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Call to booking tour method
            BookingTour(personalfirstname, personallastname, email, phone, address, firsttravellerfirstname,
            firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);
        }

        public void BookingTour(string personalfirstname, string personallastname, string email,
        string phone, string address, string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            // Create new test case report
            XunitHelper.CreateTestReport();

            // Validate home page open successfully
            BrowserFactory.AssertValue(HomePage.ValidateWebOpenSuccess(), AssertType.True, "Can't load home page");

            // choose language english
            HomePage.SelectLanguageEnglish();
            HomePage.NavigateToTourPage();

            // Validate tour page open successfully
            BrowserFactory.AssertValue(TourPage.ValidateWebOpenSuccess(), AssertType.True, "Can't nagivate to tour page");

            // Get elements and click on third item
            TourPage.ClickOnThirdTour();

            // Validate tour detail page open successfully
            BrowserFactory.AssertValue(TourDetailPage.ValidateTourTitle(), AssertType.True, "Title of detail page not correct");

            // Click on button book now
            TourDetailPage.ClickOnBookNow();

            // Validate booking page open successfully
            BrowserFactory.AssertValue(BookingPage.ValidateWebOpenSuccess(), AssertType.True, "Can't nagivate to booking page");

            // Input booking information
            BookingPage.InputPersonalInformation(personalfirstname, personallastname, email, phone, address);
            BookingPage.InputTourTravellersInformation(firsttravellerfirstname, firsttravellerlastname, secondtravellerfirstname, secondtravellerlastname);

            // Choose payment method
            BookingPage.ChoosePaymentMethod();

            // Click on confirm booking
            BookingPage.TourClickOnConfirmBooking();

            // Validate check out page
            BrowserFactory.AssertValue(ErrorPage.ValidateCheckOut(), AssertType.True, "Can't nagivate to check out page");
        }
    }
}
