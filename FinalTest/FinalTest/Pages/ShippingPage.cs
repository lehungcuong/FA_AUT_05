using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class ShippingPage : BasePage
    {
        public ShippingPage(Browser browser) : base(browser)
        {
        }

        // Get xpath of elements
        IWebElement cbxTermOfService => Browser.GetElement(By.XPath("//input[@id='cgv']"));
        IWebElement btnCheckOut => Browser.GetElement(By.XPath("//button[@name='processCarrier']"));

        public void ClickToTermOfServiveButton()
        {
            Browser.ScrollByJScript("scroll(0, 1200);");
            Browser.ClickToElement(cbxTermOfService);
        }

        // Go to PaymentPage
        public PaymentPage NavigateToPaymentPage()
        {
            Browser.ClickToElement(btnCheckOut);
            return new PaymentPage(browser);
        }

    }
}
