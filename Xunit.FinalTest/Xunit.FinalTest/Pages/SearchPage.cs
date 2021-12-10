using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement selectSort => Driver.FindElement(By.XPath("//select[@id='selectProductSort']"));
        private IList<IWebElement> afterSearchList => Driver.FindElements(By.XPath("//ul//div[@class='right-block']//span[@class='price product-price']"));
        
        //Actions
        public bool IsSortCorrectly()
        {
            BrowserFactory.select(selectSort, DriverFactory.SelectType.SELECT_BY_VALUE, "price:desc");
            Thread.Sleep(2500);
            if (afterSearchList[2].Text == "$28.98")
            {
                return true;
            } return false; 
        }

    }
}