using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    class ShippingPage : BasePage
    {
        public ShippingPage(IWebDriver driver) : base()
        {
        }

        IWebElement BtnCheckOut => BrowserFactory.SetWebElement("//button[contains(@name,'processCarrier')]");

        IWebElement ChkBoxTermsService => BrowserFactory.SetWebElement("//p[contains(@Class,'checkbox')]//label");

        public void CheckOutShippingPage()
        {
            BrowserFactory.Click(ChkBoxTermsService);

            BrowserFactory.Click(BtnCheckOut);
        }
    }
}
