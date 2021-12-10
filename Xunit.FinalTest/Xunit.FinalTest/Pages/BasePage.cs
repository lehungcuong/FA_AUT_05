using OpenQA.Selenium;

namespace Xunit.FinalTest.Pages
{
    public class BasePage
    {
        public readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
