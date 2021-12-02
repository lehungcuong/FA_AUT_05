using OpenQA.Selenium;
using WebDriver;
using XunitPOM.Constants;

namespace XunitPOM.Pages
{
    public class FlightSearchPage : BasePage
    {
        public FlightSearchPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtTitleInformation => BrowserFactory.FindElement(By.CssSelector("h2.sec__title_list"));
        private IWebElement BtnFirstBookNow => BrowserFactory.FindElement(By.XPath("(//ul[@class='catalog-panel']//button)[1]"));

        // Actions
        public bool ValidateWebOpenSuccess()
        {
            if (TxtTitleInformation.Text == DataConstant.FlyingFrom + " " + DataConstant.FlyingDestination)
            { return true; }
            return false;
        }

        public BookingPage ClickOnFirstItem()
        {
            BtnFirstBookNow.Click();
            return new BookingPage(driver);
        }
    }
}
