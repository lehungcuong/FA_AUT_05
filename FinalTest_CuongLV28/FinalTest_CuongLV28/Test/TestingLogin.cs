using System;
using FinalTest_CuongLV28.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace FinalTest_CuongLV28.Test
{
    public class TestingLogin : BaseTest
    {
        HomePage homePage;
        LoginPage loginpage;
        RegisterPage register;
        CreateAnAccountPage createAnAccountPage;

    public TestingLogin()
        {
            homePage = new HomePage(driver);
            loginpage = new LoginPage(driver);
            register = new RegisterPage(driver);
            createAnAccountPage = new CreateAnAccountPage(driver);
        }

        [Fact]
        public void LoginandRegister()
        {
            homePage.GotoSignIn();
            Assert.Equal("Login - My Store", driver.Title);

            register.SubmitCreate();
            Assert.Equal("Login - My Store", driver.Title);

            createAnAccountPage.InputInformation();
            Assert.Equal("My account - My Store", driver.Title);

            loginpage.LogIn();
            Assert.Equal("My account - My Store", driver.Title);

            createAnAccountPage.Scrolldown();


        }
    }
}
