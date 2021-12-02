using OpenQA.Selenium;
using Project1.WebDriver;

namespace DemoPOM.Pages
{
    public class ConfirmBookingPage : BasePage
    {
        public ConfirmBookingPage(Browser browser) : base(browser)
        {

        }

        //Enter the personal infomation
        IWebElement TxtFirstName => Browser.GetElement(By.XPath("//input[@name='firstname']"));
        IWebElement TxtLastName => Browser.GetElement(By.XPath("//input[@name='lastname']"));
        IWebElement TxtEmail => Browser.GetElement(By.XPath("//input[@name='email']"));
        IWebElement TxtAddress => Browser.GetElement(By.XPath("//input[@name='address']"));
        IWebElement TxtTelephone => Browser.GetElement(By.XPath("//input[@name='phone']"));
        IWebElement TxtCountry => Browser.GetElement(By.XPath("//div//select[@name='country_code']"));
        IWebElement TxtNationality => Browser.GetElement(By.XPath("//select[@name='nationality']"));
        //Enter Travellers Information
        IWebElement TxtTitle => Browser.GetElement(By.XPath("//select[@name='title_1']"));
        IWebElement TxtFirstNameTraveller => Browser.GetElement(By.XPath("//input[@name='firstname_1']"));
        IWebElement TxtLastNameTraveller => Browser.GetElement(By.XPath("//input[@name='lastname_1']"));
        IWebElement TxtNationalityTraveller => Browser.GetElement(By.XPath("//select[@name='nationality_1']"));
        IWebElement TxtDateOfBithTraveller => Browser.GetElement(By.XPath("//select[@name='dob_month_1']"));
        IWebElement TxtMonthOfBirthTraveller => Browser.GetElement(By.XPath("//input[@name='dob_day_1']"));
        IWebElement TxtYearOfBirthTraveller => Browser.GetElement(By.XPath("//input[@name='dob_year_1']"));
        IWebElement TxtPassportTraveller => Browser.GetElement(By.XPath("//input[@name='passport_1']"));
        IWebElement TxtIssuanceMonth => Browser.GetElement(By.XPath("//select[@name='passport_issuance_month_1']"));
        IWebElement TxtIssuanceDay => Browser.GetElement(By.XPath("//input[@name='passport_issuance_day_1']"));
        IWebElement TxtIssuanceYear => Browser.GetElement(By.XPath("//input[@name='passport_issuance_year_1']"));
        IWebElement TxtExpireMonth => Browser.GetElement(By.XPath("//select[@name='passport_month_1']"));
        IWebElement TxtExpireYear => Browser.GetElement(By.XPath("//input[@name='passport_year_1']"));
        IWebElement TxtExpireDay => Browser.GetElement(By.XPath("//input[@name='passport_day_1']"));
        //Payment element and  confirm booking element
        IWebElement BtnPayLater => Browser.GetElement(By.XPath("//div/div/input[@id='gateway_pay-later']"));
        IWebElement BtnAgree => Browser.GetElement(By.XPath("//label[@for='agreechb']"));
        IWebElement BtnConfirm => Browser.GetElement(By.XPath("//button[@id='booking']"));

        IWebElement confirmBookingPageTitle => Browser.GetElement(By.XPath(""));

        public void NavigatePageSuccess(string pageTitle, IWebDriver driver)
        {
            Browser.ValidateWebTitle(pageTitle, driver);
        }

        public bool NavigatePageSuccess()
        {
            return Browser.ValidateWebTitle("Flight Booking - PHPTRAVELS", );
        }

        public void InputUserInformation()
        {
            Browser.EnterText(TxtFirstName, "Harley");
            Browser.EnterText(TxtLastName, "Quiin");
            Browser.EnterText(TxtEmail, "harley111@email.com");
            Browser.EnterText(TxtAddress, "33B Barker");
            Browser.EnterText(TxtTelephone, "1234567890");
            Browser.SelectElement(TxtCountry, "IN");
            Browser.SelectElement(TxtNationality, "IN");
        }

        public void InputTravellerInformation()
        {
            Browser.SelectElement(TxtTitle, "MR");
            Browser.EnterText(TxtFirstNameTraveller, "Harley");
            Browser.EnterText(TxtLastNameTraveller, "Quiin");
            Browser.SelectElement(TxtNationality, "IN");
            Browser.SelectElement(TxtDateOfBithTraveller, "10");
            Browser.EnterText(TxtMonthOfBirthTraveller, "11");
            Browser.EnterText(TxtYearOfBirthTraveller, "1999");
            Browser.EnterText(TxtPassportTraveller, "11101999");
            Browser.SelectElement(TxtIssuanceMonth, "10");
            Browser.EnterText(TxtIssuanceDay, "09");
            Browser.EnterText(TxtIssuanceYear, "2022");
            Browser.SelectElement(TxtExpireMonth, "12");
            Browser.EnterText(TxtExpireDay, "06");
            Browser.EnterText(TxtExpireYear, "2022");
        }

        public void PaymentConfirm()
        {
            Browser.ScrollByJScript("scroll(0, 1200);");
            Browser.ClickToElement(BtnPayLater);
        }

        public void ClickToTermAndConditionButton()
        {
            Browser.ClickToElement(BtnAgree);
        }

        public BookingSuccessPage NavigateToBookingSuccessPage()
        {
            Browser.ClickToElement(BtnConfirm);
            return new BookingSuccessPage(browser);
        }

    }
}
