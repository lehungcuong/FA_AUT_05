using OpenQA.Selenium;

namespace PHP_Travel_POM.Pages
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
