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
    public class RegisterTest : BaseTest
    {
        private readonly RegisterPage registerPage;
        private readonly HomePage homePage;

        public RegisterTest()
        {
            homePage = new HomePage(browerFactory.Driver);
            registerPage = new RegisterPage(browerFactory.Driver);
        }

        [Fact(DisplayName = "Login Test")]
        public void LoginTestSuccess()
        {
            homePage.ClickButtonResgister();
            Thread.Sleep(5000);

            registerPage.Register();
            Thread.Sleep(5000);

            registerPage.InputInformation();

            Thread.Sleep(5000);
        }
    }
}
