using DriverFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoiDV4_Final.Page
{
    public class BlousePage : BasePage
    {
        public BlousePage(BrowserFactory browser) : base(browser)
        {
        }

        #region page elements
        private IWebElement btnAddToCart = BrowserFactory.Driver.FindElement(By.XPath("//span[normalize-space()='Add to cart']"));
        #endregion

        #region page actions
        #endregion
    }
}
