using System;
using System.Threading;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class ShoppingCartSummary : BasePage
    {
        public ShoppingCartSummary(IWebDriver driver) : base(driver)
        {
        }
        IWebElement BtnProceedtoCheckout => Driver.FindElement(By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']"));



        public void Scrolldown()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("scroll(0, 3000);");
            Thread.Sleep(5000);
        }

        public void ProceedtoCheckout()
        {
            BtnProceedtoCheckout.Click();
        }
    }
}
