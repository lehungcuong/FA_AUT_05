using System;
using WebDriver;
using Xunit.Abstractions;
using Xunit.DriverFactory.Utilities;
using Xunit.FinalTest.Pages;
using Xunit.FinalTest.Pages.CheckOutProgressPage;
using Xunit.Priority;

namespace Xunit.FinalTest.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("Test Collection")]
    public class FullTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly LoginPage loginPage;
        private readonly RegisterPage registerPage;
        private readonly MyAccountPage myAccountPage;
        private readonly DressesCategoryPage dressesCategoryPage;
        private readonly ProductDetailPage productDetailPage;
        private readonly CheckOutSummaryPage checkOutSummaryPage;
        private readonly CheckOutAddressPage checkOutAddressPage;
        private readonly CheckOutShippingPage checkOutShippingPage;
        private readonly CheckOutPaymentPage checkOutPaymentPage;
        private readonly PaymentConfirmPage paymentConfirmPage;
        private readonly OrderConfirmPage orderConfirmPage;
        private readonly UserInformationPage userInformationPage;
        private readonly SearchPage searchPage;

        public FullTest(ITestOutputHelper output) : base(output)
        {
            homePage = new HomePage(browserFactory.driver);
            loginPage = new LoginPage(browserFactory.driver);
            registerPage = new RegisterPage(browserFactory.driver);
            myAccountPage = new MyAccountPage(browserFactory.driver);
            dressesCategoryPage = new DressesCategoryPage(browserFactory.driver);
            productDetailPage = new ProductDetailPage(browserFactory.driver);
            checkOutSummaryPage = new CheckOutSummaryPage(browserFactory.driver);
            checkOutAddressPage = new CheckOutAddressPage(browserFactory.driver);
            checkOutShippingPage = new CheckOutShippingPage(browserFactory.driver);
            checkOutPaymentPage = new CheckOutPaymentPage(browserFactory.driver);
            paymentConfirmPage = new PaymentConfirmPage(browserFactory.driver);
            orderConfirmPage = new OrderConfirmPage(browserFactory.driver);
            userInformationPage = new UserInformationPage(browserFactory.driver);
            searchPage = new SearchPage(browserFactory.driver);
        }

        [Theory(DisplayName = "Register With Valid Account Test"), Priority(0)]
        [JsonReader("TestData.json", "Data")]
        public void RegisterWithValidAccountTest(string gender, string firstname, 
        string lastname, string password, string dob, string address, string city, string state,
        string postalcode, string phone, string assignaddress)
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Create random number for email
                Random random = new Random();
                int randomNumber = random.Next(500, 100000);
                string email = firstname + lastname + randomNumber + "@gmail.com";

                //Click on sign in button at homepage
                homePage.ClickOnSignInButton();

                //Input new email and create account
                loginPage.EnterEmailAndCreateNewAccount(email);

                //Input user information
                registerPage.EnterAccountInformation(gender, firstname, lastname, password, dob, address, 
                city, state, postalcode, phone, assignaddress);

                //Load json file and set value from data set 
                JsonHelper.LoadJson();
                JsonHelper.SetValueByKeyJson(email, "Email");
                JsonHelper.SetValueByKeyJson(password, "Password");
                JsonHelper.SetValueByKeyJson(firstname, "Firstname");
                JsonHelper.SetValueByKeyJson(lastname, "Lastname");
                JsonHelper.SetValueByKeyJson(gender, "Gender");
                JsonHelper.SetValueByKeyJson(dob, "Dob");
                
                //Save to json file
                JsonHelper.SaveJson();

                //Click on button register
                registerPage.ClickOnButtonRegister();

                //Verify login success after register
                BrowserFactory.AssertValueBool(myAccountPage.IsLoginSuccess(), XunitPOM.Utilities.AssertType.True, "Login not success !", "Login successfully !");
            });
        }

        [Fact(DisplayName = "Login With Valid Account Test"), Priority(1)]
        public void LoginWithValidAccountTest()
        {
            // Click on signin button
            homePage.ClickOnSignInButton();

            // Login on account just create and get it data from json file 
            loginPage.LoginWithValidAccount(JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Password"));
            BrowserFactory.AssertValueBool(myAccountPage.IsLoginSuccess(), XunitPOM.Utilities.AssertType.True, "Login not success !", "Login successfully !");
        }

        [Fact(DisplayName = "Order One Product And Check Out Test"), Priority(2)]
        public void OrderOneProductAndCheckOutTest()
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Click on signin button
                homePage.ClickOnSignInButton();

                // Login in account just create and get it data from json
                loginPage.LoginWithValidAccount(JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Password"));
                
                // Navigate to home page
                myAccountPage.NavigateToHomePage();

                // Click on dresses button
                homePage.ClickOnDressesButton();

                // Choose product with name get data from jsn
                dressesCategoryPage.ChooseProduct(JsonHelper.GetValueByKeyRawData("Product Name 1", @"\TestData\JsonData.json"));
                
                // Click on add to cart 
                productDetailPage.ClickOnAddToCart();
                
                // Click on button proceed to checkout
                productDetailPage.ClickOnButtonProceedToCheckOut();
                
                // Click on button proceed to checkout 
                checkOutSummaryPage.ClickOnButtonProceedCheckOut();

                // Click on button proceed to checkout
                checkOutAddressPage.ClickOnButtonProceedCheckOut();

                // Click on button accept term of service
                checkOutShippingPage.ClickOnButtonAcceptTermOfService();

                // Click on button proceed to checkout
                checkOutShippingPage.ClickOnButtonProceedCheckOut();

                // Click on button proceed to checkout
                checkOutPaymentPage.ClickOnButtonProceedCheckOut();

                // Click on button proceed to checkout
                paymentConfirmPage.ClickOnButtonProceedCheckOut();

                // Verify order successfully or not
                BrowserFactory.AssertValueBool(orderConfirmPage.IsOrderSuccess(), XunitPOM.Utilities.AssertType.True, "Order not success !", "Order successfully !");
            });
        }

        [Fact(DisplayName = "Order Three Product And Check Out Test"), Priority(3)]
        public void OrderThreeProductAndCheckOutTest()
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Click on sign in button
                homePage.ClickOnSignInButton();

                // Login with valid account get from json data
                loginPage.LoginWithValidAccount(JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Password"));
                
                // Navigate to home page
                myAccountPage.NavigateToHomePage();
                
                // Click on dresses button
                homePage.ClickOnDressesButton();

                // Click on name of product 1 get in json data
                dressesCategoryPage.ChooseProduct(JsonHelper.GetValueByKeyRawData("Product Name 1", @"\TestData\JsonData.json"));
                
                // Click on add to cart
                productDetailPage.ClickOnAddToCart();
                
                // Click on countinue shopping
                productDetailPage.ClickOnButtonCountinueShopping();
               
                // Navigate to dresses category page
                productDetailPage.NavigateToDressesCategoryPage();

                // Click on name of product 2 get in json data
                dressesCategoryPage.ChooseProduct(JsonHelper.GetValueByKeyRawData("Product Name 2", @"\TestData\JsonData.json"));

                // Click on add to cart
                productDetailPage.ClickOnAddToCart();

                // Click on countinue shopping
                productDetailPage.ClickOnButtonCountinueShopping();

                // Navigate to dresses category page
                productDetailPage.NavigateToDressesCategoryPage();

                // Click on name of product 3 get in json data
                dressesCategoryPage.ChooseProduct(JsonHelper.GetValueByKeyRawData("Product Name 3", @"\TestData\JsonData.json"));
                
                // Click on button add to cart
                productDetailPage.ClickOnAddToCart();

                // Click on button proceed check out
                productDetailPage.ClickOnButtonProceedToCheckOut();

                // Click on button proceed check out
                checkOutSummaryPage.ClickOnButtonProceedCheckOut();

                // Click on button proceed check out
                checkOutAddressPage.ClickOnButtonProceedCheckOut();

                // Click on button accept term of service
                checkOutShippingPage.ClickOnButtonAcceptTermOfService();

                // Click on button proceed check out
                checkOutShippingPage.ClickOnButtonProceedCheckOut();

                // Click on button proceed check out
                checkOutPaymentPage.ClickOnButtonProceedCheckOut();

                // Click on button proceed check out
                paymentConfirmPage.ClickOnButtonProceedCheckOut();

                // Verify order successfully or not
                BrowserFactory.AssertValueBool(orderConfirmPage.IsOrderSuccess(), XunitPOM.Utilities.AssertType.True, "Order not success !", "Order successfully !");
            });
        }

        [Fact(DisplayName = "Add One Product To Wishlist Test"), Priority(4)]
        public void AddOneProductToWishlistTest()
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Click on sign in button
                homePage.ClickOnSignInButton();

                // Login with valid account get from json data
                loginPage.LoginWithValidAccount(JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Password"));
                
                // Navigate to home page
                myAccountPage.NavigateToHomePage();
                
                // Click on dresses button
                homePage.ClickOnDressesButton();
                
                // Choose first product get in json data
                dressesCategoryPage.ChooseProduct(JsonHelper.GetValueByKeyRawData("Product Name 1", @"\TestData\JsonData.json"));
                
                // Click on add to wish list
                productDetailPage.ClickOnAddToWishListButton();
                
                // Validate add to wishlist success or not
                BrowserFactory.AssertValueBool(productDetailPage.IsAddToWishlistSuccess(), XunitPOM.Utilities.AssertType.True, "Add to wishlist fail !", "Add to wishlist successfully !");
            });
        }

        [Fact(DisplayName = "Verify Account Information Test"), Priority(5)]
        public void VerifyAccountInformationTest()
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Click on sign in button
                homePage.ClickOnSignInButton();

                // Login with account in json data
                loginPage.LoginWithValidAccount(JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Password"));
                
                // Validate login success or not
                BrowserFactory.AssertValueBool(myAccountPage.IsLoginSuccess(), XunitPOM.Utilities.AssertType.True, "Login not success !", "Login successfully !");
                
                // Click on my personal information button
                myAccountPage.ClickOnMyPersonalInformationButton();

                // Validate firstname, lastname, email and dob in datajson is correct
                BrowserFactory.AssertValueBool(userInformationPage.ValidateUserInformation(
                    JsonHelper.GetValueByKeySavedData("Firstname"), JsonHelper.GetValueByKeySavedData("Lastname"),
                    JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Dob")),
                    XunitPOM.Utilities.AssertType.True, "User information is not correct !", "User information is correct !");
            });
        }

        [Fact(DisplayName = "Verify Add Negative Product Quantity Test"), Priority(6)]
        public void VerifyAddNegativeProductQuantityTest()
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Click on sign in button
                homePage.ClickOnSignInButton();

                // Login with valid accout from json data
                loginPage.LoginWithValidAccount(JsonHelper.GetValueByKeySavedData("Email"), JsonHelper.GetValueByKeySavedData("Password"));
                
                // Validate login success or not
                BrowserFactory.AssertValueBool(myAccountPage.IsLoginSuccess(), XunitPOM.Utilities.AssertType.True, "Login not success !", "Login successfully !");
                
                // Navigate to home page
                myAccountPage.NavigateToHomePage();
                
                // Click on dresses button
                homePage.ClickOnDressesButton();
                
                // Choose product name from json data
                dressesCategoryPage.ChooseProduct(JsonHelper.GetValueByKeyRawData("Product Name 1", @"\TestData\JsonData.json"));
                
                // Enter negative quantity
                productDetailPage.EnterNegativeQuantity();
                
                // Click on add to cart
                productDetailPage.ClickOnAddToCart();
                
                // Validate add to cart successfuly or not
                BrowserFactory.AssertValueBool(productDetailPage.IsAddToCartSuccess(), XunitPOM.Utilities.AssertType.False, "Negative Value verify fail !", "Negative Value have been verify successfully !");
            });
        }

        [Fact(DisplayName = "Verify Sort Discount Item Test"), Priority(7)]
        public void VerifySortDiscountItemTest()
        {
            ReportHelper.ShouldNotThrow<Exception>(() =>
            {
                // Enter search value
                homePage.EnterSearchValue();

                // Click on 
                homePage.ClickOnButtonSearch();
                BrowserFactory.AssertValueBool(searchPage.IsSortCorrectly(), XunitPOM.Utilities.AssertType.True, "Sort item not correct !", "Sort item is correct !");
            });
        }
    }
}
