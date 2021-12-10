using Auto.Page;
using FluentAssertions;
using Xunit;

namespace Auto.Test
{
    public class InvalidEmailAddressTest : BaseTest
    {
        HomePage homePage;
        LoginPage loginPage;
        ProductPage productPage;
        /// <summary>
        /// Contructor of InvalidEmailAddressTest
        /// </summary>
        public InvalidEmailAddressTest()
        {
            homePage = new HomePage(browsers.driver);
            loginPage = new LoginPage(browsers.driver);
            productPage = new ProductPage(browsers.driver);
        }
        /// <summary>
        /// Test case Verify the system allow input invalid Email Address
        /// </summary>
        [Fact(DisplayName = "Verify the system allow input invalid Email Address")]
        public void VerifyInvalidEmailAddress()
        {
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits("ntnhien19091999@gmail.com", "12345");
            loginPage.ClickLogo();
            bool result2 = homePage.VerifyGotoHomePage();
            result2.Should().BeTrue();
            homePage.Click1Product();
            productPage.ClickSendToFriend();

        }
    }
}
