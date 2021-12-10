using OpenQA.Selenium;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    public class BasePage
    {
        public IWebDriver Driver;
        public BrowserFactory browserFactory;
        public BasePage()
        {
            Driver = BrowserFactory.Driver;
        }

    }
}
