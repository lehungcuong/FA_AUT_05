using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTest_CuongLV28.Test
{

    public class BaseTest
    {
       public IWebDriver driver ;
        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Url = "http://automationpractice.com/index.php";
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
