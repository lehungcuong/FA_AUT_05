using OpenQA.Selenium;
using System.Threading;
using TestProject2.WebDriver.WebDriver;

namespace TestProject1.Pages
{
    public class InputInformationOfRegisterPage : BasePage
    {
        public InputInformationOfRegisterPage(IWebDriver drive) : base(drive)
        {
        }

        #region element Information of Register Page

        //Elements of the YOUR PERSONAL INFORMATION table
        private IWebElement FirstName => Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        private IWebElement LastName => Driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
        private IWebElement Email => Driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement Password => Driver.FindElement(By.XPath("//input[@id='passwd']"));

        //Elements of the YOUR ADDRESS table
        private IWebElement YourAddressFirstName => Driver.FindElement(By.XPath("//input[@id='firstname']"));
        private IWebElement YourAddressLastName => Driver.FindElement(By.XPath("//input[@id='lastname']"));
        private IWebElement Company => Driver.FindElement(By.XPath("//input[@id='company']"));
        private IWebElement Address => Driver.FindElement(By.XPath("//input[@id='address1']"));
        private IWebElement City => Driver.FindElement(By.XPath("//input[@id='city']"));
        private IWebElement State => Driver.FindElement(By.XPath("//select[@id='id_state']"));
        private IWebElement PostalCode => Driver.FindElement(By.XPath("//input[@id='postcode']"));
        private IWebElement Country => Driver.FindElement(By.XPath("//select[@id='id_country']"));
        private IWebElement MobilePhone => Driver.FindElement(By.XPath("//input[@id='phone_mobile']"));
        private IWebElement AssignAnAddress => Driver.FindElement(By.XPath("//input[@id='alias']"));
        private IWebElement ButRegister => Driver.FindElement(By.XPath("//button[@id='submitAccount']"));


        #endregion

        #region action Information of Register Page

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MyAccountPage NavigateMyAccountPage()
        {
           
            BrowserFactory.SendKey(FirstName, "Ta");
            BrowserFactory.SendKey(LastName, "tu");
            BrowserFactory.SendKey(Email, "");
            BrowserFactory.SendKey(Password, "123456");
            

            BrowserFactory.SendKey(YourAddressFirstName, "Tien");
            BrowserFactory.SendKey(YourAddressLastName, "Trương");
            BrowserFactory.SendKey(Company, "YouAre");
            BrowserFactory.SendKey(Address, "11,NanUnK");
            BrowserFactory.SendKey(City, "Anmihok");
            BrowserFactory.SelectByTexts(State, "Hawaii");
            BrowserFactory.SendKey(PostalCode, "00000");
            BrowserFactory.SelectByTexts(Country, "United States");
            BrowserFactory.SendKey(MobilePhone, "0966654453");
            BrowserFactory.SendKey(AssignAnAddress, "Misula");

            BrowserFactory.ClickElement(ButRegister);
            Thread.Sleep(4000);
            return new MyAccountPage(Driver);
        }

        /// <summary>
        /// Assert Information Of Register page by tittle
        /// </summary>
        /// <param name="tittle"></param>
        public void AssertInformationOfRegisterByTittle(string tittle)
        {
            BrowserFactory.AssertPageByTittle(Driver, tittle);
        }
        

        #endregion
    }
}
