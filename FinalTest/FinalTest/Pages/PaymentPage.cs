using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class PaymentPage : BasePage
    {
        public PaymentPage(Browser browser) : base(browser)
        {
        }

        // Get xpath of Element
        IWebElement btnPayByCheck => Browser.GetElement(By.XPath("//p//a[@title='Pay by check.']"));

        // Go to Check payment page
        public CheckPaymentPage NavigateToCheckPaymentPage()
        {
            Browser.ScrollByJScript("scroll(0, 1200);");
            Browser.ClickToElement(btnPayByCheck);
            return new CheckPaymentPage(browser);
        }
    }
}
