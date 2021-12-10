using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class ShippingPage : BasePage
    {
        public ShippingPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement CbxAgreement => Keyword.FindElement(By.XPath("//*[@id='cgv']"));
        public IWebElement Btn_ProceedToCheckout => Keyword.FindElement(By.XPath("//*[@class='button btn btn-default standard-checkout button-medium']"));

        public void CheckTermAndClickToProceed()
        {
            Keyword.ClickElementJS(CbxAgreement);
            Keyword.Click(Btn_ProceedToCheckout);
        }
    }
}
