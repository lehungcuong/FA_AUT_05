using OpenQA.Selenium;

namespace Auto.Page
{
    public class HomePage : BasePage
    {
        /// <summary>
        /// Constructor Home Page
        /// </summary>
        /// <param name="driver"></param>
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
        //Element
        IWebElement btnSingIn => pageHelper.FindElement(By.XPath("//a[@title='Log in to your customer account']"));
        IWebElement btnBestSeller => pageHelper.FindElement(By.XPath("//a[@class='blockbestsellers']"));
        IWebElement imgProduct1 => pageHelper.FindElement(By.XPath("//ul[@id='blockbestsellers']/li[1]//img"));
        IWebElement addToCatProduct => pageHelper.FindElement(By.XPath("(//div//a[@data-id-product='1'])[1]/span"));
        IWebElement btnCountinue => pageHelper.FindElement(By.XPath("//span[@title='Continue shopping']/span"));
        IWebElement imgProduct2 => pageHelper.FindElement(By.XPath("(//div//a[@data-id-product='2'])[1]/span"));
        IWebElement imgProduct3 => pageHelper.FindElement(By.XPath("(//div//a[@data-id-product='3'])[1]/span"));
        IWebElement btnProcess => pageHelper.FindElement(By.XPath("//a[@class='btn btn-default button button-medium']/span"));
        IWebElement title => pageHelper.FindElement(By.XPath("//span[@class='shop-phone']"));
        IWebElement img1 => pageHelper.FindElement(By.XPath("//ul[@id='homefeatured']//a[1]/img[@title='Faded Short Sleeve T-shirts']"));

        /// <summary>
        /// Click button Create an Account in Home Page
        /// </summary>
        public void ClickBtnCreateAnAccount()
        {
            pageHelper.ClickEL(btnSingIn);

        }
        /// <summary>
        /// Click Button Best Seller in Home Page
        /// </summary>
        public void ClickBtnBestSeller()
        {
            pageHelper.ClickJSEL(btnBestSeller);
            pageHelper.ClickJSEL(imgProduct1);
        }
        /// <summary>
        /// Click process add cart 3 product
        /// </summary>
        public void Click3Product()
        {
            //Click button Add To Cat product
            pageHelper.ClickJSEL(addToCatProduct);
            //Click button button Countiune
            pageHelper.ClickJSEL(btnCountinue);
            //Click img of Product 2
            pageHelper.ClickJSEL(imgProduct2);
            //Click button button Countiune
            pageHelper.ClickJSEL(btnCountinue);
            //Click img of Product 3
            pageHelper.ClickJSEL(imgProduct3);
            //Click button button Countiune
            pageHelper.ClickJSEL(btnProcess);

        }
        /// <summary>
        /// Click Product one in Home Pgae
        /// </summary>
        public void Click1Product()
        {
            pageHelper.ClickJSEL(img1);


        }
        /// <summary>
        /// Verify Go to Home Page succesfully
        /// </summary>
        /// <returns></returns>
        public bool VerifyGotoHomePage()
        {
            return pageHelper.ValidateWebTitle("Call us now: 0123-456-789", title) ? true : false;
        }

    }
}
