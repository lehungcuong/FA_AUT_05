using Auto.Page;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auto.Test
{
    public class LoginFailTest : BaseTest
    {
        HomePage homePage;
        LoginPage loginPage;
        /// <summary>
        /// Constructor of LoginFailTest
        /// </summary>
        public LoginFailTest()
        {
            homePage = new HomePage(browsers.driver);
            loginPage = new LoginPage(browsers.driver);
        }
        /// <summary>
        /// Test case Login fail with password='123456789
        /// </summary>
        [Fact(DisplayName ="Login fail with password='123456789'")]
        public void LoginFail()
        {
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits("ntnhien19091999@gmail.com", "123456789");
            bool result2 = loginPage.VerifyLogInFail();
            result2.Should().BeTrue();

        }
    }
}
