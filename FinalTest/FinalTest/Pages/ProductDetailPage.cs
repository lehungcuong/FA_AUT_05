using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class ProductDetailPage : BasePage
    {
        public ProductDetailPage(Browser browser) : base(browser)
        {
        }

        // Get xpath of elements
        IWebElement txtQuantity => Browser.GetElement(By.XPath("//input[@id='quantity_wanted']"));
        IWebElement txtSize => Browser.GetElement(By.XPath("//select[@id='group_1']"));
        IWebElement cbxColor => Browser.GetElement(By.XPath("//a[@id='color_13']"));
        IWebElement btnAddToCart => Browser.GetElement(By.XPath("//button[@name='Submit']"));
        IWebElement btnCheckout => Browser.GetElement(By.XPath("(//a[@href='http://automationpractice.com/index.php?controller=order'])[3]"));

        // Check if the page redirected to product detail
        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }
      
        public void InputOrderInformation()
        {
            // Input quantity: 1
            Browser.EnterText(txtQuantity, "1");
            // Select size M
            Browser.SelectElement(txtSize, "M");
            // Select color orange
            Browser.ClickToElement(cbxColor);
            // Click button Add to cart
            Browser.ClickToElement(btnAddToCart);
        }   
        
        public ShoppingCartPage NavigateToShoppingCartSummary()
        {
            Browser.ClickToElement(btnCheckout);
            return new ShoppingCartPage(browser);
        }
    }
}
