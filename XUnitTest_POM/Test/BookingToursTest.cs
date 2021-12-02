using System.Threading;
using Xunit;
using XUnitTest_POM.Constraints;
using XUnitTest_POM.Page;
using XUnitTest_POM.TestData;
using XUnitTest_POM_Webdriver;
using FluentAssertions;

namespace XUnitTest_POM.Test
{
    public class BookingToursTest : BaseTest
    {
        readonly HomePage homePage;
        readonly ChooseTour chooseTour;
        readonly BookingToursPage bookingToursPage;

        #region Constructor
        /// <summary>
        /// Constructor of Booking Tour Test
        /// </summary>
        public BookingToursTest()
        {
            homePage = new HomePage(BrowserFactory.driver);
            chooseTour = new ChooseTour(BrowserFactory.driver);
            bookingToursPage = new BookingToursPage(BrowserFactory.driver);
        }
        #endregion

        #region Common Method
        private void CommonMethod(string firstNamePersonal, string lastNamePersonal, string emailPersonal,
            string phonePersonal, string addressPersonal, string countryPersonal, string nationalityPersonal,
            string titleTravellerTour, string firstNameTravellerTour, string lastNameTravellerTour,
            string titleTravellerTour2, string firstNameTravellerTour2, string lastNameTravellerTour2)
        {
            //Assert Homepage
            homePage.VerifyHomePage.Should().BeTrue(because: "Homepage Fail");
            //Assert.True(homePage.VerifyHomePage);

            //Click on Tours page
            homePage.ClickTousrPage();

            //Assert Tours page title
            ChooseTour.VerifyToursPageTitle.Should().BeTrue(because: "Tourspage Fail");

            //Choose third tour from Tours list
            chooseTour.ChooseThirdTour();

            //Assert tour was choosen
            chooseTour.VerifyTourWasChosen.Should().BeTrue(because: "Tour was choosen Fail");

            //Book first tour
            chooseTour.BookTour();

            //Assert Tour Booking page text
            bookingToursPage.VerifyTourBookingPageText.Should().BeTrue(because: "Tour Booking page Fail");

            //Fill all personal information
            bookingToursPage.InputPersonalInformation(firstNamePersonal, lastNamePersonal, emailPersonal, phonePersonal,
                addressPersonal, countryPersonal, nationalityPersonal);

            //Fill all traveller information
            bookingToursPage.InputTravellersInformation(titleTravellerTour, firstNameTravellerTour, lastNameTravellerTour,
                titleTravellerTour2, firstNameTravellerTour2, lastNameTravellerTour2);

            //Comfirm your booking information
            bookingToursPage.ConfirmBooking();

            // Assert book tour page 
            BookingToursPage.VerifyBookTourPageTitle.Should().BeTrue(because: "Book tour page Fail");
            Thread.Sleep(1000);
        }
        #endregion 

        #region InlineData
        [Theory(DisplayName = "Booking Tour Test InlineData")]
        [InlineData("Trang", "Tran", "trangtran99@gmail.com", "097810236", "240/28 CMT8 P10 Q3",
            "Viet Nam", "Viet Nam", "Mr", "Tuan", "Hoang", "Miss", "Thu", "Nguyen")]
        [InlineData("Trang", "Tran", "trangtran99@gmail.com", "12345679", "240/28 CMT8 P10 Q3",
            "Viet Nam", "Viet Nam", "Mr", "Tuan", "Hoang", "Miss", "Thu", "Nguyen")]
        public void BookingToursInlineData(string firstNamePersonal, string lastNamePersonal, string emailPersonal,
            string phonePersonal, string addressPersonal, string countryPersonal, string nationalityPersonal,
            string titleTravellerTour, string firstNameTravellerTour, string lastNameTravellerTour,
            string titleTravellerTour2, string firstNameTravellerTour2, string lastNameTravellerTour2)
        {
            CommonMethod(firstNamePersonal, lastNamePersonal, emailPersonal, phonePersonal, addressPersonal, countryPersonal, nationalityPersonal,
                titleTravellerTour, firstNameTravellerTour, lastNameTravellerTour, titleTravellerTour2, firstNameTravellerTour2, lastNameTravellerTour2);
        }
        #endregion

        #region MemberData
        [Theory(DisplayName = "Booking Tour Test MemberData")]
        [MemberData(nameof(MemberData.data), MemberType = typeof(MemberData))]
        public void BookingToursMemberData(string firstNamePersonal, string lastNamePersonal, string emailPersonal,
            string phonePersonal, string addressPersonal, string countryPersonal, string nationalityPersonal,
            string titleTravellerTour, string firstNameTravellerTour, string lastNameTravellerTour,
            string titleTravellerTour2, string firstNameTravellerTour2, string lastNameTravellerTour2)
        {
            CommonMethod(firstNamePersonal, lastNamePersonal, emailPersonal, phonePersonal, addressPersonal, countryPersonal, nationalityPersonal,
                titleTravellerTour, firstNameTravellerTour, lastNameTravellerTour, titleTravellerTour2, firstNameTravellerTour2, lastNameTravellerTour2);
        }
        #endregion

        #region ClassData
        [Theory(DisplayName = "Booking Tour Test ClassData")]
        [ClassData(typeof(ClassData))]
        public void BookingToursClassData(string firstNamePersonal, string lastNamePersonal, string emailPersonal,
            string phonePersonal, string addressPersonal, string countryPersonal, string nationalityPersonal,
            string titleTravellerTour, string firstNameTravellerTour, string lastNameTravellerTour,
            string titleTravellerTour2, string firstNameTravellerTour2, string lastNameTravellerTour2)
        {
            CommonMethod(firstNamePersonal, lastNamePersonal, emailPersonal, phonePersonal, addressPersonal, countryPersonal, nationalityPersonal,
                titleTravellerTour, firstNameTravellerTour, lastNameTravellerTour, titleTravellerTour2, firstNameTravellerTour2, lastNameTravellerTour2);
        }
        #endregion

        #region JsonReader
        [Theory(DisplayName = "JsonReader")]
        [JsonReader(@"TestData\data.json", "Data")]
        public void BookingToursTestJsonReader(string firstNamePersonal, string lastNamePersonal, string emailPersonal,
            string phonePersonal, string addressPersonal, string countryPersonal, string nationalityPersonal,
            string titleTravellerTour, string firstNameTravellerTour, string lastNameTravellerTour,
            string titleTravellerTour2, string firstNameTravellerTour2, string lastNameTravellerTour2)
        {
            CommonMethod(firstNamePersonal, lastNamePersonal, emailPersonal, phonePersonal, addressPersonal, countryPersonal, nationalityPersonal,
                titleTravellerTour, firstNameTravellerTour, lastNameTravellerTour, titleTravellerTour2, firstNameTravellerTour2, lastNameTravellerTour2);
        }
        #endregion
    }
}
