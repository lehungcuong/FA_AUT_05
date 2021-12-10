using FluentAssertions;
using LoiDV4_Final.Common;
using LoiDV4_Final.Page;
using Xunit;

namespace LoiDV4_Final.Test
{
    public class RegisterTest : BaseTest
    {     
        private readonly HomePage homePage;

        public RegisterTest()
        {
            homePage = new HomePage(browser);
        }

        /// <summary>
        /// Verify create an account
        /// </summary>
        [Fact(DisplayName = "Verify Create An Account")]
        public void VerifyCreateAccount()
        {
           homePage.CreateAccount();
           string myAccountTitle = WebKeywords.GetTitle();
           myAccountTitle.Should().Be("My account - My Store");

        }


    }
}
