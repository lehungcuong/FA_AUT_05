using OpenQA.Selenium;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base()
        {
        }
        
       //Website Element
        IWebElement TxtSignInEmail => BrowserFactory.SetWebElement("//div[@id='header_logo']//img");

        /// <summary>
        /// Navigate to Home Page
        /// </summary>
        public void NavigateToHomePage() => BrowserFactory.Click(TxtSignInEmail);
    }
}
