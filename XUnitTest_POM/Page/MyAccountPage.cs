using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base() { }

        IWebElement MyWishlistBtn => BrowserFactory.FindElement("//a[@title='My wishlists']");

        /// <summary>
        /// Verify My Account Page
        /// </summary>
        public bool VerifyMyAccountPage => BrowserFactory.GetTitle().Equals("My account - My Store");

        /// <summary>
        /// Click My Wishlist
        /// </summary>
        public void ClickMyWishlist()
        {
            BrowserFactory.ClickElement(MyWishlistBtn);
        }
    }
}
