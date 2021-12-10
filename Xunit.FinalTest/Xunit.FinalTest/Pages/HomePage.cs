using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement btnSignin => BrowserFactory.FindElement(By.XPath("//a[@class='login']"));
        private IWebElement btnDresses => BrowserFactory.FindElement(By.XPath("(//ul/li/a[@title='Dresses'])[2]"));
        private IWebElement txtSearchBox => BrowserFactory.FindElement(By.XPath("//input[@id='search_query_top']"));
        private IWebElement btnSearch => BrowserFactory.FindElement(By.XPath("//button[@name='submit_search']"));

        //Actions
        public LoginPage ClickOnSignInButton()
        {
            BrowserFactory.JsClick(btnSignin);
            return new LoginPage(Driver);
        }

        public DressesCategoryPage ClickOnDressesButton()
        {
            BrowserFactory.JsClick(btnDresses);
            return new DressesCategoryPage(Driver);
        }

        public void EnterSearchValue()
        {
            BrowserFactory.setText(txtSearchBox, "Printed Dress");
        }

        public SearchPage ClickOnButtonSearch() {
            BrowserFactory.JsClick(btnSearch);
            return new SearchPage(Driver);
        }

    }
}