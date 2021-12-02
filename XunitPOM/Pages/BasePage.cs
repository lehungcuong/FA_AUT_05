using OpenQA.Selenium;
using XunitPOM.Utilities;

namespace XunitPOM.Pages
{
    public class BasePage
    {
        public readonly IWebDriver driver;
       
        public BasePage(IWebDriver Driver)
        {
            driver = Driver;   
        }
    }
}
