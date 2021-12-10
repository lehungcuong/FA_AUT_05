using AutomationDemo.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThaoPTT12_Final.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver Driver) : base(Driver)
        {
        }
        private IWebElement Email => Driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement PassWord => Driver.FindElement(By.XPath("//input[@id='passwd']"));
        private IWebElement ClickSignIn => Driver.FindElement(By.XPath("//button[@id='SubmitLogin']"));

        public void Login()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;

            Srollpage.ExecuteScript("window.scrollTo(0, 500)");
            Email.SendKeys("phamthanhthaobp@gmail.com");
            PassWord.SendKeys("123456");
            ClickSignIn.Click();
        }
    }
}
