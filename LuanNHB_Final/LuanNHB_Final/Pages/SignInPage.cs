using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    class SignInPage
    {
        public SignInPage(IWebDriver driver) : base()
        {
        }

        IWebElement TxtSignInEmail => BrowserFactory.SetWebElement("//input[@id='email']");

        IWebElement TxtSignINPassword => BrowserFactory.SetWebElement("//input[@id='passwd']");

        IWebElement BtnSignIn => BrowserFactory.SetWebElement("//button[@id='SubmitLogin']");

        IWebElement TxtRegisterEmail => BrowserFactory.SetWebElement("//input[@id='email_create']");

        IWebElement BtnRegisterAccount => BrowserFactory.SetWebElement("//button[@id='SubmitCreate']");

        public void LoginAccountPage(String Email, string password)
        {
            BrowserFactory.sendKey(TxtSignInEmail, Email);
            BrowserFactory.sendKey(TxtSignINPassword, password);
            BrowserFactory.Click(BtnSignIn);
        }

        public void ResgisterAccount(string email)
        {
            BrowserFactory.sendKey(TxtRegisterEmail, email);
            BrowserFactory.Click(BtnRegisterAccount);
        }



    }
}
