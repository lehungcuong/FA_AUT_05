using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PHP_Travel_POM.Pages
{
    public class BookingPage : BasePage
    {
        public BookingPage(IWebDriver driver) : base(driver)
        {
        }

        //Element for Booking Page
        IWebElement txtFirstName => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        IWebElement txtLastName => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        IWebElement txtEmail => Driver.FindElement(By.XPath("//input[@name='email']"));
        IWebElement txtPhone => Driver.FindElement(By.XPath("//input[@name='phone']"));
        IWebElement txtAddress => Driver.FindElement(By.XPath("//input[@name='address']"));
        IWebElement txtCountry => Driver.FindElement(By.XPath("//select[@name='country_code']"));
        IWebElement txtNationality => Driver.FindElement(By.XPath("//select[@name='nationality']"));
        IWebElement btnBankTransfer => Driver.FindElement(By.XPath("//div[@class='col-md-4 mb-1 gateway_bank-transfer']/div"));
        IWebElement btnAgreTermsAndCondition => Driver.FindElement(By.XPath("//label[@for='agreechb']"));
        IWebElement btnCorfirmBooking => Driver.FindElement(By.XPath("//button[@id='booking']"));

        //Action for Booking Page
        public void InputFlightBookingInfomation()
        {
            txtFirstName.SendKeys("Long");
            txtLastName.SendKeys("Diem");
            txtEmail.SendKeys("longdiem0211@gmail.com");
            txtPhone.SendKeys("0855265663");
            txtAddress.SendKeys("222/3 Bui Dinh Tuy, p12, Binh Thanh, TpHCM");
            SelectElement selectCountry = new SelectElement(txtCountry);
            selectCountry.SelectByText("France");
            SelectElement selectNationality = new SelectElement(txtNationality);
            selectNationality.SelectByText("France");
        }

        public void InputTourBookingInfomation(string FirstName, string LastName, string Email, string Phone, string Address)
        {
            txtFirstName.SendKeys(FirstName);
            txtLastName.SendKeys(LastName);
            txtEmail.SendKeys(Email);
            txtPhone.SendKeys(Phone);
            txtAddress.SendKeys(Address);
            SelectElement selectCountry = new SelectElement(txtCountry);
            selectCountry.SelectByText("France");
            SelectElement selectNationality = new SelectElement(txtNationality);
            selectNationality.SelectByText("France");
        }

        public void ClickOnBookingPage()
        {
            btnBankTransfer.Click();
            btnAgreTermsAndCondition.Click();
            btnCorfirmBooking.Click();
        }


    }
}
