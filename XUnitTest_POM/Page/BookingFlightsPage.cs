using OpenQA.Selenium;
using System.Threading;
using XUnitTest_POM.Constraints;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class BookingFlightsPage : BasePage
    {
        public BookingFlightsPage(IWebDriver driver) : base() { }

        #region Elements of Booking flights page
        IWebElement TxtFirstNamePersonal => BrowserFactory.FindElement("//input[@name='firstname']");
        IWebElement TxtLastNamePersonal => BrowserFactory.FindElement("//input[@name='lastname']");
        IWebElement TxtEmailPersonal => BrowserFactory.FindElement("//input[@name='email']");
        IWebElement TxtPhonePersonal => BrowserFactory.FindElement("//input[@name='phone']");
        IWebElement TxtAddressPersonal => BrowserFactory.FindElement("//input[@name='address']");
        IWebElement SelectCountryPersonal => BrowserFactory.FindElement("//select[@name='country_code']");
        IWebElement SelectNationalityPersonal => BrowserFactory.FindElement("//select[@name='nationality']");
        IWebElement SelectTitleTraveller => BrowserFactory.FindElement("//select[@name='title_1']");
        IWebElement TxtFirstNameTraveller => BrowserFactory.FindElement("//input[@name='firstname_1']");
        IWebElement TxtLastNameTraveller => BrowserFactory.FindElement("//input[@name='lastname_1']");
        IWebElement SelectNationalityTraveller => BrowserFactory.FindElement("//select[@name='nationality_1']");
        IWebElement SelectMonthOfBirthTraveller => BrowserFactory.FindElement("//select[@name='dob_month_1']");
        IWebElement TxtDayOfBirthTraveller => BrowserFactory.FindElement("//input[@name='dob_day_1']");
        IWebElement TxtYearOfBirthTraveller => BrowserFactory.FindElement("//input[@name='dob_year_1']");
        IWebElement TxtPassportTraveller => BrowserFactory.FindElement("//input[@name='passport_1']");
        IWebElement SelectPassportIssuanceMonth => BrowserFactory.FindElement("//select[@name='passport_issuance_month_1']");
        IWebElement TxtPassportIssuanceDay => BrowserFactory.FindElement("//input[@name='passport_issuance_day_1']");
        IWebElement TxtPassportIssuaceYear => BrowserFactory.FindElement("//input[@name='passport_issuance_year_1']");
        IWebElement SelectPassportExpiryMonth => BrowserFactory.FindElement("//select[@name='passport_month_1']");
        IWebElement TxtPassportExpiryDay => BrowserFactory.FindElement("//input[@name='passport_day_1']");
        IWebElement TxtPassportExpiryYear => BrowserFactory.FindElement("//input[@name='passport_year_1']");
        IWebElement RatioPaymentMethod => BrowserFactory.FindElement("//div[@class='col-md-4 mb-1 gateway_bank-transfer']/div");
        IWebElement CkeckboxTermCondition => BrowserFactory.FindElement("//div[@class='custom-checkbox']/parent::div/parent::div/parent::div");
        IWebElement BtnConfirmBooking => BrowserFactory.FindElement("//button[@id='booking']");
        #endregion

        /// <summary>
        /// Assert Flights Booking page title
        /// </summary>
        public bool VerifyFlightsBookingPageTitle = BrowserFactory.GetTitle().Equals("Flight Booking - PHPTRAVELS");

        /// <summary>
        /// Fill all personal information
        /// </summary>
        public void FillPersonalInformation()
        {
            BrowserFactory.SendKeys(TxtFirstNamePersonal, "Trang");
            BrowserFactory.SendKeys(TxtLastNamePersonal, "Tran");
            BrowserFactory.SendKeys(TxtEmailPersonal, "1507.tiendung@gmail.com");
            BrowserFactory.SendKeys(TxtPhonePersonal, "0937215969");
            BrowserFactory.SendKeys(TxtAddressPersonal, "240/28 CMT8 P10 Q3");
            BrowserFactory.SelectElementByText(SelectCountryPersonal, "Viet Nam");
            BrowserFactory.SelectElementByText(SelectNationalityPersonal, "Viet Nam");
        }

        /// <summary>
        /// Fill all traveller information
        /// </summary>
        public void FillTravellersInformation()
        {
            BrowserFactory.SelectElementByText(SelectTitleTraveller, "MISS");
            BrowserFactory.SendKeys(TxtFirstNameTraveller, "Tuan");
            BrowserFactory.SendKeys(TxtLastNameTraveller, "Hoang");
            BrowserFactory.SelectElementByText(SelectNationalityTraveller, "Viet Nam");
            BrowserFactory.SelectElementByText(SelectMonthOfBirthTraveller, "08 August");
            BrowserFactory.SendKeys(TxtDayOfBirthTraveller, "10");
            BrowserFactory.SendKeys(TxtYearOfBirthTraveller, "2000");
            BrowserFactory.SendKeys(TxtPassportTraveller, "167423365");
            BrowserFactory.SelectElementByText(SelectPassportIssuanceMonth, "10 October");
            BrowserFactory.SendKeys(TxtPassportIssuanceDay, "20");
            BrowserFactory.SendKeys(TxtPassportIssuaceYear, "2015");
            BrowserFactory.SelectElementByText(SelectPassportExpiryMonth, "05 May");
            BrowserFactory.SendKeys(TxtPassportExpiryDay, "10");
            BrowserFactory.SendKeys(TxtPassportExpiryYear, "2022");
        }

        /// <summary>
        /// Comfirm your booking information
        /// </summary>
        public void ConfirmBooking()
        {
            BrowserFactory.ClickScroll(RatioPaymentMethod);
            BrowserFactory.ClickScroll(CkeckboxTermCondition);
            BrowserFactory.ClickScroll(BtnConfirmBooking);
        }
    }
}
