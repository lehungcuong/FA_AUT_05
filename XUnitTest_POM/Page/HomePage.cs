using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    public class HomePage : BasePage
    {
        public HomePage (IWebDriver driver) : base() { }

        #region Elements on HomePage
        IWebElement LoginBtn => BrowserFactory.FindElement("//a[contains(@title,'Log in')]");
        IWebElement FirstProduct => BrowserFactory.FindElement("(//h5//a[contains(@title,'Faded')])[1]");
        IWebElement SecondProduct => BrowserFactory.FindElement("(//h5//a[contains(@title,'Blouse')])[1]");
        IWebElement ThirdProduct => BrowserFactory.FindElement("(//h5//a[contains(@title,'Chiffon')])[1]");
        IWebElement ShoppingCart => BrowserFactory.FindElement("//a[contains(@title,'shopping cart')]");
        IWebElement LogoBtn => BrowserFactory.FindElement("//a[@title='My Store']");
        #endregion

        /// <summary>
        /// Verify HomePage Title
        /// </summary>
        public bool VerifyHomePage => BrowserFactory.GetTitle().Equals("My Store");

        public void ClickHomePage()
        {
            BrowserFactory.ClickElement(LogoBtn);
        }

        /// <summary>
        /// Click on Flights page
        /// </summary>
        public void ClickLoginPage()
        {
            BrowserFactory.ClickElement(LoginBtn);
        }

        /// <summary>
        /// Click on First Product
        /// </summary>
        public void ClickFristProduct()
        {
            BrowserFactory.ClickElement(FirstProduct);
        }

        /// <summary>
        /// Click on Second Product
        /// </summary>
        public void ClickSecondProduct()
        {
            BrowserFactory.ClickElement(SecondProduct);
        }

        /// <summary>
        /// Click on Third Product
        /// </summary>
        public void ClickThirdProduct()
        {
            BrowserFactory.ClickElement(ThirdProduct);
        }

        /// <summary>
        /// Click on Shopping Card
        /// </summary>
        public void ClickShoppingCard()
        {
            BrowserFactory.ClickElement(ShoppingCart);
        }

        /// <summary>
        /// Click on logo navigate to Homepage
        /// </summary>
        public void ClickLogo()
        {
            BrowserFactory.ClickElement(LogoBtn);
        }
    }
}
