using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(Browser browser) : base(browser)
        {

        }

        // Get xpath of button sign in 
        IWebElement btnLogin => Browser.GetElement(By.XPath("//a[@title='Log in to your customer account']"));
        IWebElement  btnItem => Browser.GetElement(By.XPath("(//div//img[@src='http://automationpractice.com/img/p/1/1-home_default.jpg'])[1]"));

        // Check if the page redirected to Homepage
        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }

        // Add item Faded Short Sleeve T-shirts to card 
        public void SelectItem()
        {
            Browser.ClickToElement(btnItem);
        }

        // Go to login page
        public LoginPage NavigateToLoginPage()
        {
            Browser.ClickToElement(btnLogin);
            return new LoginPage(browser);
        }

    }
}
