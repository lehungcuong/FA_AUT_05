using OpenQA.Selenium;
using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(Browser browser) : base(browser)
        {

        }

        // Get xpath of email address, password and login button
        IWebElement txtEmail = Browser.GetElement(By.XPath("//input[@id='email']"));
        IWebElement txtPassword = Browser.GetElement(By.XPath("//input[@id='passwd']"));
        IWebElement btnSignIn = Browser.GetElement(By.XPath("//button[@id='SubmitLogin']"));

        // Check if the page redirected to Login page
        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }

        // Input username and password
        public void InputLoginInformation(string email, string password)
        {
            Browser.EnterText(txtEmail, email);
            Browser.EnterText(txtPassword, password);
        }

        // Go to My Account page
        public MyAccountPage NavigateToMyAccountPage()
        {
            Browser.ClickToElement(btnSignIn);
            return new MyAccountPage(browser);
        }
    }
}
