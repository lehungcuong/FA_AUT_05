using System.Threading;
using OpenQA.Selenium;

namespace QuangTD20_Final.Pages
{
   class Buyproduct : BasePase
    {
      
        public Buyproduct(IWebDriver driver) : base(driver)
        {
           
        }
        private IWebElement seachproduct => Driver.FindElement(By.XPath("//input[@name='search_query']"));
        private IWebElement buttonseach => Driver.FindElement(By.XPath("//button[@name='submit_search']"));
        //img[@src='http://automationpractice.com/img/p/2/0/20-home_default.jpg']
        private IWebElement chiffondress => Driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[1]/div/div[1]/div/a[1]/img"));
        private IWebElement summerdress => Driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[2]/div/div[1]/div/a[1]/img"));
        //*[@id="add_to_cart"]/button/span
        //private IWebElement clickaddtocart => Driver.FindElement(By.XPath(" //*[@id='add_to_cart']/button/span"));
        private IWebElement clickaddtocart => Driver.FindElement(By.XPath("//*[@id='add_to_cart']/button/span")); ////*[@id='add_to_cart']/button/span
        private IWebElement continueshopping => Driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span/span"));
        ////*[@id='search_query_top']
        private IWebElement clickcheckout => Driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a"));
        private IWebElement clickblouse => Driver.FindElement(By.XPath("//*[@id='center_column']/ul/li/div/div[1]/div/a[1]/img"));
        private IWebElement proceedtocheckout => Driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]/span"));
        private IWebElement agree => Driver.FindElement(By.XPath("//*[@id='cgv']"));
        private IWebElement paybybank => Driver.FindElement(By.XPath("//*[@id='HOOK_PAYMENT']/div[1]/div/p/a"));
        private IWebElement confirmmyorder => Driver.FindElement(By.XPath("//*[@id='cart_navigation']/button/span"));
        public void Buy3product()
        {
            // Search chiffon dress
            ClassFunction.WebElementinput(seachproduct, "PRINTED CHIFFON DRESS");
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(buttonseach);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(chiffondress);
            Thread.Sleep(1000);
            ClassFunction.ScrollWindowBrowser(Driver, 100);
            ClassFunction.WebElementClick(clickaddtocart);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(continueshopping);
            // Search summer dress
            ClassFunction.ScrollWindowBrowser(Driver, 0);
            ClassFunction.WebElementinput(seachproduct, "PRINTED CHIFFON DRESS");
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(summerdress);
            Thread.Sleep(1000);
            ClassFunction.ScrollWindowBrowser(Driver, 100);
            ClassFunction.WebElementClick(clickaddtocart);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(continueshopping);
            Thread.Sleep(1000);
            ClassFunction.ScrollWindowBrowser(Driver, 0);
            // Search Blouse
            ClassFunction.WebElementinput(seachproduct, "Blouse");
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(clickblouse);
            Thread.Sleep(1000);
            ClassFunction.ScrollWindowBrowser(Driver, 100);
            ClassFunction.WebElementClick(clickaddtocart);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(clickcheckout);
            Thread.Sleep(1000);
            Payment();
           
        }

        public void Buy1product()
        {
            ClassFunction.ScrollWindowBrowser(Driver, 100);
            ClassFunction.WebElementinput(seachproduct, "PRINTED CHIFFON DRESS");
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(buttonseach);
            Thread.Sleep(1000);
            ClassFunction.WebElementClick(chiffondress);
            Thread.Sleep(1000);
            ClassFunction.ScrollWindowBrowser(Driver, 100);
            ClassFunction.WebElementClick(clickaddtocart);
            Thread.Sleep(5000);
            ClassFunction.WebElementClick(clickcheckout);
            Payment();
        }

        public void Payment()
        {
            // click proceed to checkout 1
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(proceedtocheckout);
            Thread.Sleep(1000);
            // click proceed to checkout 2
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(proceedtocheckout);
            Thread.Sleep(1000);
            // click proceed to checkout 3
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(proceedtocheckout);
            Thread.Sleep(1000);
            // click proceed to checkout 4
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(agree);
            ClassFunction.WebElementClick(proceedtocheckout);
            // click proceed to checkout 5
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(paybybank);
            ClassFunction.ScrollWindowBrowser(Driver, 200);
            ClassFunction.WebElementClick(confirmmyorder);

            Thread.Sleep(1000);

        }
    }
}
