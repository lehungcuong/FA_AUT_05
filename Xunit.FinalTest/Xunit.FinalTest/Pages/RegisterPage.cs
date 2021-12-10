using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnMaleGender => BrowserFactory.FindElement(By.XPath("//input[@id='id_gender1']"));
        private IWebElement btnFemaleGender => BrowserFactory.FindElement(By.XPath("//input[@id='id_gender2']"));
        private IWebElement txtCustomerFirstName => BrowserFactory.FindElement(By.XPath("//input[@id='customer_firstname']"));
        private IWebElement txtCustomerLastName => BrowserFactory.FindElement(By.XPath("//input[@id='customer_lastname']"));
        private IWebElement txtPassWord => BrowserFactory.FindElement(By.XPath("//input[@id='passwd']"));
        private IWebElement selectorDayOfBirth => Driver.FindElement(By.XPath("//select[@id='days']"));
        private IWebElement selectorMonthOfBirth => Driver.FindElement(By.XPath("//select[@id='months']"));
        private IWebElement selectorYearOfBirth => Driver.FindElement(By.XPath("//select[@id='years']"));
        private IWebElement txtFirstAddress => BrowserFactory.FindElement(By.XPath("//input[@id='address1']"));
        private IWebElement txtCity => BrowserFactory.FindElement(By.XPath("//input[@id='city']"));
        private IWebElement selectorState => Driver.FindElement(By.XPath("//select[@id='id_state']"));
        private IWebElement txtPostalCode => BrowserFactory.FindElement(By.XPath("//input[@id='postcode']"));
        private IWebElement txtMobilePhone => BrowserFactory.FindElement(By.XPath("//input[@id='phone_mobile']"));
        private IWebElement txtAssignAddress => BrowserFactory.FindElement(By.XPath("//input[@id='alias']"));
        private IWebElement btnRegister => BrowserFactory.FindElement(By.XPath("//button[@id='submitAccount']"));
        


        //Actions
        public void EnterAccountInformation(string gender, string firstname, string lastname,
        string password, string dob, string address, string city, string state,
        string postalcode, string phone, string assignaddress)
        {
            var _split = dob.Split('/');
            if (gender == "Mr") BrowserFactory.JsClick(btnMaleGender);
            else BrowserFactory.JsClick(btnFemaleGender);
            BrowserFactory.setText(txtCustomerFirstName, firstname);
            BrowserFactory.setText(txtCustomerLastName, lastname);
            BrowserFactory.setText(txtPassWord, password);
            BrowserFactory.select(selectorDayOfBirth, DriverFactory.SelectType.SELECT_BY_VALUE, _split[0]);
            BrowserFactory.select(selectorMonthOfBirth, DriverFactory.SelectType.SELECT_BY_VALUE, _split[1]);
            BrowserFactory.select(selectorYearOfBirth, DriverFactory.SelectType.SELECT_BY_VALUE, _split[2]);
            BrowserFactory.setText(txtFirstAddress, address);
            BrowserFactory.setText(txtCity, city);
            BrowserFactory.select(selectorState, DriverFactory.SelectType.SELECT_BY_TEXT, state);
            BrowserFactory.setText(txtPostalCode, postalcode);
            BrowserFactory.setText(txtMobilePhone, phone);
            BrowserFactory.setText(txtAssignAddress, assignaddress);
        }

        public MyAccountPage ClickOnButtonRegister()
        {
            BrowserFactory.JsClick(btnRegister);
            return new MyAccountPage(Driver);
        }
    }
}
