using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutomationDemo.Pages;

namespace ThaoPTT12_Final.Pages
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver Driver) : base(Driver)
        {
        }
        private IWebElement AddressEmail => Driver.FindElement(By.XPath("//input[@id='email_create']"));
        private IWebElement BtnSubmit => Driver.FinElement(By.XPath("//button[@id='SubmitCreate']"));

        private IWebElement CheckMrs => Driver.FindElement(By.XPath("//input[@id='id_gender2']"));
        private IWebElement FirstName => Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        private IWebElement LastName => Driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
        private IWebElement PassWord => Driver.FindElement(By.XPath("//input[@id='passwd']"));
        private IWebElement FirstName1 => Driver.FindElement(By.XPath("//input[@id='firstname']"));
        private IWebElement LastName1 => Driver.FindElement(By.XPath("//input[@id='lastname']"));
        private IWebElement Address => Driver.FindElement(By.XPath("//input[@id='address1']"));
        private IWebElement City => Driver.FindElement(By.XPath("//input[@id='city']"));
        private IWebElement State => Driver.FindElement(By.XPath("//div[@id='uniform-id_state']"));
        private IWebElement PostalCode => Driver.FindElement(By.XPath("//input[@id='postcode']"));
        private IWebElement MobilePhone => Driver.FindElement(By.XPath("//input[@id='phone_mobile']"));
        private IWebElement BtnRegister => Driver.FindElement(By.XPath("//button[@id='submitAccount']"));

        public void Register()
        {
            Thread.Sleep(3000);
            AddressEmail.SendKey("phamthanhthaobp@gmail.com");
            BtnSubmit.Click();
        }

        public void InputInformation()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Srollpage.ExecuteScript("window.scrollTo(0, 300)");

            CheckMrs.CLick();
            Thread.Sleep(1000);
            FirstName.SendKey("Thao");
            Thread.Sleep(1000);
            LastName.SendKey("Pham");
            Thread.Sleep(1000);
            PassWord.SendKey("123456");
            Thread.Sleep(1000);

            Srollpage.ExecuteScript("window.scrollTo(0, 600)");
            FirstName1.SendKey("Thao");
            Thread.Sleep(1000);
            LastName1.SendKey("Pham");
            Thread.Sleep(1000);
            Address.SendKey("Nguyen Trai Q5");
            Thread.Sleep(1000);
            City.SendKey("HCM");
            Thread.Sleep(1000);
            State.Click();
            Thread.Sleep(1000);
            Srollpage.ExecuteScript("window.scrollTo(0, 600)");
            PostalCode.SendKey("12345");
            Thread.Sleep(1000);
            MobilePhone.SendKey("0123456789");
            Thread.Sleep(1000);
            BtnRegister.Click();
            Thread.Sleep(1000);
        }
    }
}
