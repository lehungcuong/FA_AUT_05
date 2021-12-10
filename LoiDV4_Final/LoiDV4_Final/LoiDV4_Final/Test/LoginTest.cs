using FluentAssertions;
using LoiDV4_Final.Common;
using LoiDV4_Final.Page;
using Xunit;

namespace LoiDV4_Final.Test
{
    public class LoginTest : BaseTest
    {
        private readonly HomePage homePage;  

        public LoginTest()
        {
            homePage = new HomePage(browser);    
        }

        /// <summary>
        /// Verify Login with JsonData
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        [Theory(DisplayName = "Verify login to system")]
        [JSONReader("TestData\\fileData\\Account.json", "Account")]
        public void VerifyLogin(string email, string password)
        {
            homePage.LoginWithDataDriven(email, password);
            string myAccountTitle = WebKeywords.GetTitle();
            myAccountTitle.Should().Be("My account - My Store");

        }
    }
}
