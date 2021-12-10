using OpenQA.Selenium;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    class RegisterAccountPage :BasePage
    {
        public RegisterAccountPage(IWebDriver driver) : base()
        {
        }

        #region Website Element

        IWebElement RadGenderMr => BrowserFactory.SetWebElement("//input[@Id='id_gender1']");

        IWebElement RadGenderMs => BrowserFactory.SetWebElement("//input[@Id='id_gender2']");

        IWebElement TxtFirstName => BrowserFactory.SetWebElement("//input[@Id='customer_firstname']");

        IWebElement TxtLastName => BrowserFactory.SetWebElement("//input[@Id='customer_lastname']");

        IWebElement TxtEmail => BrowserFactory.SetWebElement("//input[@Id='email']");

        IWebElement TxtPassword => BrowserFactory.SetWebElement("//input[@Id='passwd']");

        IWebElement TxtDay => Driver.FindElement(By.XPath("//select[@Id='days']"));

        IWebElement TxtMonth => Driver.FindElement(By.XPath("//select[@Id='months']"));
        
        IWebElement TxtYear => Driver.FindElement(By.XPath("//select[@Id='years']"));

        IWebElement TxtCompany => BrowserFactory.SetWebElement("//input[@Id='company']");

        IWebElement TxtAddress1 => BrowserFactory.SetWebElement("//input[@Id='address1']");

        IWebElement TxtCity => BrowserFactory.SetWebElement("//input[@Id='city']");

        IWebElement TxtState => Driver.FindElement(By.XPath("//select[@Id='id_state']"));

        IWebElement TxtPostCode => BrowserFactory.SetWebElement("//input[@Id='postcode']");

        IWebElement TxtCountry => BrowserFactory.SetWebElement("//select[@Id='id_country']");

        IWebElement TxtMobilePhone => BrowserFactory.SetWebElement("//input[@Id='phone_mobile']");

        IWebElement BtnSubmitAccount => BrowserFactory.SetWebElement("//button[@Id='submitAccount']");
        #endregion

        public void RegisterAccoutData(
            string firstName,
            string lastName,
            string email,
            string password,
            string birthDay,
            string birthMonth,
            string birthYear,
            string companyName,
            string address,
            string city,
            string state,
            string postCode,
            string country,
            string mobilePhone
            ) 
        {
            BrowserFactory.sendKey(TxtFirstName, firstName);
            BrowserFactory.sendKey(TxtLastName, lastName);
            BrowserFactory.sendKey(TxtEmail, email);
            BrowserFactory.sendKey(TxtPassword, password);
            BrowserFactory.Select(TxtDay,"Value", birthDay);

            BrowserFactory.Select(TxtMonth,"Value", birthMonth);
            BrowserFactory.Select(TxtYear,"Value", birthYear);
            BrowserFactory.sendKey(TxtCompany, companyName);
            BrowserFactory.sendKey(TxtAddress1, address);
            BrowserFactory.sendKey(TxtCity, city);
            BrowserFactory.Select(TxtState, "Value", state);
            BrowserFactory.sendKey(TxtPostCode, postCode);
            BrowserFactory.Select(TxtCountry, "Value", country);
            BrowserFactory.sendKey(TxtMobilePhone, mobilePhone);
            BrowserFactory.Click(BtnSubmitAccount);
        }



    }
}
