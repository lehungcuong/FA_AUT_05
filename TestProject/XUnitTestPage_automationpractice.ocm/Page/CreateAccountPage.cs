using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class CreateAccountPage : BasePage
    {
        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
        }
        
        public IWebElement Cbx_GenderMale => Keyword.FindElement(By.XPath("//*[@id='id_gender1']"));
        public IWebElement Cbx_GenderFemale => Keyword.FindElement(By.XPath("//*[@id='id_gender1']"));
        public IWebElement Txt_CustomerFirstName => Keyword.FindElement(By.XPath("//*[@id='customer_firstname']"));
        public IWebElement Txt_CustomerLastName => Keyword.FindElement(By.XPath("//*[@id='customer_lastname']"));
        public IWebElement Txt_Customer_Email => Keyword.FindElement(By.XPath("//*[@id='email']"));
        public IWebElement Txt_Password => Keyword.FindElement(By.XPath("//*[@id='passwd']"));
        public IWebElement Sl_Day => Keyword.FindElement(By.XPath("//*[@id='days']"));
        public IWebElement Sl_Month => Keyword.FindElement(By.XPath("//*[@id='months']"));
        public IWebElement Sl_Year => Keyword.FindElement(By.XPath("//*[@id='years']"));
        //public IWebElement Txt_FirstName = Keyword.FindElement(By.Id("firstname"));
        //public IWebElement Txt_LastName = Keyword.FindElement(By.Id("lastname"));
        public IWebElement Txt_Address => Keyword.FindElement(By.XPath("//*[@id='address1']"));
        public IWebElement Txt_City => Keyword.FindElement(By.XPath("//*[@id='city']"));
        public IWebElement Sl_State => Keyword.FindElement(By.XPath("//*[@id='id_state']"));
        public IWebElement Txt_Postcode => Keyword.FindElement(By.XPath("//*[@id='postcode']"));
        public IWebElement Txt_MobilePhone => Keyword.FindElement(By.XPath("//*[@id='phone_mobile']"));
        public IWebElement Txt_Alias => Keyword.FindElement(By.XPath("//*[@id='alias']"));
        public IWebElement Btn_Register => Keyword.FindElement(By.XPath("//*[@id='submitAccount']"));

        /// <summary>
        /// gender is Male
        /// </summary>
        public void ClickGenderMale()
        {
            Keyword.Click(Cbx_GenderMale);
        }
        /// <summary>
        /// gender is Female
        /// </summary>
        public void ClickGenderFemale()
        {
            Keyword.Click(Cbx_GenderFemale);
        }

        public void inputData(string gender,string customerFirstName, string customerLastName, string customer_Email,
                                string password, string day,string moth,string year,string address, 
                                string city,string state,string postcode,string phone,string alias)
        {
            switch (gender)
            {
                case "Male":
                    ClickGenderMale();
                    break;
                case "Female":
                    ClickGenderFemale();
                    break;
            }
            Keyword.SetText(Txt_CustomerFirstName, customerFirstName);
            Keyword.SetText(Txt_CustomerLastName, customerLastName);
            Keyword.SetText(Txt_Customer_Email, customer_Email);
            Keyword.SetText(Txt_Password, password);
            Keyword.ConvertAndSelectElementByValue(Sl_Day, day);
            Keyword.ConvertAndSelectElementByValue(Sl_Month, moth);
            Keyword.ConvertAndSelectElementByValue(Sl_Year, year);
            Keyword.SetText(Txt_Address, address);
            Keyword.SetText(Txt_City, city);
            Keyword.ConvertAndSelectElementByValue(Sl_State, state);
            Keyword.SetText(Txt_Postcode, postcode);
            Keyword.SetText(Txt_MobilePhone, phone);
            Keyword.SetText(Txt_Alias, alias);
            
        }

        public MyAccountPage SubmitRegistration()
        {
            Keyword.Click(Btn_Register);
            return new MyAccountPage(Driver);
        }
    }
}
