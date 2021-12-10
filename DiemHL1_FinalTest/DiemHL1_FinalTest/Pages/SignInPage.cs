using System;
using System.Threading;
using OpenQA.Selenium;
using PHP_Travel_POM.Pages;

namespace DiemHL1_FinalTest.Pages
{
    class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }
        // Elements for SignInPage
        IWebElement txtEmailForRegisterAccount => Driver.FindElement(By.XPath("//input[@id='email_create']"));
        IWebElement btnCreate => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));
        IWebElement btnEmailLogin => Driver.FindElement(By.XPath("//label[@for='email']"));
        IWebElement txtEmailLogin => Driver.FindElement(By.XPath("//input[@id='email']"));
        IWebElement btnPassWordLogin => Driver.FindElement(By.XPath("//label[@for='passwd']"));
        IWebElement txtPassWordLogin => Driver.FindElement(By.XPath("///input[@id='passwd']"));
        IWebElement btnLogin => Driver.FindElement(By.XPath("//i[@class='icon-lock left']"));

        //Action for Sign In Page
        public void CreateAccount()
        {
            txtEmailForRegisterAccount.SendKeys("longdiem0211@gmail.com");
        }

        public void ClickOnCreate()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            btnCreate.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        public void CheckLogin()
        {
            btnEmailLogin.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            txtEmailLogin.SendKeys("longdiem@gmail.com");
            btnPassWordLogin.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            txtPassWordLogin.SendKeys("132456");
        }

        public void ClickOnLogin()
        {
            btnLogin.Click();
        }
    }
}
