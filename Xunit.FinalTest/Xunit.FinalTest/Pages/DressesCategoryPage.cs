using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriver;

namespace Xunit.FinalTest.Pages
{
    public class DressesCategoryPage : BasePage
    {
        public DressesCategoryPage(IWebDriver driver) : base(driver) { }

        //Elements
        private IWebElement txtTitleFirstPrintedDress => BrowserFactory.FindElement(By.XPath("(//ul[@class='product_list grid row']//h5//a[@title='Printed Dress'])[1]"));
        private IWebElement txtTitleFirstPrintedSummerDress => BrowserFactory.FindElement(By.XPath("(//ul[@class='product_list grid row']//h5//a[@title='Printed Summer Dress'])[1]"));
        private IWebElement txtTitlePrintedChiffonDress => BrowserFactory.FindElement(By.XPath("(//ul[@class='product_list grid row']//h5//a[@title='Printed Chiffon Dress'])"));

        //Actions
        public ProductDetailPage ChooseProduct(string productname)
        {
            if ( productname == "Printed Dress" )
            {
                BrowserFactory.JsClick(txtTitleFirstPrintedDress);
            }
            else if ( productname == "Printed Summer Dress" )
            {
                BrowserFactory.JsClick(txtTitleFirstPrintedSummerDress);
            }
            else if ( productname == "Printed Chiffon Dress")
            {
                BrowserFactory.JsClick(txtTitlePrintedChiffonDress);
            }

            return new ProductDetailPage(Driver);
        }

    }
}
