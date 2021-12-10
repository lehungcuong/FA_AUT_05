using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages.CheckOutProgressPage
{
    public class CheckOutAddressPage : BasePage
    {
        public CheckOutAddressPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnProceedCheckOut => BrowserFactory.FindElement(By.XPath("//button[@name='processAddress']"));

        //Actions
        public CheckOutShippingPage ClickOnButtonProceedCheckOut()
        {
            BrowserFactory.JsClick(btnProceedCheckOut);
            return new CheckOutShippingPage(Driver);
        }
    }
}
