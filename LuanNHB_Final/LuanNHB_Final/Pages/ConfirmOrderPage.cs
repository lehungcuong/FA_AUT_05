using OpenQA.Selenium;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    public class ConfirmOrderPage : BasePage
    {
        public ConfirmOrderPage(IWebDriver driver) : base()
        {
        }
        //Element website
        IWebElement BtnConfirmOrder => BrowserFactory.SetWebElement("//p[@id='cart_navigation']//button");

        /// <summary>
        /// Click Confirm Order
        /// </summary>
        public void ConfirmOrder() => BrowserFactory.Click(BtnConfirmOrder);
    }

}
