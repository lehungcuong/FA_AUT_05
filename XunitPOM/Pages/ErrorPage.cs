using OpenQA.Selenium;
using WebDriver;

namespace XunitPOM.Pages
{
    public class BankTransferPage : BasePage
    {
        public BankTransferPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtCheckOutNote => BrowserFactory.FindElement(By.XPath("//small[contains(text(),'Once payment')]"));

        // Actions
        public bool ValidateCheckOut()
        {
            if (TxtCheckOutNote.Text.Equals("Once payment is transfered please contact us to confirm your payment"))
            { return true; }
            return false;
        }
    }
}
