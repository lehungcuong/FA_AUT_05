using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using WebDriver;

namespace XunitPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver Driver) : base(Driver) { }

        //Elements
        private IWebElement BtnLanguage => BrowserFactory.FindElement(By.XPath("//button[@id='languages']"));
        private IWebElement SelectEnglish => BrowserFactory.FindElement(By.XPath("//a[contains(text(),'English')]"));
        private IWebElement BtnFlights => BrowserFactory.FindElement(By.XPath("//a[@href='https://phptravels.net/flights']"));
        private IWebElement BtnTour => BrowserFactory.FindElement(By.XPath("//a[@href='https://phptravels.net/tours']"));
        private IWebElement BtnViewMore => BrowserFactory.FindElement(By.XPath("//a[contains(text(),'View More')]"));
        //Actions
        public bool ValidateWebOpenSuccess()
        {
            if (driver.Url == "https://phptravels.net/")
            { return true; }
            return false;
        }

        public void SelectLanguageEnglish()
        {
            BrowserFactory.Click(BtnLanguage);
            BrowserFactory.Click(SelectEnglish);
        }

        public FlightPage NavigateToFlightPage()
        {
            BtnFlights.Click();
            return new FlightPage(driver);
        }

        public TourPage NavigateToTourPage()
        {
            BtnTour.Click();
            return new TourPage(driver);
        }

        public void MoveToElement()
        {
            BrowserFactory.Click(BtnViewMore);
        }

    }
}
