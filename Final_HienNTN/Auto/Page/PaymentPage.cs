using OpenQA.Selenium;

namespace Auto.Page
{
    public class PaymentPage : BasePage
    {
        public PaymentPage(IWebDriver driver) : base(driver)
        {
        }
        //element
        IWebElement btnPayByBankWire => pageHelper.FindElement(By.XPath("//a[@title='Pay by bank wire']"));
        IWebElement btnIConfirm => pageHelper.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']/span"));
        IWebElement title => Driver.FindElement(By.XPath("//li[@id='step_end']/span"));
        /// <summary>
        /// Click buttton Process To Checkout in Payment Page
        /// </summary>
        public void ClickConFirmMyOrder()
        {
            //Click button Pay By BankWire
            pageHelper.ClickJSEL(btnPayByBankWire);
            //click Button Confirm
            pageHelper.ClickJSEL(btnIConfirm);
        }
        public bool VerifyPaymentPage()
        {
            return pageHelper.ValidateWebTitle("05. Payment", title) ? true : false;
        }
    }
}
