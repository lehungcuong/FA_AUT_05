using OpenQA.Selenium;
using System.Threading;
using TestProject2.WebDriver.WebDriver;

namespace TestProject1.Pages

{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver drive) : base(drive)
        {
        }

        #region page element 

        private IWebElement InputMail => Driver.FindElement(By.XPath("//input[@id='email_create']"));
        private IWebElement BtCreate => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));

        #endregion

        #region page action 

        /// <summary>
        /// Navigate input Information of Register page
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public InputInformationOfRegisterPage NavigateInputInformationOfRegister(string mail)
        {
            BrowserFactory.ScrollToElement(Driver, 300);
            BrowserFactory.SendKey(InputMail, mail);
            BrowserFactory.ClickElement(BtCreate);
            Thread.Sleep(8000);
            return new InputInformationOfRegisterPage(Driver);
        }

        /// <summary>
        /// Assert go to Register page by tittle
        /// </summary>
        /// <param name="tittle"></param>
        public void AssertGoToRegisterInByTittle(string tittle)
        {
            BrowserFactory.AssertPageByTittle(Driver, tittle);
        }
        #endregion


    }
}
