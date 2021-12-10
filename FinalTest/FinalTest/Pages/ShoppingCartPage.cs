using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(Browser browser) : base(browser)
        {
        }

        // Get xpath of element
        IWebElement btnCheckOut => Browser.GetElement(By.XPath("//a[@href='http://automationpractice.com/index.php?controller=order&step=1']"));

        // Check if the page redirected to cart summary
        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }

        public AddressPage NavigateToAddressPage()
        {
            Browser.ScrollByJScript("scroll(0, 1200);");
            Browser.ClickToElement(btnCheckOut);
            return new AddressPage(browser);
        }
    }
}
