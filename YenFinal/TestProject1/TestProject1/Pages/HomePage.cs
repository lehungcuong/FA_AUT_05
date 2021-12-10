using OpenQA.Selenium;
using TestProject1.Test;
using TestProject2.WebDriver.WebDriver;

namespace TestProject1.Pages
{
    public class HomePage : BasePage
    {

        public HomePage(IWebDriver drive) : base(drive)
        {

        }
        #region element page  
        private IWebElement BtnSignIn => Driver.FindElement(By.XPath("//a[@class='login']"));
        private IWebElement BtnAddToCart => Driver.FindElement(By.CssSelector("#homefeatured:first-child li:first-child a.button.ajax_add_to_cart_button.btn.btn-default"));
       
        #endregion

        #region action page 

        /// <summary>
        /// Assert go to Home page by tittle
        /// </summary>
        /// <param name="tittle"></param>
        public void AssertGoToHomeByTittle(string tittle)
        {
            BrowserFactory.AssertPageByTittle(Driver, tittle);
        }
        /// <summary>
        /// Validate Open Page
        /// </summary>
        /// <returns></returns>
        public bool ValidateOpenPage()
        {
            if (Driver.Url == "http://automationpractice.com/index.php")
            {

                return true;
            }

            return false;
        }

        /// <summary>
        /// Navigate to Sign In page
        /// </summary>
        /// <returns></returns>
        public SignInPage NavigateToSignInPage()
        {
            BrowserFactory.ClickElement(BtnSignIn);
            return new SignInPage(Driver);
        }

        /// <summary>
        /// Navigate To Register Page
        /// </summary>
        /// <returns></returns>
        public RegisterPage NavigateToRegisterPage()
        {
            BrowserFactory.ClickElement(BtnSignIn);
            return new RegisterPage(Driver);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DetailPage NavigateToDetailPage()
        {
            BrowserFactory.ScrollToElement(Driver, 500);
            BrowserFactory.ClickElementJavaScrip(Driver, BtnAddToCart);
            return new DetailPage(Driver);
        }



        #endregion
    }
}
