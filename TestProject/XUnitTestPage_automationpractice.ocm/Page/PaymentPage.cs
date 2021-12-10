using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class PaymentPage : BasePage
    {
        public PaymentPage(IWebDriver driver) : base(driver)
        {
        }
        
        public IWebElement PayByBankWire => Keyword.FindElement(By.XPath("//*[@class='bankwire']"));

        public void ClickOnPayByBankWire()
        {
            Keyword.ClickElementJS(PayByBankWire);
        }
    }
}
