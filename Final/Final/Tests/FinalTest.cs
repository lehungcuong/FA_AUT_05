using Final.Pages;
using Final.Utilities;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Final.Tests
{
    [TestCaseOrderer("Final.Utilities.AlphabeticalOrderer", "Final")]
    public class FinalTest : BaseTest
    {
        private readonly LoginPage loginPage;
        private readonly RegisterPage registerPage;
        private readonly MyAccountPage myAccountPage;
        private readonly HomePage homePage;
        private readonly OrderPage orderPage;

        private string minute = DateTime.Now.Minute.ToString();
        private string millisecond = DateTime.Now.Millisecond.ToString();
        private string date = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";

        public FinalTest(TestFixture testFixture, ITestOutputHelper testOutputHelper) : base(testFixture, testOutputHelper)
        {
            loginPage = new LoginPage(driver);
            registerPage = new RegisterPage(driver);
            myAccountPage = new MyAccountPage(driver);
            homePage = new HomePage(driver);
            orderPage = new OrderPage(driver);
        }

        [Theory(DisplayName = "Register New Account Test")]
        [JsonReader("TestData\\Data.json", "data")]
        public void Test_1_RegisterSuccessfully
            (
                string firstName, string lastName, string email, string password, string day, string month, string year, string address, string city, string state, string postCode, string phone
            )
        {
            try
            {
                loginPage.NavigateToLoginPage();
                loginPage.InputRegisterEmail($"{email}{minute}{millisecond}@gmail.com");
                loginPage.CreateAccount();
                fixture.Report.PassReport("Go to Register page successfull");
                registerPage.InputCustomerFirstName(firstName);
                registerPage.InputCustomerLastName(lastName);
                registerPage.InputPassword(password);
                registerPage.SelectDateOfBirth(day, month, year);
                registerPage.InputFirstName(firstName);
                registerPage.InputLastName(lastName);
                registerPage.InputAddress(address);
                registerPage.InputCity(city);
                registerPage.SelectStates(state);
                registerPage.InputPostCode(postCode);
                registerPage.InputMobilePhone(phone);
                registerPage.SubmitAccount();
                myAccountPage.VerifyLoginSuccessfully(firstName, lastName);
                fixture.Report.PassReport("Register Successfully");
            }
            catch (Exception e)
            {
                fixture.Report.FailReport("Fail To Register");
                Console.WriteLine(e.Message);
                throw;
            }
          
        }

        [Theory(DisplayName = "Login Account Test")]
        [JsonReader("TestData\\Data.json", "data")]
        public void Test_2_LoginSuccessfully
            (
                string firstName, string lastName, string email, string password, string day, string month, string year, string address, string city, string state, string postCode, string phone
            )
        {
            try
            {
                loginPage.NavigateToLoginPage();
                loginPage.InputLoginEmail($"{email}@gmail.com");
                loginPage.InputLoginPassword(password);
                loginPage.SubmitLogin();
                myAccountPage.VerifyLoginSuccessfully(firstName, lastName);
                fixture.Report.PassReport("Login successfully");
            }
            catch (Exception e)
            {
                fixture.Report.FailReport("Fail To Login");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [Theory(DisplayName = "Purchase 1 product Test")]
        [JsonReader("TestData\\Data.json", "data")]
        public void Test_3_PurchaseAProduct
            (
                string firstName, string lastName, string email, string password, string day, string month, string year, string address, string city, string state, string postCode, string phone
            )
        {
            try
            {
                loginPage.SummaryLogin(email, password);
                homePage.NavigateToHomePage();
                homePage.AddTheFirstProductToCart();
                homePage.ProceedToCheckout();
                fixture.Report.PassReport("Add product to cart successfully");
                orderPage.ProceedToCheckout();
                orderPage.ProceedToCheckoutAddress();
                orderPage.AgreeTerm();
                orderPage.ProceedToCheckoutShipping();
                orderPage.ChoosePaymentMethod();
                orderPage.ConfirmOrder();
                orderPage.VerifyOrderCompleted("Your order on My Store is complete.");
                fixture.Report.PassReport("Purchase product successfully");
            }
            catch (Exception e)
            {
                fixture.Report.FailReport("Fail To Purchase");
                Console.WriteLine(e.Message);
                throw;
            }
          
        }

        [Theory(DisplayName = "WishList Function Test")]
        [JsonReader("TestData\\Data.json", "data")]
        public void Test_4_WishlishFunction
            (
                string firstName, string lastName, string email, string password, string day, string month, string year, string address, string city, string state, string postCode, string phone
            )
        {
            try
            {
                loginPage.SummaryLogin(email, password);
                homePage.NavigateToHomePage();
                homePage.AddProductToWishList(homePage.btnMoreDetailOfProduct);
                homePage.ManageAccount();
                fixture.Report.PassReport("Go to My account successfully");
                myAccountPage.ManageWishList();
                myAccountPage.VerifyCreatedDate(date);
                fixture.Report.PassReport("Add Product to wishlist successfully");
            }
            catch (Exception e)
            {
                fixture.Report.FailReport("Fail To Add Product to wishlist");
                Console.WriteLine(e.Message);
                throw;
            }
          
        }
    }
}
