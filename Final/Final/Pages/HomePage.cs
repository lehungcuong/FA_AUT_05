using BrowserFactory;
using OpenQA.Selenium;
using System.Drawing;
using System.Threading;

namespace Final.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        string url = "http://automationpractice.com/index.php";

        IWebElement btnAddToCart_1 => BrowsersFactory.Get("CSS:#homefeatured:first-child li:first-child a.button.ajax_add_to_cart_button.btn.btn-default");
        IWebElement btnProceedToCheckout => BrowsersFactory.Get("//a[@class='btn btn-default button button-medium']");
        public IWebElement btnMoreDetailOfProduct => BrowsersFactory.Get("CSS:#homefeatured:first-child li:nth-child(1) .button.lnk_view.btn.btn-default");
        IWebElement btnAddToWishList => BrowsersFactory.Get("Id:wishlist_button");
        IWebElement btnClose => BrowsersFactory.Get("//a[@title='Close']");
        IWebElement btnManageAccount => BrowsersFactory.Get("//a[@title='Manage my customer account']");

        public void NavigateToHomePage()
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Size = new Size(400, 600);
        }

        public void AddTheFirstProductToCart()
        {
            BrowsersFactory.ClickElement(btnAddToCart_1);
            Driver.Manage().Window.Maximize();
            Thread.Sleep(8000);
        }

        public void ProceedToCheckout()
        {
            BrowsersFactory.ClickElement(btnProceedToCheckout);
        }

        public void AddProductToWishList(IWebElement element)
        {
            Driver.Manage().Window.Size = new Size(400, 600);
            BrowsersFactory.ClickElement(element);
            Driver.Manage().Window.Maximize();
            BrowsersFactory.ClickElement(btnAddToWishList);
            Thread.Sleep(5000);
            BrowsersFactory.ClickElement(btnClose);
        }

        public void ManageAccount()
        {
            BrowsersFactory.ClickElementJSXPATH(Driver, btnManageAccount);
        }
    }
}
