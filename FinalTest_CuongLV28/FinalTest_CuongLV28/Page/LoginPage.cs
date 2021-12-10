using System;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        IWebElement EmailLogin => Driver.FindElement(By.XPath("//input[@id='email']"));
        IWebElement PasswordLogin => Driver.FindElement(By.XPath("//input[@id='passwd']"));

        public void LogIn()
        {
            EmailLogin.SendKeys("cuonglv15296@gmail.com");
            PasswordLogin.SendKeys("qqqqqq");
        }
    }
}
