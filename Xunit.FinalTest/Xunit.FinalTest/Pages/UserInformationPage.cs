using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class UserInformationPage : BasePage
    {
        public UserInformationPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement txtFirstname => BrowserFactory.FindElement(By.XPath("//input[@id='firstname']"));
        private IWebElement txtLastname => BrowserFactory.FindElement(By.XPath("//input[@id='lastname']"));
        private IWebElement txtEmail => BrowserFactory.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement selectedDayOfBirth => BrowserFactory.FindElement(By.XPath("//select[@id='days']/option[@selected='selected']"));
        private IWebElement selectedMonthOfBirth => BrowserFactory.FindElement(By.XPath("//select[@id='months']/option[@selected='selected']"));
        private IWebElement selectedYearOfBirth => BrowserFactory.FindElement(By.XPath("//select[@id='years']/option[@selected='selected']"));


        //Actions
        public bool ValidateUserInformation(string firstname, string lastname, string email, string dob)
        {
            var _split = dob.Split('/');
            if (txtFirstname.GetAttribute("value") != firstname)
            { 
                if (txtLastname.GetAttribute("value") != lastname)
                {
                    if (txtEmail.GetAttribute("value") != email)
                    {
                        if (selectedDayOfBirth.GetAttribute("value") != _split[0])
                        {
                            if (selectedMonthOfBirth.GetAttribute("value") != _split[1])
                            {
                                if (selectedYearOfBirth.GetAttribute("value") != _split[2])
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
