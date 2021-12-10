using Auto.Data;
using Auto.Page;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auto.Test
{
    public class LoginTest : BaseTest
    {
        HomePage homePage;
        LoginPage loginPage;
        /// <summary>
        /// Constructor of LoginTest
        /// </summary>
        public LoginTest()
        {
            homePage = new HomePage(browsers.driver);
            loginPage = new LoginPage(browsers.driver);
        }
        /// <summary>
        /// Test case Login the system succesfully with Inline Data
        /// 1. Click button Sign in
        /// 2. Input field Email Address
        /// 3. Input field Password
        /// 4. Click button Sign in
        /// </summary>
        [Theory(DisplayName = "Login the system succesfully with Inline Data")]
        [InlineData("ntnhien19091999@gamail.com", "12345")]
        [InlineData("ntnhien@gmail.com", "12345")]

        public void LoginSuccesfullyWithInlineData(string email, string password)
        {
           
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits(email, password);
        }
        /// <summary>
        /// Test case Login the system succesfully with Member Data
        /// 1. Click button Sign in
        /// 2. Input field Email Address
        /// 3. Input field Password 
        /// 4. Click button Sign in
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        [Theory(DisplayName = "Login the system succesfully with Member Data")]
        [MemberData(nameof(Data))]
        public void LoginSuccesfullyWithMemberData(string email, string password)
        {
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits(email, password);
        }
        public static IEnumerable<object[]> Data =>
          new List<object[]>
             {
            new object[] {"ntnhien19091999@gmail.com", "12345" },
            new object[] { "ntnhien@gmail.com", "12345" },

                };
        /// <summary>
        /// Test case Login the system succesfully with Class Data Data
        /// 1. Click button Sign in
        /// 2. Input field Email Address
        /// 3. Input field Password
        /// 4. Click button Sign in
        /// </summary>

        [Theory(DisplayName = "Login the system succesfully with Class Data")]
        [ClassData(typeof(LoginData))]
        public void LoginSuccesfullyWithClassdata(string email, string password)
        {
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits(email, password);
        }
        
    }
}
