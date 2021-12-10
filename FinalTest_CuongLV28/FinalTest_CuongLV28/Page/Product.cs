using System;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class Product : BasePage
    {
        public Product(IWebDriver driver) : base(driver)
        {

        }
        IWebElement BtnAddtoCart => Driver.FindElement(By.XPath("//a[@href='http://automationpractice.com/index.php?controller=cart&add=1&id_product=3&token=6b971ec41efac92e24b5e06681343835']"));
        IWebElement BtnProceedCheckout => Driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));

        public void AddProduct()
        {
            BtnAddtoCart.Click();
            BtnProceedCheckout.Click();
        }
    }
}
