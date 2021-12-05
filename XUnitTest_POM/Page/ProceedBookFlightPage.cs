using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    class ProceedBookFlightPage : BasePage
    {
        public ProceedBookFlightPage(IWebDriver driver) : base() { }

        #region Elements Booking Flight page
        IWebElement BtnProceed => BrowserFactory.FindElement("//input[@id='form']");
        #endregion

        /// <summary>
        /// Verify proceed booking status and payment 
        /// </summary>
        public static bool VerifyProceedPageTitle => BrowserFactory.GetTitle().Equals("Flight Invoice - PHPTRAVELS");

        /// <summary>
        /// Click on proceed to accept booking flight
        /// </summary>
        public void ClickOnProceedBtn()
        {
            BrowserFactory.ClickElement(BtnProceed);
        }

        /// <summary>
        /// Pay with transfer booking flight
        /// </summary>
        public string VerifyPayWithBankTransferTitle()
        {
            return BrowserFactory.GetTitle();
        }
    }
}
