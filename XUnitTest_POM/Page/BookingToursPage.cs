using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    class BookingToursPage : BasePage
    {
        public BookingToursPage(IWebDriver driver) : base() { }

        #region Elements Booking Tour page
        IWebElement TxtTourBookingPage => BrowserFactory.FindElement("//h3[@class='card-title']");
        IWebElement TxtFirstNamePersonal => BrowserFactory.FindElement("//input[@name='firstname']");
        IWebElement TxtLastNamePersonal => BrowserFactory.FindElement("//input[@name='lastname']");
        IWebElement TxtEmailPersonal => BrowserFactory.FindElement("//input[@name='email']");
        IWebElement TxtPhonePersonal => BrowserFactory.FindElement("//input[@name='phone']");
        IWebElement TxtAddressPersonal => BrowserFactory.FindElement("//input[@name='address']");
        IWebElement SelectCountryPersonal => BrowserFactory.FindElement("//select[@name='country_code']");
        IWebElement SelectNationalityPersonal => BrowserFactory.FindElement("//select[@name='nationality']");
        IWebElement SelectTitleTravellerTour => BrowserFactory.FindElement("//select[@name='title_1']");
        IWebElement TxtFirstNameTravellerTour => BrowserFactory.FindElement("//input[@name='firstname_1']");
        IWebElement TxtLastNameTravellerTour => BrowserFactory.FindElement("//input[@name='lastname_1']");
        IWebElement SelectTitleTravellerTour2 => BrowserFactory.FindElement("//select[@name='title_2']");
        IWebElement TxtFirstNameTravellerTour2 => BrowserFactory.FindElement("//input[@name='firstname_2']");
        IWebElement TxtLastNameTravellerTour2 => BrowserFactory.FindElement("//input[@name='lastname_2']");
        IWebElement RatioPaymentMethod => BrowserFactory.FindElement("//div[@class='col-md-4 mb-1 gateway_bank-transfer']/div");
        IWebElement CkeckboxTermCondition => BrowserFactory.FindElement("//div[@class='custom-checkbox']/parent::div/parent::div/parent::div");
        IWebElement BtnConfirmBooking => BrowserFactory.FindElement("//button[@id='booking']");
        #endregion

        /// <summary>
        /// Verify Tour Booking page text
        /// </summary>
        public bool VerifyTourBookingPageText => BrowserFactory.GetText(TxtTourBookingPage).Equals("Day Visit of Petra from Oman");

        /// <summary>
        /// Fill all personal information
        /// </summary>
        public void InputPersonalInformation(string firstNamePersonal, string lastNamePersonal, string emailPersonal,
            string phonePersonal, string addressPersonal, string countryPersonal, string nationalityPersonal)
        {
            BrowserFactory.SendKeys(TxtFirstNamePersonal, firstNamePersonal);
            BrowserFactory.SendKeys(TxtLastNamePersonal, lastNamePersonal);
            BrowserFactory.SendKeys(TxtEmailPersonal, emailPersonal);
            BrowserFactory.SendKeys(TxtPhonePersonal, phonePersonal);
            BrowserFactory.SendKeys(TxtAddressPersonal, addressPersonal);
            BrowserFactory.SelectElementByText(SelectCountryPersonal, countryPersonal);
            BrowserFactory.SelectElementByText(SelectNationalityPersonal, nationalityPersonal);
        }

        /// <summary>
        /// Fill all traveller information
        /// </summary>
        public void InputTravellersInformation(string titleTravellerTour, string firstNameTravellerTour, string lastNameTravellerTour,
            string titleTravellerTour2, string firstNameTravellerTour2, string lastNameTravellerTour2)
        {
            BrowserFactory.SelectElementByValue(SelectTitleTravellerTour, titleTravellerTour);
            BrowserFactory.SendKeys(TxtFirstNameTravellerTour, firstNameTravellerTour);
            BrowserFactory.SendKeys(TxtLastNameTravellerTour, lastNameTravellerTour);
            BrowserFactory.SelectElementByValue(SelectTitleTravellerTour2, titleTravellerTour2);
            BrowserFactory.SendKeys(TxtFirstNameTravellerTour2, firstNameTravellerTour2);
            BrowserFactory.SendKeys(TxtLastNameTravellerTour2, lastNameTravellerTour2);
        }

        /// <summary>
        /// Comfirm your booking information
        /// </summary>
        public void ConfirmBooking()
        {
            BrowserFactory.ClickElement(RatioPaymentMethod);
            BrowserFactory.ClickElement(CkeckboxTermCondition);
            BrowserFactory.ClickElement(BtnConfirmBooking);
        }

        /// <summary>
        /// Verify book tour page 
        /// </summary>
        public static bool VerifyBookTourPageTitle => BrowserFactory.GetTitle().Equals("PHPTRAVELS - PHPTRAVELS");
    }
}
