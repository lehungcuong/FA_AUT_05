using AventStack.ExtentReports;
using QuyenLLP_FinalTest.Pages;
using QuyenLLP_FinalTest.Utilities;
using System.Threading;
using Xunit;

namespace QuyenLLP_FinalTest.Tests
{
    public class AccountTest : BaseTest
    {
        readonly HomePage homePage;
        readonly AuthenticationPage authenticationPage;
        readonly CreateAccountPage createAccountPage;
        readonly DetailProductPage detailProductPage;
        readonly OrderPage orderPage;
        public AccountTest()
        {
            homePage = new HomePage();
            authenticationPage = new AuthenticationPage();
            createAccountPage = new CreateAccountPage();
            detailProductPage = new DetailProductPage();
            orderPage = new OrderPage();
        }

        /// <summary>
        /// Test case for create account successfully
        /// </summary>
        /// <param name="firstNamePersonal"></param>
        /// <param name="lastNamePersonal"></param>
        /// <param name="password"></param>
        /// <param name="firstNameAddress"></param>
        /// <param name="lastNameAddress"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="code"></param>
        /// <param name="phone"></param>
        [Theory(DisplayName = "Test case for create account successfully!!")]
        [ReadDataFromJson(@"Config\data.json", "Data")]
        public void CreateAccount(string firstNamePersonal, string lastNamePersonal, string password,
                                     string firstNameAddress, string lastNameAddress, string address,
                                        string city, string state, string code, string phone)
        {
            try
            {
                ReportHelper.CreateTestReport("Name");
                homePage.ClickLoginInMenuHome();
                ReportHelper.extentTest.Log(Status.Pass, "Redriect To Login Page");
                authenticationPage.AssertTitle();
                authenticationPage.SendEmailCreate();
                authenticationPage.ClickOnCreateButton();
                createAccountPage.WriteInfomation(firstNamePersonal, lastNamePersonal, password, firstNameAddress, lastNameAddress, address, city, state, code, phone);

            }
            catch (System.Exception)
            {
                ReportHelper.extentTest.Log(Status.Pass, "Test Fail!!");
                throw;
            }
        }

        /// <summary>
        /// Test case for order 1 product!
        /// </summary>
        [Fact(DisplayName = "Test case for order 1 product!")]
        public void TestOrder()
        {
            try
            {
                ReportHelper.CreateTestReport("Name");
                homePage.ClickLoginInMenuHome();
                authenticationPage.AssertTitle();
                authenticationPage.SendEmailLogin();
                authenticationPage.SendPassLogin();
                authenticationPage.ClickOnSignBtn();
                homePage.ClickOnLogo();
                homePage.ClickProductInList();
                detailProductPage.ClickBtnAddToCart();
                detailProductPage.ClickCheckOutBtn();
                orderPage.ClickProcessToCheckOutBtn();
                orderPage.ClickProcessAddressBtn();
                orderPage.ClickTermCheckBox();
                orderPage.ClickProcessCarrierBtn();

            }
            catch (System.Exception)
            {
                ReportHelper.extentTest.Log(Status.Pass, "Test Fail!!");
                throw;
            }
        }
        /// <summary>
        /// Test case for order many product!
        /// </summary>
        [Fact(DisplayName = "Test case for order many product!")]
        public void TestOrderManyProduct()
        {
            try
            {
                ReportHelper.CreateTestReport("Name");
                homePage.ClickLoginInMenuHome();
                authenticationPage.AssertTitle();
                authenticationPage.SendEmailLogin();
                authenticationPage.SendPassLogin();
                authenticationPage.ClickOnSignBtn();
                homePage.ClickOnLogo();
                homePage.ClickProductInList();
                detailProductPage.ClickBtnAddToCart();
                detailProductPage.ClickContinue();
                homePage.ClickOnLogo();
                homePage.ClickProduct();
                detailProductPage.ClickBtnAddToCart();
                detailProductPage.ClickCheckOutBtn();
                orderPage.ClickProcessToCheckOutBtn();
                orderPage.ClickProcessAddressBtn();
                orderPage.ClickTermCheckBox();
                orderPage.ClickProcessCarrierBtn();
            }
            catch (System.Exception)
            {
                ReportHelper.extentTest.Log(Status.Pass, "Test Fail!!");
                throw;
            }
        }
    }
}
