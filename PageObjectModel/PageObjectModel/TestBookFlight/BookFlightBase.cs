using System;
using System.Threading;
using ConfigPOM.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectModel.TestBookFlight
{
    public class BookFlightBase
    {
        public IWebDriver driver;
        public BrowserFactory browserFactory;

        public BookFlightBase()
        {
            // driver = new ChromeDriver();
            // driver.Url = "https://phptravels.net";
            /// Browser.KeyWord();
            browserFactory = new BrowserFactory(Browser.BrowserType.Chrome);

        }
        public void Dispose()
        {
            
            driver.Quit();
        }

    }
}
