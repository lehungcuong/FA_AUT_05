using AutomationDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;

namespace ThaoPTT12_Final.Pages
{
    public class WomanPage : BasePage
    {
        public WomanPage(IWebDriver Driver) : base(Driver)
        {

        }
        private IWebDriver ChooseProduct => Driver.FindElement(By.XPath("//img[@alt='Faded Short Sleeve T-shirts']"));
        private IWebDriver BtnAddToCart => Driver.FindElement(By.XPath("//p[@id='add_to_cart']"));
        private IWebDriver BtnCheckout1 => Driver.FindElement(By.XPath("//a[@class='btn btn-default button button-medium']"));
        private IWebDriver BtnCheckout2 => Driver.FindElement(By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']"));
        private IWebDriver BtnCheckout3 => Driver.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']"));

        private IWebDriver TermsOfService => Driver.FindElement(By.XPath("//input[@id='cgv']"));
        private IWebDriver BtnCheckout4 => Driver.FindElement(By.XPath("//button[@class='button btn btn-default standard-checkout button-medium']"));

        private IWebDriver PayByCheck => Driver.FindElement(By.XPath("//a[@class='cheque']"));

        private IWebDriver BtnCheckout5 => Driver.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']"));

        /// <summary>
        /// Click Choose Product 
        /// </summary>
        public void ClickChooseProduct()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 1000)");
            Thread.Sleep(3000);
            ChooseProduct.Click();
        }

        /// <summary>
        /// CLick Add To Cart
        /// </summary>
        public void AddToCart()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 1000)");
            Thread.Sleep(3000);
            BtnAddToCart.Click();
        }

        /// <summary>
        /// Click Proceed To Checkout At stage 1. Summary
        /// </summary>
        public void ProceedToCheckout1()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 1000)");
            Thread.Sleep(3000);
            BtnCheckout1.Click();
        }

        /// <summary>
        /// Click Proceed To Checkout At stage 3. Address
        /// </summary>
        public void ProceedToCheckout2()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 1000)");
            Thread.Sleep(3000);
            BtnCheckout2.Click();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProceedToCheckout3()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 1000)");
            Thread.Sleep(3000);
            BtnCheckout3.Click();
        }

        public void ProceedToCheckout4()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 600)");
            Thread.Sleep(3000);
            TermsOfService.Click();
            BtnCheckout4.Click();
        }

        public void TickPayByCheck()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 600)");
            Thread.Sleep(3000);
            PayByCheck.Click();
        }

        public void ProceedToCheckout5()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 600)");
            Thread.Sleep(3000);
            BtnCheckout5.Click();
        }
    }
}



