using System;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        IWebElement BtnSignIn => Driver.FindElement(By.XPath("//a[@title='Log in to your customer account']"));
        public void GotoSignIn()
        {
            BtnSignIn.Click();
        }

    }
}

