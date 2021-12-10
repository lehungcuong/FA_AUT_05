using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTest_CuongLV28.Page
{
    public class CreateAnAccountPage : BasePage
    {
        public CreateAnAccountPage(IWebDriver driver) : base(driver)
        {
        }

        SelectElement SelectTitle => new SelectElement(Driver.FindElement(By.XPath("//input[@id='id_gender1']")));
        IWebElement FirtsName => Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        IWebElement LastName => Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
        IWebElement Email => Driver.FindElement(By.XPath("//input[@id='email']"));
        IWebElement PassWord => Driver.FindElement(By.XPath("//input[@id='passwd']"));
        SelectElement DayofBirth => new SelectElement(Driver.FindElement(By.XPath("//select[@id='days']")));
        SelectElement MonthofBirth => new SelectElement(Driver.FindElement(By.XPath("//select[@id='months']")));
        SelectElement YearofBirth => new SelectElement(Driver.FindElement(By.XPath("//select[@id='years']")));

        // Adress


        IWebElement FNameAdress => Driver.FindElement(By.XPath("//input[@id='firstname']"));
        IWebElement LNameAdress => Driver.FindElement(By.XPath("//input[@id='lastname']"));
        IWebElement Company => Driver.FindElement(By.XPath("//input[@id='company']"));
        IWebElement Adress1 => Driver.FindElement(By.XPath("//input[@id='address1']"));
        IWebElement Adress2 => Driver.FindElement(By.XPath("//input[@id='address2']"));
        IWebElement City => Driver.FindElement(By.XPath("//input[@id='city']"));
        SelectElement selectState => new SelectElement(Driver.FindElement(By.XPath("//select[@id='id_state']")));
        IWebElement PostCode => Driver.FindElement(By.XPath("//input[@id='postcode']"));
        SelectElement Country => new SelectElement(Driver.FindElement(By.XPath("//select[@id='id_country']")));
        IWebElement Additional => Driver.FindElement(By.XPath("//textarea[@id='other']"));
        IWebElement Homephone => Driver.FindElement(By.XPath("//input[@id='phone']"));
        IWebElement MobilePhone => Driver.FindElement(By.XPath("//input[@id='phone_mobile']"));

        IWebElement BtnRegister => Driver.FindElement(By.XPath("//button[@id='submitAccount']"));



        public void InputInformation()
        {
            SelectTitle.SelectByText("MR");
            FirtsName.SendKeys("Le");
            LastName.SendKeys("Cuong");
            Email.SendKeys("Cuonglv15296@gmail.com");
            PassWord.SendKeys("qqqqqq");
            DayofBirth.SelectByValue("15");
            MonthofBirth.SelectByValue("June");
            YearofBirth.SelectByValue("1996");

            // adress

            FNameAdress.SendKeys("Le");
            LNameAdress.SendKeys("CUong");
            Company.SendKeys("McDonal");
            Adress1.SendKeys("12ere");
            Adress2.SendKeys("324dsfs");
            City.SendKeys("Taxes");

            selectState.SelectByText("Hawaii");
            PostCode.SendKeys("40000");
            Country.SelectByText("United States");
            Additional.SendKeys("abc, xyz");

            Homephone.SendKeys("2394823948");
            MobilePhone.SendKeys("123123124");

            BtnRegister.Click();
        }

        public void Scrolldown()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("scroll(0, 3000);");
            Thread.Sleep(5000);
        }
    }   
}
