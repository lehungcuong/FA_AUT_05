using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement txtCreateEmail => BrowserFactory.FindElement(By.XPath("//input[@id='email_create']"));
        private IWebElement btnCreateAccount => BrowserFactory.FindElement(By.XPath("//button[@id='SubmitCreate']"));
        private IWebElement txtLoginEmail => BrowserFactory.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement txtLoginPassword => BrowserFactory.FindElement(By.XPath("//input[@id='passwd']"));
        private IWebElement btnSignin => BrowserFactory.FindElement(By.XPath("//button[@id='SubmitLogin']"));

        //Actions
        public RegisterPage EnterEmailAndCreateNewAccount(string email)
        {
            BrowserFactory.setText(txtCreateEmail, email);
            BrowserFactory.JsClick(btnCreateAccount);
            return new RegisterPage(Driver);
        }

        public MyAccountPage LoginWithValidAccount(string email, string password)
        {
            BrowserFactory.setText(txtLoginEmail, email);
            BrowserFactory.setText(txtLoginPassword, password);
            BrowserFactory.JsClick(btnSignin);
            return new MyAccountPage(Driver);
        }
    }
}
