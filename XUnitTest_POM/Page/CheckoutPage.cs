using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base() { }

        IWebElement ProceedCheckoutBtn => BrowserFactory.FindElement("//p//a[@title='Proceed to checkout']");
        IWebElement ProceedAddressBtn => BrowserFactory.FindElement("//button[@name='processAddress']");
        IWebElement TermAndConditionCheckbox => BrowserFactory.FindElement("//label[@for='cgv']");
        IWebElement ProceedShippingBtn => BrowserFactory.FindElement("//button[@name='processCarrier']");
        IWebElement ProceedPaymentBtn => BrowserFactory.FindElement("//a[@title='Pay by bank wire']");
        IWebElement ConfirmBtn => BrowserFactory.FindElement("//p[@id='cart_navigation']//button");
        IWebElement TxtCheckoutSuccess => BrowserFactory.FindElement("//h3[@class='page-subheading']");
        
        /// <summary>
        /// Check out Step1. Summary
        /// </summary>
        public void CheckoutSummary()
        {
            BrowserFactory.ClickElement(ProceedCheckoutBtn);
        }

        /// <summary>
        /// Check out Step3. Address
        /// </summary>
        public void CheckoutAddress()
        {
            BrowserFactory.ClickElement(ProceedAddressBtn);
        }

        /// <summary>
        /// Check out Step4. Shipping
        /// </summary>
        public void CheckoutShipping()
        {
            BrowserFactory.ClickElement(TermAndConditionCheckbox);
            BrowserFactory.ClickElement(ProceedShippingBtn);
        }

        /// <summary>
        /// Check out Step5. Payment
        /// </summary>
        public void CheckoutPayment()
        {
            BrowserFactory.ClickElement(ProceedPaymentBtn);
        }

        /// <summary>
        /// Comfirm Payment 
        /// </summary>
        public void ConfirmPayment()
        {
            BrowserFactory.ClickElement(ConfirmBtn);
        }

        /// <summary>
        /// Verify your Checkout
        /// </summary>
        public bool VerifyCheckout => BrowserFactory.GetText(TxtCheckoutSuccess).Equals("BANK-WIRE PAYMENT.");
    }
}
