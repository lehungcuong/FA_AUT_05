using OpenQA.Selenium;

namespace Auto.Page
{
    public class BasePage
    {
        public IWebDriver Driver;
        public PageHelper pageHelper;
        /// <summary>
        /// Constructor BasePage
        /// </summary>
        /// <param name="driver"></param>
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            pageHelper = new PageHelper(driver);

        }
    }
}
