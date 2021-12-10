using OpenQA.Selenium;
using PHP_Travel_POM.Pages;

namespace DiemHL1_FinalTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        // Elements for Home Page
        //IWebElement BtnSignIn => Driver.FindElement(By.XPath("//a[@title='Log in to your customer account']"));
        IWebElement BtnSignIn => Driver.FindElement(By.XPath("//div[@class='header_user_info']"));



        // Actions for Home Page
        public void ClickOnSignInButton()
        {
            BtnSignIn.Click();
        }

        //public void ClickOnToursButton()
        //{
        //    BtnTours.Click();
        //}
    }
}
