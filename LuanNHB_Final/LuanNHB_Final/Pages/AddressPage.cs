using OpenQA.Selenium;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    public class AddressPage : BasePage
    {
        public AddressPage(IWebDriver driver) : base()
        {
        }

        IWebElement BtnCheckOut => BrowserFactory.SetWebElement("//button[contains(@name,'processAddress')]");

        public void CheckOutDelivery() => BrowserFactory.Click(BtnCheckOut);
    }
}
