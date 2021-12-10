using System;
using System.Threading;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class CheckoutPage_Adress : BasePage
    {
        public CheckoutPage_Adress(IWebDriver driver) : base(driver)
        {
        }

        IWebElement BtnProceedCheckout => Driver.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']"));

        public void Scrolldown()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("scroll(0, 3000);");
            Thread.Sleep(5000);
        }

        public void ProceedCheckoutAdress()
        {
            BtnProceedCheckout.Click();
        }

    }

}
