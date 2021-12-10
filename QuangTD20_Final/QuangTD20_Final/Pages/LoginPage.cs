using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using FluentAssertions;


namespace QuangTD20_Final.Pages
{
    class Loginpage : BasePase
    {
        public Loginpage(IWebDriver Driver) : base(Driver)
        {

        }

        private IWebElement Email => Driver.FindElement(By.XPath("//*[@id='email']"));
        private IWebElement Password => Driver.FindElement(By.XPath("//*[@id='passwd']"));
        ///i[@class='icon-lock left']
        private IWebElement Signin => Driver.FindElement(By.XPath("//*[@id='SubmitLogin']/span"));
        public void Login()
        {
            Thread.Sleep(1000);
            Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            ClassFunction.WebElementinput(Email,"quangtrangk111@gmail.com");
            Thread.Sleep(1000);
            ClassFunction.WebElementinput(Password,"0123456789");
            ClassFunction.WebElementClick(Signin);
        }
        
        public void Loginbydata(string email,string password)
        {
            ClassFunction.WebElementinput(Email, email);
            Thread.Sleep(1000);
            ClassFunction.WebElementinput(Password, password);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(Signin);
        }
    }
}
