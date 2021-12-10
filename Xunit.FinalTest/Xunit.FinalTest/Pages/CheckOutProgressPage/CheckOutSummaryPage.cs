using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;
using Xunit.FinalTest.Pages.CheckOutProgressPage;

namespace Xunit.FinalTest.Pages
{
    public class CheckOutSummaryPage : BasePage
    {
        public CheckOutSummaryPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnProceedCheckOut => BrowserFactory.FindElement(By.XPath("//p//a[@title ='Proceed to checkout']"));
        
        //Actions
        public CheckOutAddressPage ClickOnButtonProceedCheckOut()
        {
           BrowserFactory.JsClick(btnProceedCheckOut);
           return new CheckOutAddressPage(Driver);
        }
    }
}
