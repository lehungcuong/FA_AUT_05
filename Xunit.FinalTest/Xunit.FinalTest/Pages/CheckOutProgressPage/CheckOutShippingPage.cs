using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriver;
using Xunit.FinalTest.Pages.CheckOutProgressPage;

namespace Xunit.FinalTest.Pages
{
    public class CheckOutShippingPage : BasePage
    {
        public CheckOutShippingPage(IWebDriver driver) : base(driver) { }

        //Elements

        private IWebElement btnAcceptTermOfService => BrowserFactory.FindElement(By.XPath("//label[@for='cgv']"));
        private IWebElement btnProceedCheckOut => BrowserFactory.FindElement(By.XPath("//button[@name='processCarrier']"));
        
        //Actions
        public void ClickOnButtonAcceptTermOfService()
        {
            BrowserFactory.Click(btnAcceptTermOfService);
            Thread.Sleep(2000);
        }

        public CheckOutPaymentPage ClickOnButtonProceedCheckOut()
        {
            BrowserFactory.JsClick(btnProceedCheckOut);
            return new CheckOutPaymentPage(Driver);
        }
    }
}
