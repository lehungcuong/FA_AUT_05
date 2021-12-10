using OpenQA.Selenium;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement Txt_CreateAccountEmailAddress => Keyword.FindElement(By.XPath("//*[@id='email_create']"));

        public IWebElement Btn_SubmitEmail => Keyword.FindElement(By.XPath("//*[@id='SubmitCreate']"));

        public CreateAccountPage ClickCreateAccount()
        {
            Keyword.Click(Btn_SubmitEmail);
            return new CreateAccountPage(Driver);
        }
        /// <summary>
        /// set email text
        /// </summary>
        /// <param name="email"></param>
        public void SetEmailTest(string email)
        {
            Keyword.SetText(Txt_CreateAccountEmailAddress, email);
        }
    }
}
