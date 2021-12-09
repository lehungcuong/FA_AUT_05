
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using FluentAssertions;

namespace TestPOM.Pages
{
    class Tourspage : BasePage
    {

        public Tourspage(IWebDriver Driver) : base(Driver)
        {

        }
        public ClassFunction ClassFunction;
        /// choose tours  you want to go
        private IWebElement CLicktourswanttogo => Driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[3]"));
        //click Book TOURS PACKAGES TODAY
        private IWebElement CLickbooknow => Driver.FindElement(By.XPath("//button[@class='effect ladda effect ladda-button waves-effect']"));
        private IWebElement Firstname => Driver.FindElement(By.XPath("(//input[@placeholder='First Name'])[1]"));
        private IWebElement Lastname => Driver.FindElement(By.XPath("(//input[@placeholder='Last Name'])[1]"));
        private IWebElement Email => Driver.FindElement(By.XPath("(//input[@placeholder='Email'])[1]"));

        private IWebElement Phone => Driver.FindElement(By.XPath("(//input[@placeholder='Phone'])[1]"));
        private IWebElement Address => Driver.FindElement(By.XPath("(//input[@placeholder='Address'])[1]"));
        private IWebElement Title => Driver.FindElement(By.XPath("//select[@name='title_1']//option[@value='Mr']"));
        private IWebElement FirstName1 => Driver.FindElement(By.XPath("//input[@name='firstname_1']"));
        private IWebElement ClassName1 => Driver.FindElement(By.XPath("//input[@name='lastname_1']"));
        private IWebElement Title2 => Driver.FindElement(By.XPath("//select[@name='title_2']//option[@value='Mr']"));
        private IWebElement FirstName2 => Driver.FindElement(By.XPath("//input[@name='firstname_2']"));
        private IWebElement ClassName2 => Driver.FindElement(By.XPath("//input[@name='lastname_2']"));
        private IWebElement Paylater => Driver.FindElement(By.XPath("(//div[@class='d-flex mb-2 input'])[2]"));
        private IWebElement agree => Driver.FindElement(By.XPath("//label[@for='agreechb']"));
        private IWebElement Confimr => Driver.FindElement(By.XPath("//button[text()='Confirm Booking']"));
        //private IWebElement TextAfterclickPetrafromoman => Driver.FindElement(By.XPath("//h3[text()='Day Visit of Petra from Oman']"));


       //public string AfterclickPetrafromoman = "Day Visit of Petra from Oman";

        public void fluentAssert(string value , string value1 , string message)
        {
            value.Should().BeEquivalentTo(value1,message);
        }

        
        public void inputinfomation()
        {
            ClassFunction = new ClassFunction();
        }

        public void Choosetours()
        {
            
            ClassFunction.WebElementClick(CLicktourswanttogo);    
            //fluentAssert(TextAfterclickPetrafromoman.Text, AfterclickPetrafromoman, "check fail");
            ClassFunction.ScrollWindowBrowser(Driver, 500);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(CLickbooknow);
            ClassFunction.ScrollWindowBrowser(Driver, 800);
            Thread.Sleep(1000);
            ClassFunction.WebElementinput(Firstname, "Quang");
            ClassFunction.WebElementinput(Lastname, "Tran");
            ClassFunction.WebElementinput(Email, "quangtran111@gmail.com");
            ClassFunction.WebElementinput(Phone, "123456789");
            ClassFunction.WebElementinput(Address, "83/2C");

            ClassFunction.WebElementClick(Title);

            ClassFunction.WebElementinput(FirstName1, "Quang");
            ClassFunction.WebElementinput(ClassName1, "Tran");

            ClassFunction.WebElementClick(Title2);
            ClassFunction.WebElementinput(FirstName2, "Quang");
            ClassFunction.WebElementinput(ClassName2, "Tran");
            ClassFunction.ScrollWindowBrowser(Driver, 1000);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(Paylater);
            ClassFunction.WebElementClick(agree);
            ClassFunction.WebElementClick(Confimr);
            Thread.Sleep(10000);

            IJavaScriptExecutor Srollpage = (IJavaScriptExecutor)Driver;

            Thread.Sleep(2000);
            Srollpage.ExecuteScript("window.scrollTo(0, 500)");
            CLicktourswanttogo.Click();

            Srollpage.ExecuteScript("window.scrollTo(0, 800)");
            Thread.Sleep(2000);  
            
            CLickbooknow.Click();
            Thread.Sleep(2000);

            Firstname.SendKeys("Quang");
            Lastname.SendKeys("Tran");
            Email.SendKeys("quangtran111@gmail.com");
            Phone.SendKeys("0123456789");
            Address.SendKeys("83/2C");
            Title.Click();
            FirstName1.SendKeys("Quang1");
            ClassName1.SendKeys("Tran");
            Title2.Click();
            FirstName2.SendKeys("Quang2");
            ClassName2.SendKeys("Tran");
            Srollpage.ExecuteScript("window.scrollTo(0, 1000)");
            Thread.Sleep(1000);
            Paylater.Click();
            agree.Click();
            Confimr.Click();           
            Thread.Sleep(3000);
            Srollpage.ExecuteScript("window.scrollTo(0, 300)");

        }  
        /*
        public void Bookingtoursbydata(string textFirstname, string textLastname, string textEmail, string textPhone, string textAddress,
           string textFirstName1, string textClassName1, string textFirstName2, string textClassName2)
        {
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(CLicktourswanttogo);
            //fluentAssert(TextAfterclickPetrafromoman.Text, AfterclickPetrafromoman, "check text oman fail");
            Thread.Sleep(1000);
            ClassFunction.ScrollWindowBrowser(Driver, 500);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(CLickbooknow);
            ClassFunction.ScrollWindowBrowser(Driver, 800);
            Thread.Sleep(1000);
            ClassFunction.WebElementinput(Firstname, textFirstname);
            ClassFunction.WebElementinput(Lastname, textLastname);
            ClassFunction.WebElementinput(Email, textEmail);
            ClassFunction.WebElementinput(Phone, textPhone);
            ClassFunction.WebElementinput(Address, textAddress);

            ClassFunction.WebElementClick(Title);

            ClassFunction.WebElementinput(FirstName1, textFirstName1);
            ClassFunction.WebElementinput(ClassName1, textClassName1);

            ClassFunction.WebElementClick(Title2);
            ClassFunction.WebElementinput(FirstName2, textFirstName2);
            ClassFunction.WebElementinput(ClassName2, textClassName2);
            ClassFunction.ScrollWindowBrowser(Driver, 1000);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(Paylater);
            ClassFunction.WebElementClick(agree);
            ClassFunction.WebElementClick(Confimr);
            Thread.Sleep(10000);


        }*/
    }
}