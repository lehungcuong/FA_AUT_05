using FinalTest.DataTest;
using FinalTest.Pages;
using Xunit;

namespace FinalTest.Test
{
    public class MyAccountTest : BaseTest
    {
        readonly HomePage homePage;
        readonly LoginPage loginPage;
        readonly MyAccountPage myAccountPage;   
        readonly MyAddressPage addressPage;

        public MyAccountTest()
        {
            homePage = new HomePage(browser);
            loginPage = new LoginPage(browser);
            myAccountPage = new MyAccountPage(browser); 
            addressPage = new MyAddressPage(browser);   
        }

        [Theory]
        [JsonReader("jsconfig.json", "data")]
        public void LoginAccountTest(string email, string password)
        {
            homePage.NavigatePageSuccess("My Store");
            homePage.NavigateToLoginPage();
            loginPage.NavigatePageSuccess("Login - My Store");
            loginPage.InputLoginInformation(email, password);
            loginPage.NavigateToMyAccountPage();
            myAccountPage.NavigatePageSuccess("My account - My Store");
            myAccountPage.NavigateToMyAddressPage();
        }
    }
}
