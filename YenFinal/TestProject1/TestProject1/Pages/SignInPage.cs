using OpenQA.Selenium;
using TestProject2.WebDriver.WebDriver;

namespace TestProject1.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver drive) : base(drive)
        {
        }

        #region element Sign In Page 
        private IWebElement InputMail => Driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement InputPass => Driver.FindElement(By.XPath("//input[@id='passwd']"));
        private IWebElement BtnSignIn => Driver.FindElement(By.XPath("//button[@id='SubmitLogin']"));
        #endregion

        #region  action Sign In Page

        /// <summary>
        /// Navigate to My Account page
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public MyAccountPage NavigateMyAccountPage(string mail, string pass)
        {
            BrowserFactory.ScrollToElement(Driver, 300);
            BrowserFactory.SendKey(InputMail, mail);
            BrowserFactory.SendKey(InputPass, pass);
            BrowserFactory.ClickElement(BtnSignIn);
            return new MyAccountPage(Driver);
        }

        /// <summary>
        /// Assert go to Sign In page by tittle
        /// </summary>
        /// <param name="tittle"></param>
        public void AssertGoToSignInByTittle(string tittle)
        {
            BrowserFactory.AssertPageByTittle(Driver, tittle);
        }
        #endregion

    }
}
