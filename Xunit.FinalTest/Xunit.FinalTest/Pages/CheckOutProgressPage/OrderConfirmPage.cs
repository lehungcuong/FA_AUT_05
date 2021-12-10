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
    public class OrderConfirmPage : BasePage
    {
        public OrderConfirmPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement txtOrderMessage => BrowserFactory.FindElement(By.XPath("//strong[contains(text(),'Your order on My Store is complete')]"));
        
        //Actions
        public bool IsOrderSuccess() => txtOrderMessage.Text == "Your order on My Store is complete." ? true : false;
    }
}
