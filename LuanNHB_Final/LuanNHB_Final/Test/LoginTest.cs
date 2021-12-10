using LuanNHB_Final.DataTest;
using LuanNHB_Final.Pages;
using WebDriverFactory;
using Xunit;

namespace LuanNHB_Final.Test
{
    public class LoginTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly SignInPage signInPage;

        public LoginTest()
        {
            homePage = new HomePage(BrowserFactory.Driver);
            signInPage = new SignInPage(BrowserFactory.Driver);
        }
        [Theory(DisplayName = "Test login Page")]
        [JsonReader("LoginDataTest.json", "Data")]
        public void LoginAcountPage(string email, string password)
        {
            homePage.NavigateToSignInPage();
            signInPage.LoginAccountPage(email, password);
        }
    }
}
