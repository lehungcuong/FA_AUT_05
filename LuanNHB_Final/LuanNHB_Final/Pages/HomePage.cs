using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base()
        {
        }


        IWebElement BtnSignIn => BrowserFactory.SetWebElement("//a[@Class='login']");

        IList<IWebElement> BtnAddToCards => BrowserFactory.SetWebElements("//ul[@id='homefeatured']/descendant::li//a[@title='Add to cart']");

        IList<IWebElement> BtnProducts => BrowserFactory.SetWebElements("//ul[@id='homefeatured']/descendant::li//img");

        IList<IWebElement> BtnProductsDriver => Driver.FindElements(By.XPath("//ul[@id='homefeatured']/descendant::li//h5"));

        IWebElement BtnProductFirst => BtnProductsDriver.ElementAt(0);

        IWebElement BtnAddCardProductFirst => BtnAddToCards.ElementAt(0);

        IWebElement BtnProductSecond => BtnProductsDriver.ElementAt(1);

        IWebElement BtnAddProductSecond => BtnAddToCards.ElementAt(1);

        IWebElement BtnProductThird => BtnProductsDriver.ElementAt(3);

        IWebElement BtnAddProductThird => BtnAddToCards.ElementAt(3);

        IWebElement BtnContinue => BrowserFactory.SetWebElement("//div[@class='button-container']/span");

        IWebElement BtnCard => BrowserFactory.SetWebElement("//a[@title='View my shopping cart']");

        IWebElement BtnContinueShopping => BrowserFactory.SetWebElement("//span[@title='Continue shopping']");

        IWebElement BtnCheckOut => BrowserFactory.SetWebElement("//a[@title='Proceed to checkout']");

        public void AddToCardThreeProduct()
        {
            BrowserFactory.Click(BtnProductFirst);
            BrowserFactory.Click(BtnAddCardProductFirst);
            BrowserFactory.Click(BtnContinueShopping);

            BrowserFactory.Click(BtnProductSecond);
            BrowserFactory.Click(BtnAddProductSecond);
            BrowserFactory.Click(BtnContinueShopping);

            BrowserFactory.Click(BtnProductThird);
            BrowserFactory.Click(BtnAddProductThird);
            BrowserFactory.Click(BtnCheckOut);
        }

        public void NavigateToSignInPage() => BrowserFactory.Click(BtnSignIn);

        public void NavigateToProductDetail()
        {
            BrowserFactory.Click(BtnProductFirst);
            BrowserFactory.Click(BtnAddCardProductFirst);
            BrowserFactory.Click(BtnCheckOut);
        }

        //public void PurchaseProduct() => BrowserFactory.Click(BtnAddToCart);

    }
}
