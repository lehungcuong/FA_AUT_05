using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitTestPage_automationpractice.com.Utilities;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class TShirtPage : BasePage
    {
        public TShirtPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement FieldProduct => Keyword.FindElement(By.XPath("//*[@class='product_list grid row']"));

        public IList<IWebElement> TShirtProductList => Keyword.ParseToList(FieldProduct,By.XPath("//*[@class='product_list grid row']/li"));
        public IWebElement Btn_AddToCart => Keyword.FindElement(By.XPath("//*[@class='button ajax_add_to_cart_button btn btn-default']"));

        public IWebElement Btn_ProceedToCheckout => Keyword.FindElement(By.XPath("//*[@class='btn btn-default button button-medium']"));
        public string ProdcutQuantity => Keyword.FindElement(By.XPath("//*[@id='layer_cart_product_quantity']")).Text;
        public void addToCartAndCheckOut()
        {
            IList<IWebElement> productElements = TShirtProductList.ToList();
            Keyword.MoveToElementAndClick(productElements.First(),Btn_AddToCart);
        }

        public bool CheckQuantityIsOne => "1".Equals(ProdcutQuantity.Trim());
        
    }
}
