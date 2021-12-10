using OpenQA.Selenium;

namespace Auto.Page
{
    public class AddressPage : BasePage
    {

        public AddressPage(IWebDriver driver) : base(driver)
        {

        }
        //element
        IWebElement btnProccessToCheckout => pageHelper.FindElement(By.XPath("//button[@name='processAddress']/span"));
        IWebElement title => pageHelper.FindElement(By.XPath("//li[@class='step_current third']/span"));
        public void ClickBtnProccessToCheckout()
        {
            pageHelper.ClickJSEL(btnProccessToCheckout);
        }
        public bool VerifyAddressPage()
        {
            return pageHelper.ValidateWebTitle("03. Address", title) ? true : false;
        }

    }
}
