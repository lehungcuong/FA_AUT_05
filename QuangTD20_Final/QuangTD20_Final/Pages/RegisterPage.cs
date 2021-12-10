
using System.Threading;
using OpenQA.Selenium;

namespace QuangTD20_Final.Pages
{
    class RegisterPage: BasePase
    {
        public RegisterPage(IWebDriver Driver) : base(Driver)
        {
        }
        private IWebElement email => Driver.FindElement(By.XPath("//input[@id='email_create']"));
        //body[@id='authentication']
        private IWebElement createanaccount => Driver.FindElement(By.XPath("//*[@id='SubmitCreate']"));
        private IWebElement title => Driver.FindElement(By.XPath("//*[@id='id_gender1']"));
        private IWebElement firstname => Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        private IWebElement lastname => Driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
        private IWebElement password => Driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement address => Driver.FindElement(By.XPath("//input[@name='address1']"));
        private IWebElement city => Driver.FindElement(By.XPath("//input[@name='city']"));
        private IWebElement postalcode => Driver.FindElement(By.XPath("//input[@id='postcode']"));
        private IWebElement state => Driver.FindElement(By.XPath("//select[@name='id_state']//option[@value='1']"));

        private IWebElement mobilephone => Driver.FindElement(By.XPath("//input[@id='phone_mobile']"));
        ////input[@value='My address']
        private IWebElement addressalias => Driver.FindElement(By.XPath("//input[@value='My address']"));

        public void Register()
        {
           
            Thread.Sleep(2000);
            ClassFunction.WebElementinput(email, "quangtrangk1234@gmail.com");
            Thread.Sleep(2000);
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(createanaccount);
            Thread.Sleep(5000);

        }

        public void Inputinfomation()
        {
            //ClassFunction.WebElementClick(createanaccount);
            Thread.Sleep(5000);
            //ClassFunction.ScrollWindowBrowser(Driver, 300);
            ClassFunction.WebElementClick(title);
            Thread.Sleep(500);
            ClassFunction.WebElementinput(firstname, "Quang");
            Thread.Sleep(500);
            ClassFunction.WebElementinput(lastname, "Tran");
            Thread.Sleep(500);
            ClassFunction.WebElementinput(password, "0123456789");
            Thread.Sleep(500);
            ClassFunction.WebElementinput(address, "83/2 dong nai");
            Thread.Sleep(500);
            ClassFunction.WebElementinput(city, "Ho Chi Minh");
            Thread.Sleep(500);
            ClassFunction.WebElementinput(postalcode, "12345");
            Thread.Sleep(500);
            ClassFunction.WebElementClick(state);
            Thread.Sleep(500);
            ClassFunction.WebElementinput(mobilephone, "0123456789");
            Thread.Sleep(500);
            ClassFunction.WebElementinput(addressalias, "quang213@gmail.com");
            Thread.Sleep(500);

        }

    }
}
