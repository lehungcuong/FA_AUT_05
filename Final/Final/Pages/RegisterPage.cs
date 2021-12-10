using BrowserFactory;
using OpenQA.Selenium;
using System.Threading;

namespace Final.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        IWebElement txtCustomerFirstName => BrowsersFactory.Get("Id:customer_firstname");
        IWebElement txtCustomerLastName => BrowsersFactory.Get("Id:customer_lastname");
        IWebElement txtPassword => BrowsersFactory.Get("Id:passwd");
        IWebElement ddlDays => BrowsersFactory.Get("Id:days");
        IWebElement ddlMonths => BrowsersFactory.Get("Id:months");
        IWebElement ddlYears => BrowsersFactory.Get("Id:years");
        IWebElement txtFirstName => BrowsersFactory.Get("Id:firstname");
        IWebElement txtLastName => BrowsersFactory.Get("Id:lastname");
        IWebElement txtAddress => BrowsersFactory.Get("Id:address1");
        IWebElement txtCity => BrowsersFactory.Get("Id:city");
        IWebElement ddlState => BrowsersFactory.Get("Id:id_state");
        IWebElement txtPostCode => BrowsersFactory.Get("Id:postcode");
        IWebElement txtPhoneMobile => BrowsersFactory.Get("Id:phone_mobile");
        IWebElement btnSubmitAccount => BrowsersFactory.Get("Id:submitAccount");

        public void InputCustomerFirstName(string firstName)
        {
            BrowsersFactory.InputText(txtCustomerFirstName, firstName);
        }

        public void InputCustomerLastName(string lastName)
        {
            BrowsersFactory.InputText(txtCustomerLastName, lastName);
        }

        public void InputPassword(string password)
        {
            BrowsersFactory.InputText(txtPassword, password);
        }

        public void SelectDateOfBirth(string day, string month, string year)
        {
            BrowsersFactory.SelectElement(ddlDays, day);
            BrowsersFactory.SelectElement(ddlMonths, month);
            BrowsersFactory.SelectElement(ddlYears, year);
        }

        public void InputFirstName(string firstName)
        {
            BrowsersFactory.InputText(txtFirstName, firstName);
        }

        public void InputLastName(string lastName)
        {
            BrowsersFactory.InputText(txtLastName, lastName);
        }

        public void InputAddress(string address)
        {
            BrowsersFactory.InputText(txtAddress, address);
        }

        public void InputCity(string city)
        {
            BrowsersFactory.InputText(txtCity, city);
        }

        public void SelectStates(string state)
        {
            BrowsersFactory.SelectElement(ddlState, state);
        }

        public void InputPostCode(string postCode)
        {
            BrowsersFactory.InputText(txtPostCode, postCode);
        }

        public void InputMobilePhone(string phone)
        {
            BrowsersFactory.InputText(txtPhoneMobile, phone);
        }

        public void SubmitAccount()
        {
            BrowsersFactory.ClickElement(btnSubmitAccount);
        }
    }
}
