using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    public class ShoppingCardPage : BasePage
    {
        public ShoppingCardPage(IWebDriver driver) : base()
        {
        }

        IWebElement BtnCheckOut2 => BrowserFactory.SetWebElement("//p[contains(@class,'cart_navigation')]//a[@title='Proceed to checkout']");


        public void CheckOutShoppingCard() => BrowserFactory.Click(BtnCheckOut2);


    }
}
