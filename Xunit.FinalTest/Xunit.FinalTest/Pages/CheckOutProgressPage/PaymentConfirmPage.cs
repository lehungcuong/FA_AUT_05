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
    public class PaymentConfirmPage : BasePage
    {
        public PaymentConfirmPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnConfirmOrder => BrowserFactory.FindElement(By.XPath("//p[@id='cart_navigation']//button[@type='submit']"));
        
        //Actions
        public OrderConfirmPage ClickOnButtonProceedCheckOut()
        {
           BrowserFactory.JsClick(btnConfirmOrder);
           return new OrderConfirmPage(Driver);
        }
    }
}
