using POM_Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyenLLP_FinalTest.Pages
{
    public class DetailProductPage : PageBase
    {
        public string addToCartXpath = "//*[@id='add_to_cart']//button";
        public string checkOutBtn = "//a[@class='btn btn-default button button-medium']";
        public string continueXpath = "//span[@title='Continue shopping']";

        /// <summary>
        /// Click the Add To Cart button
        /// </summary>
        public void ClickBtnAddToCart() => BrowserFactory.ClickElenmentByJS(addToCartXpath);
        /// <summary>
        /// Click Check Out button
        /// </summary>
        public void ClickCheckOutBtn() => BrowserFactory.ClickElenmentByJS(checkOutBtn);
        /// <summary>
        /// Click Continue button on popup
        /// </summary>
        public void ClickContinue() => BrowserFactory.ClickElenmentByJS(continueXpath);

    }
}
