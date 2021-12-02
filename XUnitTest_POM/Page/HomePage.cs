using OpenQA.Selenium;
using XUnitTest_POM.Constraints;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class HomePage : BasePage
    {
        public HomePage (IWebDriver driver) : base() { }

        #region Elements on HomePage
        IWebElement BtnFlights => BrowserFactory.FindElement("//a[@href='https://phptravels.net/flights']");
        IWebElement BtnTours => BrowserFactory.FindElement("//a[@href='https://phptravels.net/tours']");
        #endregion

        //String Verify HomePage Title
        readonly string veryfyHomePageTitle = "PHPTRAVELS - PHPTRAVELS";

        /// <summary>
        /// Click on Flights page
        /// </summary>
        public void ClickFlightsPage() 
        {
            BtnFlights.Click();
        }

        /// <summary>
        /// Verify HomePage Title
        /// </summary>
        public bool VerifyHomePage => BrowserFactory.GetTitle().Equals(veryfyHomePageTitle);

        /// <summary>
        /// Click on Tours page
        /// </summary>
        public void ClickTousrPage() 
        {
            BrowserFactory.ClickElement(BtnTours);
        }
    }
}
