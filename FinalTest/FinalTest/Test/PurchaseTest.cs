using FinalTest.DataTest;
using FinalTest.Pages;
using Xunit;

namespace FinalTest.Test
{
    public class PurchaseTest : BaseTest
    {
        readonly HomePage homePage;
        readonly LoginPage loginPage;   
        readonly MyAccountPage myAccountPage;
        readonly ProductDetailPage productDetailPage;
        readonly ShoppingCartPage shoppingCartPage; 
        readonly AddressPage addressPage;   
        readonly ShippingPage shippingPage; 
        readonly PaymentPage paymentPage;   
        readonly CheckPaymentPage checkPaymentPage; 
        readonly OrderConfirmationPage orderConfirmationPage;

        public PurchaseTest()
        {
            homePage = new HomePage(browser);
            loginPage = new LoginPage(browser); 
            myAccountPage = new MyAccountPage(browser); 
            productDetailPage = new ProductDetailPage(browser); 
            shoppingCartPage = new ShoppingCartPage(browser);   
            addressPage = new AddressPage(browser);
            shippingPage = new ShippingPage(browser);
            paymentPage = new PaymentPage(browser);
            checkPaymentPage = new CheckPaymentPage(browser);
            orderConfirmationPage = new OrderConfirmationPage(browser);
        }

        [Theory]
        [JsonReader("jsconfig.json", "data")]
        public void AddToCardTest(string email, string password)
        {
            homePage.NavigatePageSuccess("My Store");
            homePage.NavigateToLoginPage();
            loginPage.NavigatePageSuccess("Login - My Store");
            loginPage.InputLoginInformation(email, password);
            loginPage.NavigateToMyAccountPage();
            myAccountPage.NavigatePageSuccess("My account - My Store");
            myAccountPage.GoBackToHomePage();
            homePage.NavigatePageSuccess("My Store");
            homePage.SelectItem();
            productDetailPage.NavigatePageSuccess("Faded Short Sleeve T-shirts - My Store");
            productDetailPage.InputOrderInformation();
            productDetailPage.NavigateToShoppingCartSummary();
            shoppingCartPage.NavigatePageSuccess("Order - My Store");
            shoppingCartPage.NavigateToAddressPage();
            addressPage.NavigateToShippingPage();
            shippingPage.ClickToTermOfServiveButton();
            shippingPage.NavigateToPaymentPage();
            paymentPage.NavigateToCheckPaymentPage();
            checkPaymentPage.NavigateToOrderConfirmationPage();
            orderConfirmationPage.NavigatePageSuccess("Order confirmation - My Store");
        }
    }
}
