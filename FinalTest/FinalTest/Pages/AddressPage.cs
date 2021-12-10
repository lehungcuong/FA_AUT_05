using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class AddressPage : BasePage
    {
        public AddressPage(Browser browser) : base(browser)
        {
        }
        // Get xpath of element
        IWebElement btnCheckOut => Browser.GetElement(By.XPath("//button[@name='processAddress']"));

        // Go to shipping page
        public ShippingPage NavigateToShippingPage()
        {
            Browser.ScrollByJScript("scroll(0, 1200);");
            Browser.ClickToElement(btnCheckOut);
            return new ShippingPage(browser);
        }
    }
}
