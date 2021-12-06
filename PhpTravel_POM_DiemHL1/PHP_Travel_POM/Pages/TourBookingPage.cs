using OpenQA.Selenium;

namespace PHP_Travel_POM.Pages
{
    class TourBookingPage : BasePage
    {
        public TourBookingPage(IWebDriver driver) : base(driver)
        {
        }

        //Element for Tour Booking Page
        IWebElement txtBookNow => Driver.FindElement(By.XPath("//button[@type='submit']"));

        //Action for Tour Booking Page
        public void ClickOnBookNow()
        {
            txtBookNow.Click();
        }
    }
}
