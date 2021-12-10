using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PHP_Travel_POM.Pages;

namespace DiemHL1_FinalTest.Pages
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver)
        {
        }
        // Elements for Order Page
        IWebElement ListTour => Driver.FindElement(By.CssSelector("div.row.padding-top-50px"));
        IList<IWebElement> TourListElements => ListTour.FindElements(By.CssSelector("div.row.padding-top-50px div.col-lg-4"));
        IWebElement BtnThirdItem => TourListElements.ElementAt(2);

        // Action for order Page
        public void ClickOnThirdItem()
        {
            BtnThirdItem.Click();
        }
    }
}

