using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(Browser browser) : base(browser)
        {

        }

        // Get xpath of elements in My account page 
        IWebElement btnMyAddresses = Browser.GetElement(By.XPath("//a[@title='Addresses']"));
        IWebElement btnHome = Browser.GetElement(By.XPath("//a[@title='Home']"));

        // Check if the page redirected to Login page
        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle("My account - My Store");
        }

        // Go to Homepage
        public void GoBackToHomePage()
        {
            Browser.ClickToElement(btnHome);
        }

        // Go to My Address page
        public MyAccountPage NavigateToMyAddressPage()
        {
            Browser.ClickToElement(btnMyAddresses);
            return new MyAccountPage(browser);
        }
    }
}
