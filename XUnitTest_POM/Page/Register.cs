using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class Register : BasePage
    {
        public Register(IWebDriver driver) : base() { }

        IWebElement FirstNamePersonalTxt => BrowserFactory.FindElement("//input[@id='customer_firstname']");
        IWebElement LastNamePersonalTxt => BrowserFactory.FindElement("//input[@id='customer_lastname']");
        IWebElement EmailPersonalTxt => BrowserFactory.FindElement("//input[@id='email']");
        IWebElement PasswordPersonalTxt => BrowserFactory.FindElement("//input[@id='passwd']");
        IWebElement FirstNameTxt => BrowserFactory.FindElement("//input[@id='firstname']");
        IWebElement LastNameTxt => BrowserFactory.FindElement("//input[@id='lastname']");
        IWebElement AddressTxt => BrowserFactory.FindElement("//input[@id='address1']");
        IWebElement CityTxt => BrowserFactory.FindElement("//input[@id='city']");
        IWebElement StateSelect => BrowserFactory.driver.FindElement(By.XPath("//select[@id='id_state']"));
        IWebElement PostalCodeTxt => BrowserFactory.FindElement("//input[@id='postcode']");
        IWebElement MobilePhoneTxt => BrowserFactory.FindElement("//input[@id='phone_mobile']");
        IWebElement AliasTxt => BrowserFactory.FindElement("//input[@id='alias']");
        IWebElement RegisterBtn => BrowserFactory.FindElement("//button[@id='submitAccount']");
        IWebElement TxtRegister => BrowserFactory.FindElement("//h3[contains(text(),'personal information')]");

        public bool VerifyRegisterAccountPage => BrowserFactory.GetText(TxtRegister).Equals("YOUR PERSONAL INFORMATION");

        /// <summary>
        /// Input information to creat account
        /// </summary>
        /// <param name="firstNamePersonal"></param>
        /// <param name="lastNamePersonal"></param>
        /// <param name="emailPersonal"></param>
        /// <param name="passwordPersonal"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postalCode"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="alias"></param>
        public void InputInformationCreatAnAccout(string firstNamePersonal, string lastNamePersonal, string emailPersonal, string passwordPersonal, string firstName, string lastName,
            string address, string city, string state, string postalCode, string mobilePhone, string alias)
        {
            BrowserFactory.SendKeys(FirstNamePersonalTxt, firstNamePersonal);
            BrowserFactory.SendKeys(LastNamePersonalTxt, lastNamePersonal);
            BrowserFactory.SendKeys(EmailPersonalTxt, emailPersonal);
            BrowserFactory.SendKeys(PasswordPersonalTxt, passwordPersonal);
            BrowserFactory.SendKeys(FirstNameTxt, firstName);
            BrowserFactory.SendKeys(LastNameTxt, lastName);
            BrowserFactory.SendKeys(AddressTxt, address);
            BrowserFactory.SendKeys(CityTxt, city);
            BrowserFactory.SelectElementByValue(StateSelect, state);
            BrowserFactory.SendKeys(PostalCodeTxt, postalCode);
            BrowserFactory.SendKeys(MobilePhoneTxt, mobilePhone);
            BrowserFactory.SendKeys(AliasTxt, alias);
        }

        public void ClickRegisterButton()
        {
            BrowserFactory.ClickElement(RegisterBtn);
        }
    }
}
