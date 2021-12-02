using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using XUnitTest_POM.Constraints;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    class ChooseTour : BasePage
    {
        public ChooseTour(IWebDriver driver) : base() { }

        #region Elements on Choose Tour page
        IList<IWebElement> TourList => BrowserFactory.FindElements("//div[@class='row padding-top-50px']//div[@class='col-lg-4']");
        IWebElement BtnTour => TourList[2];
        IWebElement TxtTourWasChosen => BrowserFactory.FindElement("//div//h3[@class='title font-size-26']");
        IWebElement BtnBookNow => BrowserFactory.FindElement("//button[@type='submit']");
        #endregion

        /// <summary>
        /// Verify Tours page title
        /// </summary>
        public static bool VerifyToursPageTitle => BrowserFactory.GetTitle().Equals("Search Tours - PHPTRAVELS");

        /// <summary>
        /// Choose third tour from Tours list
        /// </summary>
        public void ChooseThirdTour()
        {
            BrowserFactory.ClickScroll(BtnTour);
        }

        /// <summary>
        /// Verify tour was choosen
        /// </summary>
        public bool VerifyTourWasChosen => BrowserFactory.GetText(TxtTourWasChosen).Equals("Day Visit of Petra from Oman");

        /// <summary>
        /// Book tour
        /// </summary>
        public void BookTour()
        {
            BrowserFactory.ClickScroll(BtnBookNow);
        }
    }
}
