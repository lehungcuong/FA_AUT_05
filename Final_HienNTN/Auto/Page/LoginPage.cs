using OpenQA.Selenium;
using System.Threading;

namespace Auto.Page
{
    public class LoginPage : BasePage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver"></param>
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        //Element
        IWebElement txtCretaEmailAddress => pageHelper.FindElement(By.XPath("//input[@id ='email_create']"));
        IWebElement btnSubmit => pageHelper.FindElement(By.XPath("//i[@class='icon-user left']"));
        IWebElement txtEmailAddress => pageHelper.FindElement(By.XPath("//input[@id='email']"));
        IWebElement txtPassword => pageHelper.FindElement(By.XPath("//input[@id='passwd']"));
        IWebElement btnSignIn => pageHelper.FindElement(By.XPath("//i[@class='icon-lock left']"));
        IWebElement logo => pageHelper.FindElement(By.XPath("//img[@class='logo img-responsive']"));
        IWebElement title => pageHelper.FindElement(By.XPath("//h1[text()='Authentication']"));
        IWebElement title1 => pageHelper.FindElement(By.XPath("//div[@class='alert alert-danger']/p"));
        /// <summary>
        /// Input field Email 
        /// </summary>
        public void InputEmail()
        {
            //Scrol window
            pageHelper.ScrollWindown(Driver, 400);
            //click and input text box Create Email Address
            pageHelper.ClickJSEL(txtCretaEmailAddress);
            pageHelper.SenkeyEL(txtCretaEmailAddress, "ngochien0000@gmail.com");
            //Click button Submit
            pageHelper.ClickJSEL(btnSubmit);
            Thread.Sleep(7000);
        }
        /// <summary>
        /// Verify title = AUTHENTICATION
        /// </summary>
        /// <returns></returns>
        public bool VerifyGoToREGISTEREDPage()
        {
            return pageHelper.ValidateWebTitle("AUTHENTICATION", title) ? true : false;
        }
        /// <summary>
        /// Login With Account Exits
        /// </summary>
        public void LoginWithAccountExits(string Email, string password)
        {
            //click and input textbox Email Address
            pageHelper.ClickJSEL(txtEmailAddress);
            pageHelper.SenkeyEL(txtEmailAddress, Email);
            //click and input textbox Password
            pageHelper.ClickJSEL(txtPassword);
            pageHelper.SenkeyEL(txtPassword, password);
            //Click button Sign up
            pageHelper.ClickJSEL(btnSignIn);
            Thread.Sleep(7000);
        }
        /// <summary>
        /// Click Login go to Home Page
        /// </summary>
        public void ClickLogo()
        {
            pageHelper.ClickJSEL(logo);
            Thread.Sleep(7000);

        }
        public bool VerifyLogInFail()
        {
            return pageHelper.ValidateWebTitle("There is 1 error", title1) ? true : false;
        }
    }
}
