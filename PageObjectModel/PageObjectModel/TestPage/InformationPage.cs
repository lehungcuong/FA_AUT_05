using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModel.TestPage
{
    public class InformationPage : BasePage
    {
        

        public InformationPage(IWebDriver driver) : base(driver)
        {
        }
        // personal information 
        IWebElement InFirstName => Driver.FindElement(By.XPath("//input[@name='firstname']"));
        IWebElement InLastName => Driver.FindElement(By.XPath("//input[@name='lastname']"));
        IWebElement InpEmail => Driver.FindElement(By.XPath("//input[@name='email']"));
        IWebElement InpPhone => Driver.FindElement(By.XPath("//input[@name='phone']"));
        IWebElement InpAddress => Driver.FindElement(By.XPath("//input[@name='address']"));
        SelectElement SelectCountry => new SelectElement(Driver.FindElement(By.XPath("//select[@name='country_code']")));
        SelectElement SelectNation => new SelectElement(Driver.FindElement(By.XPath("//select[@name='nationality']")));

        // Traveler information

        SelectElement SelectTitle => new SelectElement(Driver.FindElement(By.XPath("//select[@name='title_1']")));
        IWebElement InputFirstName => Driver.FindElement(By.XPath("//input[@name='firstname_1']"));
        IWebElement InputLastName => Driver.FindElement(By.XPath("//input[@name='lastname_1']"));
        SelectElement SelectNation_1 => new SelectElement(Driver.FindElement(By.XPath("//select[@name='nationality_1']")));
        SelectElement SelectMonth => new SelectElement(Driver.FindElement(By.XPath("//select[@name='dob_month_1']")));
        IWebElement Selectday => Driver.FindElement(By.XPath("//input[@name='dob_day_1']"));
        IWebElement SelectYear => Driver.FindElement(By.XPath("//input[@name='dob_year_1']"));

        // Passport

        IWebElement InpPassport => Driver.FindElement(By.XPath("//input[@name='passport_1']"));
        SelectElement SelectMonth_1 => new SelectElement(Driver.FindElement(By.XPath("//select[@name='passport_issuance_month_1']")));
        IWebElement Selectday_1 => Driver.FindElement(By.XPath("//input[@name='passport_issuance_day_1']"));
        IWebElement SelectYear_1 => Driver.FindElement(By.XPath("//input[@name='passport_issuance_year_1']"));
        SelectElement SelectMonth_2 => new SelectElement(Driver.FindElement(By.XPath("//select[@name='passport_month_1']")));
        IWebElement Selectday_2 => Driver.FindElement(By.XPath("//input[@name='passport_day_1']"));
        IWebElement SelectYear_2 => Driver.FindElement(By.XPath("//input[@name='passport_year_1']"));

        // payment

        IWebElement RadioPaymentMethod => Driver.FindElement(By.XPath("//div[@class='col-md-4 mb-1 gateway_bank-transfer']/div"));

        /// Terms and conditions
        ///

        IWebElement checkboxConfirm => Driver.FindElement(By.XPath("//*[@id='agreechb']/parent::div/parent::div"));

        // Confirm button
        IWebElement BtnConfirm => Driver.FindElement(By.XPath("//button[@id='booking']"));

        public void InputInformation()
        {
            InFirstName.SendKeys("Le");
            InLastName.SendKeys("Cuong");
            InpEmail.SendKeys("cuonglv@live.com");
            InpPhone.SendKeys("0909090909");
            InpAddress.SendKeys("22 Nam Ky Khoi Nghia,Ho Chi Minh city");
            SelectCountry.SelectByText("Viet Nam");
            SelectNation.SelectByText("Viet Nam");
            SelectTitle.SelectByText("MR");
            InputFirstName.SendKeys("Le");
            InputLastName.SendKeys("Cuong");
            SelectNation_1.SelectByText("Viet Nam");
            SelectMonth.SelectByText("02 February");
            Selectday.SendKeys("15");
            SelectYear.SendKeys("1996");
            InpPassport.SendKeys("03032894829");
            SelectMonth_1.SelectByText("07 July");
            Selectday_1.SendKeys("29");
            SelectYear_1.SendKeys("2020");
            SelectMonth_2.SelectByText("07 July");
            Selectday_2.SendKeys("10");
            SelectYear_2.SendKeys("2024");
            RadioPaymentMethod.Click();
            checkboxConfirm.Click();
            BtnConfirm.Submit();
        }

        public void Scrolldown()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            jse.ExecuteScript("scroll(0, 3000);");
            Thread.Sleep(5000);
        }


    }
}
