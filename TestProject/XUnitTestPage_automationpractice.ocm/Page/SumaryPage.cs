using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class SumaryPage : BasePage
    {
        public SumaryPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Btn_ProceedToCheck => Keyword.FindElement(By.XPath("//*[@class='button btn btn-default standard-checkout button-medium']"));

        public SumaryPage clickOnProceedToCheck()
        {
            Keyword.Click(Btn_ProceedToCheck);
            return new SumaryPage(Driver);
        }
    }
}
