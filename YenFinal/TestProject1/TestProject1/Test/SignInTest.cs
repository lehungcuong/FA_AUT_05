using TestProject1.Pages;
using TestProject1.ReportHelper;
using Xunit;

namespace TestProject1.Test
{
    public class SignInTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly SignInPage signInPage;

        public SignInTest()
        {
            homePage = new HomePage(browserFactory.driver);
            signInPage = new SignInPage(browserFactory.driver);
        }
        [Theory]
        [JsonReader(@"\Test\jsconfig.json", "data")]
        public void VerifyBookingTours(string signIn,string myAcount,string mail, string pass)
        {
            //Choose Sign in menu
            ExtentReportsHelper.CreateTestReporst("Test case Sign In");
            ExtentReportsHelper.extentTest.Pass("Navigate to Sign In page");
            homePage.ValidateOpenPage();
            homePage.AssertGoToHomeByTittle(signIn);
            homePage.NavigateToSignInPage();

            //Enter data in Email and Password input
            signInPage.AssertGoToSignInByTittle(myAcount);
            ExtentReportsHelper.extentTest.Pass("Navigate to My Acount page");
            signInPage.NavigateMyAccountPage(mail,pass);




        }
    }
}
