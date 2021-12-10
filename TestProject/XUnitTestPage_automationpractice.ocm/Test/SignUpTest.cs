using Xunit;
using XUnitTestPage_automationpractice.com.Page;
using XUnitTestPage_automationpractice.com.TestData;
using XUnitTestPage_automationpractice.com.Utilities;

namespace XUnitTestPage_automationpractice.com.Test
{
    public class SignUpTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly SignInPage signInPage;
        private readonly CreateAccountPage createAccountPage;
        private readonly MyAccountPage myAccountPage;
        private readonly TShirtPage tShirtPage;
        private readonly SumaryPage sumaryPage;
        private readonly AddressPage addressPage;
        private readonly ShippingPage shippingPage;
        private readonly PaymentPage paymentPage;

        public SignUpTest()
        {
            homePage = new HomePage(browserFactory.Driver);
            signInPage = new SignInPage(browserFactory.Driver);
            createAccountPage = new CreateAccountPage(browserFactory.Driver);
            myAccountPage = new MyAccountPage(browserFactory.Driver);
            tShirtPage = new TShirtPage(browserFactory.Driver);
            sumaryPage = new SumaryPage(browserFactory.Driver);
            addressPage = new AddressPage(browserFactory.Driver);
            shippingPage = new ShippingPage(browserFactory.Driver);
            paymentPage = new PaymentPage(browserFactory.Driver);
        }

        //test shop 1 item and check out 
        #region class test http://automationpractice.com/
        [Theory(DisplayName = "Create account Data Test")]
        [JsonReader("CreateUserData.json", "CreateUser")]
        public void CreateAccount(string gender,string customerFirstName, string customerLastName, string customer_Email,
                                string password, string day, string moth, string year, string address,
                                string city, string state, string postcode, string phone, string alias)
        {
            #region homepage
            homePage.MaximineWindow();
            homePage.ClickToSign();
            #endregion homepage

            #region signin page
            signInPage.SetEmailTest(customer_Email);
            signInPage.ClickCreateAccount();
            #endregion

            #region create account apge
            
            createAccountPage.inputData(gender,customerFirstName, customerLastName, customer_Email, password, day, moth, year, address, city, state, postcode, phone, alias);
            createAccountPage.SubmitRegistration();
            #endregion

            #region My account page
            string acctualUsername = customerFirstName + " " + customerLastName;
            WebKeyword.AssertValue(myAccountPage.CheckUsername(acctualUsername), AssertType.True, "user name incorrect");
            myAccountPage.ClickOnTShirt();
            #endregion

            #region TshirtPage add item to cart
            tShirtPage.addToCartAndCheckOut();
            tShirtPage.addToCartAndCheckOut();
            #endregion

        }
        #endregion

        //test shop 1 item and check out 
        #region class test http://automationpractice.com/
        [Theory(DisplayName = "Create account Data Test")]
        [JsonReader("CreateUserData.json", "CreateUser")]
        public void CheckBuyOneItem(string gender, string customerFirstName, string customerLastName, string customer_Email,
                                string password, string day, string moth, string year, string address,
                                string city, string state, string postcode, string phone, string alias)
        {
            #region homepage
            homePage.MaximineWindow();
            homePage.ClickToSign();
            #endregion homepage

            #region signin page
            signInPage.SetEmailTest(customer_Email);
            signInPage.ClickCreateAccount();
            #endregion

            #region create account apge

            createAccountPage.inputData(gender, customerFirstName, customerLastName, customer_Email, password, day, moth, year, address, city, state, postcode, phone, alias);
            createAccountPage.SubmitRegistration();
            #endregion

            #region My account page
            string acctualUsername = customerFirstName + " " + customerLastName;
            WebKeyword.AssertValue(myAccountPage.CheckUsername(acctualUsername), AssertType.True, "user name incorrect");
            myAccountPage.ClickOnTShirt();
            #endregion

            #region TshirtPage add item to cart
            tShirtPage.addToCartAndCheckOut();
            tShirtPage.addToCartAndCheckOut();
            #endregion

        #region payment
            #region Sumary
            sumaryPage.clickOnProceedToCheck();
            #endregion
            #region address
            addressPage.ClickProceedToCheckout();
            #endregion
            #region Shipping
            shippingPage.CheckTermAndClickToProceed();
            #endregion
            #region Payment
            paymentPage.ClickOnPayByBankWire();
            #endregion
        #endregion

        }
        #endregion



    }
}
