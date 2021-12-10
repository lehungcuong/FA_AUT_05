using OpenQA.Selenium;
using POM_Driver;

namespace QuyenLLP_FinalTest.Pages
{
    public class PageBase
    {
        public readonly IWebDriver driver;

        public PageBase()
        {
            driver = BrowserFactory.driver;
        }
    }
}
