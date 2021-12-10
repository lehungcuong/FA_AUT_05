using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    public class ProductDetailPage : BasePage
    {
        public ProductDetailPage(IWebDriver driver) : base()
        {
        }



        IWebElement BtnAddToCart => BrowserFactory.SetWebElement("//p[@id='add_to_cart']");

        IWebElement BtnCheckout => BrowserFactory.SetWebElement("//a[contains(@title,'Proceed to checkout')]");

        public void PurchasedProduct()
        {
        
            BrowserFactory.Click(BtnAddToCart);
            BrowserFactory.Click(BtnCheckout);
        }

    }
}
