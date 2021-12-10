using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThaoPTT12_Final.Pages;
using Xunit;

namespace ThaoPTT12_Final.Test
{
    public class LoginTest : BaseTest
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        public LoginTest()
        {
            homePage = new HomePage(browerFactory.Driver);
            loginPage = new LoginPage(browerFactory.Driver);

        }

        [Fact(DisplayName = "Login Test")]
        public void LoginTestSuccess()
        {
            homePage.ClickButtonSignIn();
            Thread.Sleep(5000);

            loginPage.Login();
            Thread.Sleep(5000);
        }

    }
}
