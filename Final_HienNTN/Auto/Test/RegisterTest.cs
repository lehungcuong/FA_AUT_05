using Auto.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Auto.Test
{
    public class RegisterTest : BaseTest
    {
        HomePage homePage;
        AccountPage accountPage;
        LoginPage loginPage;
        /// <summary>
        /// Constructor of RegisterTest
        /// </summary>
        public RegisterTest()
        {
            homePage = new HomePage(browsers.driver);
            accountPage = new AccountPage(browsers.driver);
            loginPage = new LoginPage(browsers.driver);
        }
        /// <summary>
        /// Test case Resgiter Account Succesfully
        /// </summary>
        [Fact(DisplayName ="Resgiter Account Succesfully")]
        public void RegisterAcoountSuccesfully()
        {
            
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.InputEmail();
            accountPage.InputInfomationAccount();
            bool result2 = accountPage.VerifyTitle();
            result2.Should().BeTrue();
        }
    }
}
