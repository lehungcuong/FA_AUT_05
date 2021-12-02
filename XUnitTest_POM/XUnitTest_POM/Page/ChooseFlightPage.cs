using OpenQA.Selenium;
using XUnitTest_POM.Constraints;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    class ChooseFlightPage : BasePage
    {
        public ChooseFlightPage(IWebDriver driver) : base() { }

        #region Elements Flight page
        IWebElement TxtFlightWasChosen => BrowserFactory.FindElement("//h2[@class='sec__title_list']");
        IWebElement BtnBookATrip => BrowserFactory.FindElement("(//div[contains(@class,'item-book')]//button)[1]");
        #endregion

        //Flight Was Choosen
        readonly string flightWasChoosen = "DUB LCG";

        /// <summary>
        /// Verify flight was choosen
        /// </summary>
        public bool VerifyFlightWasChoosen => BrowserFactory.GetText(TxtFlightWasChosen).Equals(flightWasChoosen);

        /// <summary>
        /// Book first trip
        /// </summary>
        public void BookATrip()
        {
            BrowserFactory.ClickElement(BtnBookATrip);
        }
    }
}
