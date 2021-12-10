using OpenQA.Selenium;

namespace Auto.Page
{
    public class SumaryPage : BasePage
    {
        public SumaryPage(IWebDriver driver) : base(driver)
        {

        }
        //Element 
        IWebElement btnProcessToCheckout => pageHelper.FindElement(By.XPath("//p[@class='cart_navigation clearfix']//span"));
        IWebElement title => pageHelper.FindElement(By.XPath("//li[@class='step_current  first']/span"));
        /// <summary>
        /// Click buttton Process To Checkout in Sumary Page
        /// </summary>
        public void ClickButtonProcessToCheckOut()
        {
            pageHelper.ClickJSEL(btnProcessToCheckout);
        }
        public bool VerifyGotoSummaryPage()
        {
            return pageHelper.ValidateWebTitle("01. Summary", title) ? true : false;
        }

    }
}
