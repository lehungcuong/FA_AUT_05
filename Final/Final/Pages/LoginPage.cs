using BrowserFactory;
using OpenQA.Selenium;
using System.Threading;

namespace Final.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        string url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

        IWebElement txtEmailCreate => BrowsersFactory.Get("id:email_create");
        IWebElement btnCreateAccount => BrowsersFactory.Get("Id:SubmitCreate");
        IWebElement txtEmail => BrowsersFactory.Get("Id:email");
        IWebElement txtPassword => BrowsersFactory.Get("Id:passwd");
        IWebElement btnSubmitLogin => BrowsersFactory.Get("Id:SubmitLogin");


        public void NavigateToLoginPage()
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().Refresh();
        }

       public void InputRegisterEmail(string email)
        {
            BrowsersFactory.InputText(txtEmailCreate, email);
        }

        public void CreateAccount()
        {
            BrowsersFactory.ClickElement(btnCreateAccount);
            Thread.Sleep(10000);
        }

        public void InputLoginEmail(string email)
        {
            BrowsersFactory.InputText(txtEmail, email);
        }

        public void InputLoginPassword(string password)
        {
            BrowsersFactory.InputText(txtPassword, password);
        }

        public void SubmitLogin()
        {
            BrowsersFactory.ClickElement(btnSubmitLogin);
        }

        public void SummaryLogin(string email, string password)
        {
            NavigateToLoginPage();
            InputLoginEmail($"{email}@gmail.com");
            InputLoginPassword(password);
            SubmitLogin();
        }
    }
}
