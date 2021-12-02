using OpenQA.Selenium;
using WebDriver;

namespace XunitPOM.Pages
{
    public class ErrorPage : BasePage
    {
        public ErrorPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtCheckOutNote => BrowserFactory.FindElement(By.XPath("//a[text()='Back to Home']"));

        // Actions
        public bool ValidateCheckOut()
        {
            if (TxtCheckOutNote.Text.Equals("Back to Home"))
            { return true; }
            return false;
        }
    }
}
