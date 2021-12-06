using OpenQA.Selenium;
using WebDriver;
using XunitPOM.Constants;

namespace XunitPOM.Pages
{
    public class BookingInvoicePage : BasePage
    {
        public BookingInvoicePage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtAccountTitle => BrowserFactory.FindElement(By.CssSelector("h3 small"));
        private IWebElement BtnProceedCheckOut => BrowserFactory.FindElement(By.XPath("//input[@value='Proceed']"));

        // Actions
        public bool ValidateWebOpenSuccess() => TxtAccountTitle.Text == DataConstant.Firstname + " " + DataConstant.Lastname ? true : false;

        public BookingPage ClickOnProceedCheckOut()
        {
            BrowserFactory.Click(BtnProceedCheckOut);
            return new BookingPage(driver);
        }
    }
}
