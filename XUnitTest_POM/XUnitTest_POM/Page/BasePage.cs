using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class BasePage 
    {
        public IWebDriver Driver;
        public BasePage()
        { 
            Driver = BrowserFactory.driver;
        }
    }
}
