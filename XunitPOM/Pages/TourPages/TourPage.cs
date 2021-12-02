using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebDriver;

namespace XunitPOM.Pages
{
    public class TourPage : BasePage
    {
        public TourPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtSearchTourTitle => BrowserFactory.FindElement(By.XPath("//h2[contains(text(),'FIND BEST')]"));
        private IWebElement ListTour => BrowserFactory.FindElement(By.CssSelector("div.row.padding-top-50px"));
        private IList<IWebElement> TourListElement => ListTour.FindElements(By.CssSelector("div.row.padding-top-50px div.col-lg-4"));
        private IWebElement BtnThirdItem => TourListElement.ElementAt(2);

        // Actions
        public bool ValidateWebOpenSuccess()
        {
            if (TxtSearchTourTitle.Text == "FIND BEST TOURS PACKAGES TODAY")
            { return true; }
            return false;
        }

        public FlightSearchPage ClickOnThirdTour()
        {
            BtnThirdItem.Click();
            return new FlightSearchPage(driver);
        }

    }
}
