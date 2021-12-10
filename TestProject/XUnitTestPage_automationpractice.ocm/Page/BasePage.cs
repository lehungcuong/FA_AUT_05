using OpenQA.Selenium;
using XUnitTestPage_automationpractice.com.Utilities;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class BasePage
    {
        public readonly IWebDriver Driver;
        public static WebKeyword Keyword;

        /// <summary>
        /// class keyword installed
        /// </summary>
        /// <param name="driver"></param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Keyword = new WebKeyword(Driver);
        }
    }
}
