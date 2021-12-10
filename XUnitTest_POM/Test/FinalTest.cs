using Xunit;
using XUnitTest_POM.Constraints;
using XUnitTest_POM.Page;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Test
{
    public class FinalTest : BaseTest
    {
        readonly HomePage homePage;
        readonly LoginPage loginPage;
        readonly MyAccountPage myAccountPage;
        readonly Register register;
        readonly AddToCartPage addToCart;
        readonly CheckoutPage checkoutPage;

        public FinalTest()
        {
            homePage = new HomePage(BrowserFactory.driver);
            loginPage = new LoginPage(BrowserFactory.driver);
            myAccountPage = new MyAccountPage(BrowserFactory.driver);
            register = new Register(BrowserFactory.driver);
            addToCart = new AddToCartPage(BrowserFactory.driver);
            checkoutPage = new CheckoutPage(BrowserFactory.driver);
        }

        [Theory(DisplayName = "Register Account")]
        [JsonReader(@"TestData\data.json", "Register")]
        public void RegisterAccount(string firstNamePersonal, string lastNamePersonal, string emailPersonal, string passwordPersonal, string firstName, string lastName,
            string address, string city, string state, string postalCode, string mobilePhone, string alias)
        {
                BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
                homePage.ClickLoginPage();
                BrowserFactory.FluentAssert(loginPage.VerifyLoginPage, "Login Page Fail");
                loginPage.InputEmail();
                loginPage.ClickCreatAnAccount();
                BrowserFactory.FluentAssert(register.VerifyRegisterAccountPage, "YOUR PERSONAL INFORMATION");
                register.InputInformationCreatAnAccout(firstNamePersonal, lastNamePersonal, emailPersonal, passwordPersonal, firstName, lastName,
                address, city, state, postalCode, mobilePhone, alias);
                register.ClickRegisterButton();
        }

        [Theory(DisplayName = "Purchase One Product")]
        [JsonReader(@"TestData\data.json", "Login")]
        public void PurchaseOneProduct(string email, string password)
        {
                BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
                homePage.ClickLoginPage();
                BrowserFactory.FluentAssert(loginPage.VerifyLoginPage, "Login Page Fail");
                loginPage.InputAccountLogin(email, password);
                loginPage.ClickSignIn();

                homePage.ClickLogo();
                BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
                homePage.ClickFristProduct();
                addToCart.ClickAddToCart();
                BrowserFactory.FluentAssert(addToCart.VerifyCheckoutPage, "Add To Cart Fail");
                addToCart.ClickCheckout();

                checkoutPage.CheckoutSummary();
                checkoutPage.CheckoutAddress();
                checkoutPage.CheckoutShipping();
                checkoutPage.CheckoutPayment();
                BrowserFactory.FluentAssert(checkoutPage.VerifyCheckout, "Checkout Fail");
                checkoutPage.ConfirmPayment();
        }

        [Theory(DisplayName = "Add to Wishlist")]
        [JsonReader(@"TestData\data.json", "Login")]
        public void AddToWish(string email, string password)
        {
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
            homePage.ClickLoginPage();
            BrowserFactory.FluentAssert(loginPage.VerifyLoginPage, "Login Page Fail");
            loginPage.InputAccountLogin(email, password);
            loginPage.ClickSignIn();

            homePage.ClickLogo();
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
            homePage.ClickFristProduct();
            addToCart.ClickAddToWishlist();
        }

        [Theory(DisplayName = "Purchase Three Product")]
        [JsonReader(@"TestData\data.json", "Login")]
        public void PurchaseThreeProduct(string email, string password)
        {
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
            homePage.ClickLoginPage();
            BrowserFactory.FluentAssert(loginPage.VerifyLoginPage, "Login Page Fail");
            loginPage.InputAccountLogin(email, password);
            loginPage.ClickSignIn();

            homePage.ClickLogo();
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
            homePage.ClickFristProduct();
            addToCart.ClickAddToCart();
            addToCart.ClickContinueShopping();

            homePage.ClickLogo();
            homePage.ClickSecondProduct();
            addToCart.ClickAddToCart();
            addToCart.ClickContinueShopping();

            homePage.ClickLogo();
            homePage.ClickThirdProduct();
            addToCart.ClickAddToCart();
            BrowserFactory.FluentAssert(addToCart.VerifyCheckoutPage, "Add To Cart Fail");
            addToCart.ClickCheckout();

            checkoutPage.CheckoutSummary();
            checkoutPage.CheckoutAddress();
            checkoutPage.CheckoutShipping();
            checkoutPage.CheckoutPayment();
            BrowserFactory.FluentAssert(checkoutPage.VerifyCheckout, "Checkout Fail");
            checkoutPage.ConfirmPayment();
        }

        [Theory(DisplayName = "Add Negative Quantity")]
        [JsonReader(@"TestData\data.json", "Login")]
        public void AddNegativeQuantity(string email, string password)
        {
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
            homePage.ClickLoginPage();
            BrowserFactory.FluentAssert(loginPage.VerifyLoginPage, "Login Page Fail");
            loginPage.InputAccountLogin(email, password);
            loginPage.ClickSignIn();

            homePage.ClickLogo();
            BrowserFactory.FluentAssert(homePage.VerifyHomePage, "Homepage Fail");
            homePage.ClickFristProduct();
            addToCart.InputNegativeQuantity();
            addToCart.ClickAddToCart();
            BrowserFactory.FluentAssertFalse(addToCart.VerifyCheckoutPage, "Success Add to Cart");
        }
    }
}
