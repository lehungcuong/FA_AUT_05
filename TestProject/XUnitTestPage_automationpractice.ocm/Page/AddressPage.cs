﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class AddressPage : BasePage
    {
        public AddressPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Btn_ProceedToCheckout => Keyword.FindElement(By.XPath("//*[@class='button btn btn-default button-medium']"));
        public void ClickProceedToCheckout()
        {
            Keyword.Click(Btn_ProceedToCheckout);
        }
    }
}
