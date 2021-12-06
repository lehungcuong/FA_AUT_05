using OpenQA.Selenium;

namespace PHP_Travel_POM.Pages
{
    class InvoicePage : BasePage
    {
        public InvoicePage(IWebDriver driver) : base(driver)
        {
        }

        //Element for Invoice Page
        IWebElement btnProcess => Driver.FindElement(By.XPath("//input[@id='form']"));

        //Action for Invoice Page
        public void ClickOnCorfimBookingButton()
        {
            btnProcess.Click();
        }

    }
}
