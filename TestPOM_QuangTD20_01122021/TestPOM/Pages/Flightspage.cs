using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
/*
namespace TestPOM.Pages
{
    class FlightsPage : BasePage
    {
        public FlightsPage(IWebDriver Driver) : base(Driver)
        {
          
        }
        public ClassFunction ClassFunction;

        //private string Result;
       
        private IWebElement Inputflyingfrom => Driver.FindElement(By.XPath("//input[@id='autocomplete']"));
        private IWebElement Inputplacedestination => Driver.FindElement(By.XPath("//input[@id='autocomplete2']"));
        private IWebElement Flightdeparturedate => Driver.FindElement(By.XPath("//div[@class='form-group']//input[@class='depart form-control'] "));
        private IWebElement Clicksearchtofindflights => Driver.FindElement(By.XPath("//button[@id='flights-search'] "));
        private IWebElement Booking => Driver.FindElement(By.XPath("//li[1]//button"));
        private IWebElement Firstname => Driver.FindElement(By.XPath("//div[2]/div/div/div[1]/div/div/input"));
        private IWebElement Lastname => Driver.FindElement(By.XPath("//div[2]/div/div/div[2]/div/div/input"));
        private IWebElement Email => Driver.FindElement(By.XPath("//div[@class='form-group']//input[@placeholder='Email']"));
        private IWebElement Phone => Driver.FindElement(By.XPath("//div[@class='form-group']//input[@placeholder='Phone']"));
        private IWebElement Address => Driver.FindElement(By.XPath("//div[@class='form-group']//input[@placeholder='Address']"));
        ///public IWebElement Title       => Driver.FindElement(By.XPath("//select[@name='title_1']//option[@value='Mr']"));
        private IWebElement FirstName1 => Driver.FindElement(By.XPath("//div[2]/div[1]/div[2]/input"));
        private IWebElement ClassName1 => Driver.FindElement(By.XPath("//div[2]/div[1]/div[3]/input"));
        public IWebElement Nationality => Driver.FindElement(By.XPath("//select[@name ='nationality_1']//option[@value='VN']"));
        public IWebElement Month => Driver.FindElement(By.XPath("//select[@name ='dob_month_1']//option[@value='02']"));
        public IWebElement Day => Driver.FindElement(By.XPath("//input[@name ='dob_day_1']"));
        public IWebElement Year => Driver.FindElement(By.XPath("//input[@name ='dob_year_1']"));
        public IWebElement Passport => Driver.FindElement(By.XPath("//input[@name='passport_1']"));
        public IWebElement PassportM => Driver.FindElement(By.XPath("//select[@name='passport_issuance_month_1']//option[@value='02']"));
        public IWebElement PassportD => Driver.FindElement(By.XPath("//div[3]/div[2]/div/div[2]/input"));

        public IWebElement PassportY => Driver.FindElement(By.XPath("//div[3]/div[2]/div/div[3]/input"));

        public IWebElement PassportM1 => Driver.FindElement(By.XPath("//select[@name='passport_month_1']//option[@value='02']"));
        public IWebElement PassportD1 => Driver.FindElement(By.XPath("//div[3]/div[3]/div/div[2]/input"));
        public IWebElement PassportY1 => Driver.FindElement(By.XPath("//div[3]/div[3]/div/div[3]/input"));
        public IWebElement Paylater => Driver.FindElement(By.XPath("//input[@id='gateway_pay-later']"));
        public IWebElement agree => Driver.FindElement(By.XPath("//div[1]/div[4]/div/div/div/label"));

        public IWebElement Confimr => Driver.FindElement(By.XPath("//button[@class='theme-btn book waves-effect']"));
        
        //public IWebElement Assertbooking => Driver.FindElement(By.XPath("//main/div/div[2]/div/div/div/div/div[1]/p"));
        public void InputSearch()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Inputflyingfrom.SendKeys("DUB");
            Inputplacedestination.SendKeys("LCG");
            Flightdeparturedate.Clear();
            Flightdeparturedate.SendKeys("27-11-2021");
            Clicksearchtofindflights.Click();
            Thread.Sleep(3000);
            Srollpage.ExecuteScript("window.scrollTo(0, 300)");
            Booking.Click();
        }

        public void Inputinfomation()
        {
            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;
            Firstname.SendKeys("Quang");
            Lastname.SendKeys("Tran");
            Email.SendKeys("quangtrang@gmail.com");
            Phone.SendKeys("0123456789");
            Address.SendKeys("83/2C");
            FirstName1.SendKeys("Quang");
            ClassName1.SendKeys("Tran");
            Srollpage.ExecuteScript("window.scrollTo(0, 700)");
            Thread.Sleep(1000);
            Nationality.Click();
            Month.Click();
            Day.SendKeys("20");
            Year.SendKeys("1999");
            Passport.SendKeys("123456789");
            PassportM.Click();
            PassportD.SendKeys("20");
            PassportY.SendKeys("2019");
            PassportM1.Click();
            PassportD1.SendKeys("20");
            PassportY1.SendKeys("2023");
            Srollpage.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(1000);
            Paylater.Click();
            agree.Click();
            Confimr.Click();
        }

    }
}

*/