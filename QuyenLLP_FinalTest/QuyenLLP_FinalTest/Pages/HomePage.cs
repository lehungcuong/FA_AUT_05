using OpenQA.Selenium;
using POM_Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyenLLP_FinalTest.Pages
{
    public class HomePage : PageBase
    {
        public string loginXpath = "//a[@class='login']";
        public string logoXpath = "//img[@class='logo img-responsive']";
        public string listProductXpath = ("//ul[@id='homefeatured']/li[1]/div[@class='product-container']//h5/a[@title='Faded Short Sleeve T-shirts']");
        public string productXpath = ("//ul[@id='homefeatured']//div[@class='product-container']//h5/a[@title='Blouse']");
       
        public string dressesXpath = "//ul[@class='submenu-container clearfix first-in-line-xs']//a[@title='Dresses']";
        public HomePage()
        {

        }

        /// <summary>
        /// Click Login button In Menu Home
        /// </summary>
        public void ClickLoginInMenuHome() => BrowserFactory.ClickElenment(loginXpath);

        /// <summary>
        /// Click On Logo in menu
        /// </summary>
        public void ClickOnLogo() => BrowserFactory.ClickElenmentByJS(logoXpath);

        /// <summary>
        /// Click Product on the home page
        /// </summary>
        public void ClickProductInList()
        {
            BrowserFactory.ClickElenmentByJS(listProductXpath);
        }
        /// <summary>
        /// Click Product on the home page
        /// </summary>
        public void ClickProduct()
        {
            BrowserFactory.ClickElenmentByJS(productXpath);
        }
       
       
    }
}
