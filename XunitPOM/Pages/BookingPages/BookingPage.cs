using OpenQA.Selenium;
using System;
using System.Threading;
using WebDriver;
using XunitPOM.Utilities;

namespace XunitPOM.Pages
{
    public class BookingPage : BasePage
    {
        public BookingPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtPersonalInformationTitle => BrowserFactory.FindElement(By.XPath("//h3[contains(text(),'Your Personal')]"));
        private IWebElement TxtPersonalInformationFirstName => BrowserFactory.FindElement(By.XPath("//div[@class='form-content ']//input[@name='firstname']"));
        private IWebElement TxtPersonalInformationLastName => BrowserFactory.FindElement(By.XPath("//div[@class='form-content ']//input[@name='lastname']"));
        private IWebElement TxtPersonalInformationEmail => BrowserFactory.FindElement(By.XPath("//div[@class='form-content ']//input[@name='email']"));
        private IWebElement TxtPersonalInformationPhone => BrowserFactory.FindElement(By.XPath("//div[@class='form-content ']//input[@name='phone']"));
        private IWebElement TxtPersonalInformationAddress => BrowserFactory.FindElement(By.XPath("//div[@class='form-content ']//input[@name='address']"));
        private IWebElement TxtFirstTravellerInformationFirstName => BrowserFactory.FindElement(By.XPath("//div[@class='card-body']//input[@name='firstname_1']"));
        private IWebElement TxtFirstTravellerInformationLastName => BrowserFactory.FindElement(By.XPath("//div[@class='card-body']//input[@name='lastname_1']"));
        private IWebElement TxtSecondTravellerInformationFirstName => BrowserFactory.FindElement(By.XPath("//div[@class='card-body']//input[@name='firstname_2']"));
        private IWebElement TxtSecondTravellerInformationLastName => BrowserFactory.FindElement(By.XPath("//div[@class='card-body']//input[@name='lastname_2']"));
        private IWebElement SelectNation => BrowserFactory.FindElement(By.XPath("//select[@name='nationality_1']"));
        private IWebElement SelectMonthInDob => BrowserFactory.FindElement(By.XPath("//select[@name='dob_month_1']"));
        private IWebElement TxtTravellerInformationDayInDob => BrowserFactory.FindElement(By.XPath("//input[@name='dob_day_1']"));
        private IWebElement TxtTravellerInformationYearInDob => BrowserFactory.FindElement(By.XPath("//input[@name='dob_year_1']"));
        private IWebElement TxtTravellerInformationPassport => BrowserFactory.FindElement(By.XPath("//input[@name='passport_1']"));
        private IWebElement SelectTravellerInformationMonthOfIssuanceDate => BrowserFactory.FindElement(By.XPath("//select[@name='passport_issuance_month_1']"));
        private IWebElement TxtTravellerInformationDayOfIssuanceDate => BrowserFactory.FindElement(By.XPath("//input[@name='passport_issuance_day_1']"));
        private IWebElement TxtTravellerInformationYearOfIssuanceDate => BrowserFactory.FindElement(By.XPath("//input[@name='passport_issuance_year_1']"));
        private IWebElement SelectTravellerInformationMonthOfExpiryDate => BrowserFactory.FindElement(By.XPath("//select[@name='passport_month_1']"));
        private IWebElement TxtTravellerInformationDayOfExpiryDate => BrowserFactory.FindElement(By.XPath("//input[@name='passport_day_1']"));
        private IWebElement TxtTravellerInformationYearOfExpiryDate => BrowserFactory.FindElement(By.XPath("//input[@name='passport_year_1']"));
        private IWebElement BtnBankTransfer => BrowserFactory.FindElement(By.XPath("//div[contains(@class,'gateway_bank')]"));
        private IWebElement BtnAgreeTermOfUse => BrowserFactory.FindElement(By.XPath("//div[@class='custom-checkbox']/parent::div/parent::div/parent::div"));
        private IWebElement BtnBooking => BrowserFactory.FindElement(By.XPath("//button[@id ='booking']"));
        private IWebElement BtnCookieGotIt => BrowserFactory.FindElement(By.XPath("//button[@id='cookie_stop']"));

        // Actions
        public bool ValidateWebOpenSuccess()
        {
            if (TxtPersonalInformationTitle.Text == "Your Personal Information")
            { return true; }
            return false;
        }

        public void InputPersonalInformation(string personalfirstname, string personallastname, string email,
        string phone, string address)
        {
            BrowserFactory.setText(TxtPersonalInformationFirstName, personalfirstname);
            BrowserFactory.setText(TxtPersonalInformationLastName, personallastname);
            BrowserFactory.setText(TxtPersonalInformationEmail, email);
            BrowserFactory.setText(TxtPersonalInformationPhone, phone);
            BrowserFactory.setText(TxtPersonalInformationAddress, address);
        }

        public void InputFlightTravellersInformation()
        {
            BrowserFactory.setText(TxtFirstTravellerInformationFirstName, "Tung");
            BrowserFactory.setText(TxtFirstTravellerInformationLastName, "Son");
            BrowserFactory.select(SelectNation, SelectType.SELECT_BY_TEXT, "France");
            BrowserFactory.select(SelectMonthInDob, SelectType.SELECT_BY_VALUE, "04");
            BrowserFactory.setText(TxtTravellerInformationDayInDob, "10");
            BrowserFactory.setText(TxtTravellerInformationYearInDob, "1989");
            BrowserFactory.setText(TxtTravellerInformationPassport, "123456789");
            BrowserFactory.select(SelectTravellerInformationMonthOfIssuanceDate, SelectType.SELECT_BY_VALUE, "01");
            BrowserFactory.setText(TxtTravellerInformationDayOfIssuanceDate, "11");
            BrowserFactory.setText(TxtTravellerInformationYearOfIssuanceDate, "2000");
            BrowserFactory.select(SelectTravellerInformationMonthOfExpiryDate, SelectType.SELECT_BY_VALUE, "01");
            BrowserFactory.setText(TxtTravellerInformationDayOfExpiryDate, "11");
            BrowserFactory.setText(TxtTravellerInformationYearOfExpiryDate, "2030");
        }

        public void InputTourTravellersInformation(string firsttravellerfirstname, string firsttravellerlastname,
        string secondtravellerfirstname, string secondtravellerlastname)
        {
            BrowserFactory.setText(TxtFirstTravellerInformationFirstName, firsttravellerfirstname);
            BrowserFactory.setText(TxtFirstTravellerInformationLastName, firsttravellerlastname);
            BrowserFactory.setText(TxtSecondTravellerInformationFirstName, secondtravellerfirstname);
            BrowserFactory.setText(TxtSecondTravellerInformationLastName, secondtravellerlastname);
        }

        public void ChoosePaymentMethod()
        {
            BrowserFactory.ScrollAndClick(BtnBankTransfer);
            BrowserFactory.ScrollAndClick(BtnAgreeTermOfUse);
        }

        public void ClickOnCookieGotIt()
        {
            BrowserFactory.JsClick(BtnCookieGotIt);
        }

        public BookingInvoicePage FlightClickOnConfirmBooking()
        {
            BtnBooking.Submit();
            return new BookingInvoicePage(driver);
        }

        public ErrorPage TourClickOnConfirmBooking()
        {
            BrowserFactory.ScrollAndClick(BtnBooking);
            return new ErrorPage(driver);
        }

    }
}
