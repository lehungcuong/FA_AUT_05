using System;
using System.Threading;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class Checkoutpage_Shipping : BasePage
    {
        public Checkoutpage_Shipping(IWebDriver driver) : base(driver)
        {
        }

        IWebElement RadioTermsandCondition => Driver.FindElement(By.XPath("//div[@class='checker']"));

        IWebElement BtnProceedCheckoutShipping => Driver.FindElement(By.XPath("//button[@name='processCarrier']"));

        public void Scrolldown()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("scroll(0, 3000);");
            Thread.Sleep(5000);
        }

        public void ShippingmovetoPayment()
        {
            RadioTermsandCondition.Click();
            BtnProceedCheckoutShipping.Click();
        }

    }
}
