using OpenQA.Selenium;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class HomePage : BasePage
    {
        private readonly string HomePageURL = "http://automationpractice.com/";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Btn_SignIn => Keyword.FindElement(By.XPath("//*[@class='login']"));

        public void ValidateHomePage() => Keyword.GetURL().Equals(HomePageURL);

        public void MaximineWindow()
        {
            Keyword.Maximize();
        }

        public SignInPage ClickToSign()
        {
            Keyword.Click(Btn_SignIn);
            return new SignInPage(Driver);
        }

    }
}
