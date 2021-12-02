using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PHP_Travel_POM.Pages
{
    class SearchToursPage : BasePage
    {
        public SearchToursPage(IWebDriver driver) : base(driver)
        {
        }

        //Element for Search Tour Page
        IWebElement ListTour => Driver.FindElement(By.CssSelector("div.row.padding-top-50px"));
        IList<IWebElement> TourListElements => ListTour.FindElements(By.CssSelector("div.row.padding-top-50px div.col-lg-4"));
        IWebElement BtnThirdItem => TourListElements.ElementAt(2);

        //Action for Search Tour Page
        public void ClickOnThirdItem()
        {
            BtnThirdItem.Click();
        }
    }
}
