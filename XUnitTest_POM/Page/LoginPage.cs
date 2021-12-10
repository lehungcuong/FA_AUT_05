using OpenQA.Selenium;
using System;
using System.Threading;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base() { }

        #region Elements on HomePage
        IWebElement EmailLoginTxt => BrowserFactory.FindElement("//input[@id='email']");
        IWebElement PasswordLoginTxt => BrowserFactory.FindElement("//input[@id='passwd']");
        IWebElement LoginBtn => BrowserFactory.FindElement("//button[@id='SubmitLogin']");
        IWebElement EmailRegisterTxt => BrowserFactory.FindElement("//input[@id='email_create']");
        IWebElement CreatAnAccountBtn => BrowserFactory.FindElement("//button[@id='SubmitCreate']");
        #endregion

        /// <summary>
        /// Verify Login Page
        /// </summary>
        public bool VerifyLoginPage => BrowserFactory.GetTitle().Equals("Login - My Store");

        /// <summary>
        /// Input Account to Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void InputAccountLogin(string email, string password)
        {
            BrowserFactory.SendKeys(EmailLoginTxt, email);
            BrowserFactory.SendKeys(PasswordLoginTxt, password);
        }

        /// <summary>
        /// Click Sign in Account
        /// </summary>
        public void ClickSignIn()
        {
            BrowserFactory.ClickElement(LoginBtn);
        }

        /// <summary>
        /// Input Email
        /// </summary>
        public void InputEmail()
        {
            Random _r = new Random();
            int n = _r.Next();
            BrowserFactory.SendKeys(EmailRegisterTxt, $"trangtran4t{n}@gmail.com");
        }

        /// <summary>
        /// Click on to Creat Account Button
        /// </summary>
        public void ClickCreatAnAccount()
        {
            BrowserFactory.ClickElement(CreatAnAccountBtn);
            Thread.Sleep(5000);
        }
    }
}
