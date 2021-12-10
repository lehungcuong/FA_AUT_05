using OpenQA.Selenium;
namespace TestProject1.Pages
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
