using OpenQA.Selenium;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class ProductDetailPage : BasePage
    {
        public ProductDetailPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnAddToCart => BrowserFactory.FindElement(By.XPath("//p[@id='add_to_cart']/button"));
        private IWebElement iconAddToCartSuccess => BrowserFactory.FindElement(By.XPath("//i[@class='icon-ok']"));
        private IWebElement btnCountinueShopping => BrowserFactory.FindElement(By.XPath("//span[contains(@class,'continue')]/span"));
        private IWebElement btnProceedToCheckOut => BrowserFactory.FindElement(By.XPath("//a[@title='Proceed to checkout']"));
        private IWebElement btnDresses => BrowserFactory.FindElement(By.XPath("(//ul/li/a[@title='Dresses'])[2]"));
        private IWebElement btnAddToWishList => BrowserFactory.FindElement(By.XPath("//a[@id='wishlist_button']"));
        private IWebElement txtWishListMessage => BrowserFactory.FindElement(By.XPath("//p[@class='fancybox-error']"));
        private IWebElement txtProductQuantity => BrowserFactory.FindElement(By.XPath("//input[@name='qty']"));


        //Actions
        public void EnterNegativeQuantity()
        {
            BrowserFactory.setText(txtProductQuantity, "-1");
        }

        public void ClickOnAddToCart()
        {
            BrowserFactory.JsClick(btnAddToCart);
        }

        public bool IsAddToCartSuccess() => iconAddToCartSuccess.Displayed ? true : false;

        public void ClickOnButtonCountinueShopping()
        {
            BrowserFactory.JsClick(btnCountinueShopping);
        }
        
        public CheckOutSummaryPage ClickOnButtonProceedToCheckOut()
        {
            BrowserFactory.JsClick(btnProceedToCheckOut);
            return new CheckOutSummaryPage(Driver);
        }

        public DressesCategoryPage NavigateToDressesCategoryPage()
        {
            BrowserFactory.JsClick(btnDresses);
            return new DressesCategoryPage(Driver);
        }

        public void ClickOnAddToWishListButton()
        {
            BrowserFactory.JsClick(btnAddToWishList);
        }

        public bool IsAddToWishlistSuccess() => txtWishListMessage.Text == "Added to your wishlist." ? true : false;
    }
}
