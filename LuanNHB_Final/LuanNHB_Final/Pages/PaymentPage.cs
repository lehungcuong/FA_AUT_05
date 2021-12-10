using OpenQA.Selenium;
using WebDriverFactory;

namespace LuanNHB_Final.Pages
{
    class PaymentPage : BasePage
    {
        public PaymentPage(IWebDriver driver) : base()
        {
        }

        IWebElement BtnPaymentByBank => BrowserFactory.SetWebElement("//p[contains(@Class,'payment_module')]/a[contains(@title,'bank wire')]");

        IWebElement BtnPaymentByCheck => BrowserFactory.SetWebElement("//p[contains(@Class,'payment_module')]/a[contains(@title,'check')]");

        public void ChooseBankPayment() => BrowserFactory.Click(BtnPaymentByBank);

        public void ChooseCheckPayment() => BrowserFactory.Click(BtnPaymentByCheck);
    }
}
