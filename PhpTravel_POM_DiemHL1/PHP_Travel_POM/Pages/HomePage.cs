using OpenQA.Selenium;

namespace PHP_Travel_POM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        // Elements for Home Page
        IWebElement BtnFlights => Driver.FindElement(By.XPath("//a[contains(@href,'flight')]"));
        IWebElement BtnTours => Driver.FindElement(By.XPath("//a[contains(@href,'tours')]"));

        // Actions for Home Page
        public void ClickOnFlightButton()
        {
            BtnFlights.Click();
        }

        public void ClickOnToursButton()
        {
            BtnTours.Click();
        }
    }
}
