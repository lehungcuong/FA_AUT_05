using AutomationDemo.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThaoPTT12_Final.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver Driver) : base(Driver)
        {

        }
        private IWebDriver BtnRegister => Driver.FindElement(By.XPath("//a[@class='login']"));
        private IWebDriver BtnSignIn => Driver.FindElement(By.XPath("//a[@class='login']"));
        private IWebDriver BtnWomen => Driver.FindElement(By.XPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']//a[text()='Women']"));

        public bool OpenWeb()
        {
            if (Driver.Url == "http://automationpractice.com/index.php")
            {
                return true;
            }
            return false;
        }

        public WomanPage ClickButtonResgister()
        {
            BtnRegister.Click();
            return new WomanPage(Driver);
        }

        public WomanPage ClickButtonSignIn()
        {
            BtnSignIn.Click();
            return new WomanPage(Driver);
        }
        public WomanPage ClickOnButtonWomen()
        {
            BtnWomen.Click();
            return new WomanPage(Driver);
        }
    }
}
