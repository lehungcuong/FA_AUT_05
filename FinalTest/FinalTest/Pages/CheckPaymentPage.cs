using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class CheckPaymentPage : BasePage
    {
        public CheckPaymentPage(Browser browser) : base(browser)
        {
        }

        // Get xpath of element
        IWebElement btnConfirm => Browser.GetElement(By.XPath("//p//button[@type='submit']"));

        // Go to order confirmation page
        public OrderConfirmationPage NavigateToOrderConfirmationPage()
        {
            Browser.ScrollByJScript("scroll(0, 1200);");
            Browser.ClickToElement(btnConfirm);
            return new OrderConfirmationPage(browser);
        }
    }
}
