using BrowserFactory;
using FluentAssertions;
using OpenQA.Selenium;

namespace Final.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base(driver) { }

        IWebElement ttlCustomerName => BrowsersFactory.Get("//a[@title='View my customer account']");
        IWebElement btnWishList => BrowsersFactory.Get("//a[@title='My wishlists']");
        IWebElement lblDateCreated => BrowsersFactory.Get("//tbody//td[4]");


        public void VerifyLoginSuccessfully(string firstName, string lastName)
        {
            ttlCustomerName.Text.Should().Be($"{firstName} {lastName}");
        }

        public void ManageWishList()
        {
            BrowsersFactory.ClickElement(btnWishList);
        }

        public void VerifyCreatedDate(string date)
        {
            BrowsersFactory.AssertElementText(lblDateCreated, date);
        }
    }
}
