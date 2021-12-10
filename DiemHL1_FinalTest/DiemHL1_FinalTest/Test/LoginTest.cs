using System;
using System.Threading;
using DiemHL1_FinalTest.Pages;
using OpenQA.Selenium;
using Xunit;

namespace DiemHL1_FinalTest.Test
{
    public class LoginTest : BaseTest
    {
        readonly HomePage HomePage;
        readonly SignInPage SignInPage;

        public LoginTest()
        {
            HomePage = new HomePage(browserFactory.Driver);
            SignInPage = new SignInPage(browserFactory.Driver);
        }
        [Fact(DisplayName = "Verify button Sign in open page correct")]
        public void LoginTestCase()
        {
            // Step 1. Click button "Sign in" at HeaderMenu
            HomePage.ClickOnSignInButton();

            // Step 2. Verify the links will lead to the respective page
            IWebElement TXT_SignInPage = browserFactory.Driver.FindElement(By.XPath("//h1[@class='page-heading']"));
            browserFactory.AssertFluent("AUTHENTICATION", TXT_SignInPage.Text, "Validate item fail");

            // Pause the screen for 5 seconds
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // End Function
            browserFactory.Driver.Quit();
        }

        [Fact(DisplayName = "Verify button create an account open page correct")]
        public void CreateAccountTestCase()
        {
            // Step 1. Click button "Sign in" at HeaderMenu
            HomePage.ClickOnSignInButton();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Step 2. 2. Scroll down to  "Authentication" component
            IJavaScriptExecutor scrollInBookNow = (IJavaScriptExecutor)browserFactory.Driver;
            scrollInBookNow.ExecuteScript("scroll(0, 300);");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Step 3. At "Create an Account"  Input type for element address email
            SignInPage.CreateAccount();

            // Step 4. Click button"Create an Account"
            SignInPage.ClickOnCreate();

            // Pause the screen for 5 seconds
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // End Function
            browserFactory.Driver.Quit();
        }

        [Fact(DisplayName = "Verify button Sign In open page correct at page Authentication")]
        public void VerifyButtonSignIn_TestCase()
        {
            // Step 1. Click button "Sign in" at HeaderMenu
            HomePage.ClickOnSignInButton();

            // Step 2. Scroll down to  "Authentication" component
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            IJavaScriptExecutor scrollInBookNow = (IJavaScriptExecutor)browserFactory.Driver;
            scrollInBookNow.ExecuteScript("scroll(0, 300);");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Step 3. At "ALREADY REGISTERED?"  Input email and password  for elements 
            SignInPage.CheckLogin();

            // Step 4. Click button "Sign in"
            SignInPage.ClickOnLogin();

            // Pause the screen for 5 seconds
            Thread.Sleep(TimeSpan.FromSeconds(5));

            // End Function
            browserFactory.Driver.Quit();
        }
    }
}
