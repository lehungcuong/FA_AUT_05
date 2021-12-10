using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement txtWelcomeTitle => BrowserFactory.FindElement(By.XPath("//p[@class='info-account']"));
        private IWebElement btnPersonalInformation => BrowserFactory.FindElement(By.XPath("//a[@title='Information']"));
        private IWebElement btnHome => BrowserFactory.FindElement(By.XPath("//a[@title='Home']"));

        //Actions
        public bool IsLoginSuccess()
        {
            if (txtWelcomeTitle.Text == "Welcome to your account. Here you can manage all of your personal information and orders.")
            {
                return true;
            }
            return false;
        }

        public UserInformationPage ClickOnMyPersonalInformationButton()
        {
            BrowserFactory.Click(btnPersonalInformation);
            return new UserInformationPage(Driver);
        }

        public HomePage NavigateToHomePage()
        {
            BrowserFactory.JsClick(btnHome);
            return new HomePage(Driver);
        }
    }
}
