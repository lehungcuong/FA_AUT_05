using LuanNHB_Final.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFactory;
using Xunit;

namespace LuanNHB_Final.Test
{
    public class PurchaseOneProduct : BaseTest
    {
        private readonly HomePage homePage;
        private readonly SignInPage signInPage;
        private readonly ShoppingCardPage shoppingCardPage;
        private readonly AddressPage address;
        private readonly ShippingPage shippingPage;
        private readonly PaymentPage paymentPage;
        private readonly ConfirmOrderPage confirmOrderPage;
        private readonly MyAccountPage myAccountPage;
        private readonly ProductDetailPage productDetailPage;


        public PurchaseOneProduct()
        {
            homePage = new HomePage(BrowserFactory.Driver);
            signInPage = new SignInPage(BrowserFactory.Driver);
            shoppingCardPage = new ShoppingCardPage(BrowserFactory.Driver);
            address = new AddressPage(BrowserFactory.Driver);
            shippingPage = new ShippingPage(BrowserFactory.Driver);
            paymentPage = new PaymentPage(BrowserFactory.Driver);
            confirmOrderPage = new ConfirmOrderPage(BrowserFactory.Driver);
            myAccountPage = new MyAccountPage(BrowserFactory.Driver);
            productDetailPage = new ProductDetailPage(BrowserFactory.Driver);
        }

        [Theory(DisplayName = "Test purchase the Product InlineData")]
        [InlineData("luannhb1122@gmail.com", "123456")]
        public void PurchaseOneProductTest(string email, string password)
        {

            homePage.NavigateToProductDetail();

            shoppingCardPage.CheckOutShoppingCard();

            signInPage.LoginAccountPage(email, password);
            address.CheckOutDelivery();
            shippingPage.CheckOutShippingPage();
            paymentPage.ChooseBankPayment();
            confirmOrderPage.ConfirmOrder();
        }


    }
}
