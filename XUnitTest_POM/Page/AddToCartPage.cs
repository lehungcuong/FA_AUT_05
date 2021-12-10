using OpenQA.Selenium;
using System.Threading;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class AddToCartPage : BasePage
    {
        public AddToCartPage(IWebDriver driver) : base() { }

        IWebElement AddToCartBtn => BrowserFactory.FindElement("//button[@name='Submit']");
        IWebElement ProceedToCheckoutBtn => BrowserFactory.FindElement("//a[contains(@title,'checkout')]");
        IWebElement TxtSuccessCheckout => BrowserFactory.FindElement("//div[@id='layer_cart']//h2");
        IWebElement AddWishlistBtn => BrowserFactory.FindElement("//a[@id='wishlist_button']");
        IWebElement QuantityTxt => BrowserFactory.FindElement("//input[@id='quantity_wanted']");
        IWebElement ContinueShopping => BrowserFactory.FindElement("//span[contains(@class,'continue')]");

        /// <summary>
        /// Click on Add To Cart
        /// </summary>
        public void ClickAddToCart()
        {
            BrowserFactory.ClickElement(AddToCartBtn);
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Verify Checkout Page
        /// </summary>
        public bool VerifyCheckoutPage => BrowserFactory.GetText(TxtSuccessCheckout).Equals("Product successfully added to your shopping cart");

        /// <summary>
        /// Click on Checkout Button
        /// </summary>
        public void ClickCheckout()
        {
            BrowserFactory.ClickElement(ProceedToCheckoutBtn);
        }

        /// <summary>
        /// Click on Add to Wishlist 
        /// </summary>
        public void ClickAddToWishlist()
        {
            BrowserFactory.ClickElement(AddWishlistBtn);
        }

        public void InputNegativeQuantity()
        {
            BrowserFactory.SendKeys(QuantityTxt, "-1");
        }

        /// <summary>
        /// Click on Continue Shopping button
        /// </summary>
        public void ClickContinueShopping()
        {
            BrowserFactory.ClickElement(ContinueShopping);
            Thread.Sleep(5000);
        }
    }
}
