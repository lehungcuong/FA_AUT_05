using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading;

namespace QuangTD20_Final.Pages
{
     class HomePage : BasePase
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
        private string Result;
        public IWebElement buttonSignin => Driver.FindElement(By.XPath("//a[@class='login']"));
        public IWebElement clickmyaccount => Driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]"));
        
        public void clickLoginpage()
        {
            
            Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            //buttonSignin.Click();
            ClassFunction.WebElementClick(buttonSignin);
        }
        public void clickLoginpagetobuy()
        {

            
            Thread.Sleep(2000);
            //buttonSignin.Click();
            ClassFunction.WebElementClick(clickmyaccount);
        }

    }
}
