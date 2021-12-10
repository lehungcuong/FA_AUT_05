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
    public class CheckOutPaymentPage : BasePage
    {
        public CheckOutPaymentPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnBankWirePayment => BrowserFactory.FindElement(By.XPath("//a[@class='bankwire']"));
        
        //Actions
        public PaymentConfirmPage ClickOnButtonProceedCheckOut()
        {
           BrowserFactory.JsClick(btnBankWirePayment);
           return new PaymentConfirmPage(Driver);
        }
    }
}
