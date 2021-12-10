using OpenQA.Selenium;
using System.Threading;
using TestProject2.WebDriver.WebDriver;

namespace TestProject1.Pages
{
    public class DetailPage : BasePage
    {
        public DetailPage(IWebDriver drive) : base(drive)
        {
        }
        
        #region Cart page  element 
        private IWebElement ButProceed => Driver.FindElement(By.XPath("//a[@class='btn btn-default button button-medium']"));

        #endregion

        #region Cart page action
        /// <summary>
        /// Navigate to Order Page
        /// </summary>
        /// <returns></returns>
        public OrderPage NavigateToOrderPage()
        {
            BrowserFactory.ClickElementJavaScrip(Driver, ButProceed);
            Thread.Sleep(3000);
            return new OrderPage(Driver);
        }
        #endregion

    }
}
