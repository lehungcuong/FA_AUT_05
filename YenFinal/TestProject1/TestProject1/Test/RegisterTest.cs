using TestProject1.Pages;
using TestProject1.ReportHelper;
using Xunit;

namespace TestProject1.Test
{
    public class RegisterTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;
        private readonly InputInformationOfRegisterPage inputInformationOfRegisterPage;



        public RegisterTest()
        {
            homePage = new HomePage(browserFactory.driver);
            registerPage = new RegisterPage(browserFactory.driver);
            inputInformationOfRegisterPage=new InputInformationOfRegisterPage(browserFactory.driver);
        }
        
        [Theory]
        [InlineData("hihianhcon@gmail.com")]
        public void VerifyRegisterTest(string mail)

        {
            //Choose Sign in menu
            ExtentReportsHelper.CreateTestReporst("Test case Register");
            ExtentReportsHelper.extentTest.Pass("Navigate to Sign In page");
            homePage.ValidateOpenPage();
            homePage.AssertGoToHomeByTittle("My Store");
            homePage.NavigateToRegisterPage();

            //Enter data in Email input
            ExtentReportsHelper.extentTest.Pass("Navigate to Input Information Of Register page");
            registerPage.AssertGoToRegisterInByTittle("Login - My Store"); 
            registerPage.NavigateInputInformationOfRegister(mail);

            //Input data information of Register
            ExtentReportsHelper.extentTest.Pass("Navigate to My Account page");
            inputInformationOfRegisterPage.NavigateMyAccountPage();
            inputInformationOfRegisterPage.AssertInformationOfRegisterByTittle("My account - My Store");



        }
    }
    }

