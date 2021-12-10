using BrowserFactory;
using OpenQA.Selenium;
using System.Threading;

namespace Final.Pages
{
    public class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver) { }

        IWebElement btnProceedToCheckout => BrowsersFactory.Get("//a[@class='button btn btn-default standard-checkout button-medium']");
        IWebElement btnProceedToCheckoutAddress => BrowsersFactory.Get("//button[@name='processAddress']");
        IWebElement chbTermOfService => BrowsersFactory.Get("Id:cgv");
        IWebElement btnProceddToCheckoutShipping => BrowsersFactory.Get("//button[@name='processCarrier']");
        IWebElement btnBankWire => BrowsersFactory.Get("//a[@class='bankwire']");
        IWebElement btnConfirmOrder => BrowsersFactory.Get("//button[@class='button btn btn-default button-medium']");
        IWebElement lblOrderComplete => BrowsersFactory.Get("//p[@class='cheque-indent']/strong");

        public void ProceedToCheckout()
        {
            BrowsersFactory.ClickElement(btnProceedToCheckout);
        }

        public void ProceedToCheckoutAddress()
        {
            BrowsersFactory.ClickElement(btnProceedToCheckoutAddress);
        }

        public void AgreeTerm()
        {
            BrowsersFactory.ClickElementJS(Driver, chbTermOfService);
        }

        public void ProceedToCheckoutShipping()
        {
            BrowsersFactory.ClickElement(btnProceddToCheckoutShipping);
        }

        public void ChoosePaymentMethod()
        {
            BrowsersFactory.ClickElement(btnBankWire);
        }

        public void ConfirmOrder()
        {
            BrowsersFactory.ClickElement(btnConfirmOrder);
        }

        public void VerifyOrderCompleted(string text)
        {
            BrowsersFactory.AssertElementText(lblOrderComplete, text);
        }
    }
}
