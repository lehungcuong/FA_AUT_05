using OpenQA.Selenium;
using WebDriver;
using XunitPOM.Constants;

namespace XunitPOM.Pages
{
    public class TourDetailPage : BasePage
    {
        public TourDetailPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement BtnBookNow => BrowserFactory.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement TxtTitleDayVisitOfPetraFromOman => BrowserFactory.FindElement(By.XPath("//h3[contains(text(),'Day Visit of Petra from Oman')]"));

        // Actions
        public bool ValidateTourTitle()
        {
            if (TxtTitleDayVisitOfPetraFromOman.Text == DataConstant.TourTitle)
            { return true; }
            return false;
        }

        public FlightSearchPage ClickOnBookNow()
        {
            BrowserFactory.Click(BtnBookNow);
            return new FlightSearchPage(driver);
        }

    }
}
