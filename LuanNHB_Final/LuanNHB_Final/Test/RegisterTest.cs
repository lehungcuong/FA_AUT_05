using LuanNHB_Final.DataTest;
using LuanNHB_Final.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFactory;
using Xunit;

namespace LuanNHB_Final.Test
{
    public class RegisterTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly SignInPage signInPage;
        private readonly RegisterAccountPage registerAccountPage;

        public RegisterTest()
        {
            homePage = new HomePage(BrowserFactory.Driver);
            signInPage = new SignInPage(BrowserFactory.Driver);
            registerAccountPage = new RegisterAccountPage(BrowserFactory.Driver);
        }
        [Theory(DisplayName = "Test login Page")]
        [JsonReader("RegisterAccountDataTest.json", "Data")]
        public void LoginAcountPage(
            string firstName,
            string lastName,
            string email,
            string password,
            string birthDay,
            string birthMonth,
            string birthYear,
            string companyName,
            string address,
            string city,
            string state,
            string postCode,
            string country,
            string mobilePhone)
        {
            homePage.NavigateToSignInPage();
            signInPage.ResgisterAccount("Luan122234@gmail.com");
            registerAccountPage.RegisterAccoutData(
             firstName,
             lastName,
             email,
             password,
             birthDay,
             birthMonth,
             birthYear,
             companyName,
             address,
             city,
             state,
             postCode,
             country,
             mobilePhone);

        }
    }
}
