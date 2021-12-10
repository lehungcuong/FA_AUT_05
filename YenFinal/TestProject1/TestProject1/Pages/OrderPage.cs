using OpenQA.Selenium;
using System.Threading;
using TestProject2.WebDriver.WebDriver;

namespace TestProject1.Pages
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver drive) : base(drive)
        {
        }

        #region element Order Page
        private IWebElement ButProceed => Driver.FindElement(By.XPath("//a[@href='http://automationpractice.com/index.php?controller=order&step=1']"));
        #endregion

        #region Order Page

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AddressOrderPage NavigateToAddressOrderPage()
        {
            BrowserFactory.ScrollToElement(Driver, 700);
            BrowserFactory.ClickElementJavaScrip(Driver, ButProceed);
            Thread.Sleep(3000);
            return new AddressOrderPage(Driver);
        }
            public void AssertGoToAddressOderInByTittle(string tittle)
            {
                BrowserFactory.AssertPageByTittle(Driver, tittle);
            }
            #endregion
        }
    }

