using System;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }

        IWebElement InpEmail => Driver.FindElement(By.XPath("//input[@id='email_create']"));
        IWebElement BtnCreateAccount => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));

        public void SubmitCreate()
        {
            InpEmail.SendKeys("cuonglv15296@gmail.com");
            BtnCreateAccount.Click();
        }
    }   

}
