using OpenQA.Selenium;
using System.Threading;

namespace Auto.Page
{
    public class ShippingPage:BasePage
    {
        public ShippingPage(IWebDriver driver) : base(driver)
        {

        }
        //element
        IWebElement btnProcessToCheckout => pageHelper.FindElement(By.XPath("//button[@name='processCarrier']/span"));

        IWebElement labelAgress => pageHelper.FindElement(By.XPath("//label[@for='cgv']"));
        IWebElement title => pageHelper.FindElement(By.XPath("//li[@class='step_current four']/span"));
        /// <summary>
        /// Click buttton Process To Checkout in Shipping Page
        /// </summary>
        public void ClickButtonProcessToCheckout()
        {
            Thread.Sleep(7000);
            pageHelper.ClickJSEL(labelAgress);
            Thread.Sleep(7000);
            pageHelper.ClickJSEL(btnProcessToCheckout);
            Thread.Sleep(4000);
        }
        public bool VerifyShippngPage()
        {
            return pageHelper.ValidateWebTitle("04. Shipping", title) ? true : false;
        }
    }
}
