using DriverFactory;
using LoiDV4_Final.Common;
using OpenQA.Selenium;
using System.Threading;

namespace LoiDV4_Final.Page
{
    public class HomePage : BasePage
    {
        public HomePage(BrowserFactory browser) : base(browser)
        {
        }

        #region page elements
        private IWebElement btnSignIn = BrowserFactory.Driver.FindElement(By.XPath("//a[@class='login']"));
        #endregion

        #region page actions
        /// <summary>
        /// Login to system
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public MyAccountPage Login()
        {
            // CLick "sign in" menu
            WebKeywords.Click(btnSignIn);

            // Enter email address
            IWebElement txtEmailLogin = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='email']"));
            WebKeywords.SetText(txtEmailLogin, "vanloi@gmail.com");

            // Enter password
            IWebElement txtPassword = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='passwd']"));
            WebKeywords.SetText(txtPassword, "300796");

            // Click "Sign in" button to login
            IWebElement btnSubmitLogin = BrowserFactory.Driver.FindElement(By.XPath("//button[@id='SubmitLogin']"));
            WebKeywords.Click(btnSubmitLogin);

            return new MyAccountPage(browser);
        }



        /// <summary>
        /// Login to system with data driven
        /// </summary>
        /// <returns></returns>
        public MyAccountPage LoginWithDataDriven(string email, string password)
        {
            // CLick "sign in" menu
            WebKeywords.Click(btnSignIn);

            // Enter email address
            IWebElement txtEmailLogin = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='email']"));
            WebKeywords.SetText(txtEmailLogin, email);

            // Enter password
            IWebElement txtPassword = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='passwd']"));
            WebKeywords.SetText(txtPassword, password);

            // Click "Sign in" button to login
            IWebElement btnSubmitLogin = BrowserFactory.Driver.FindElement(By.XPath("//button[@id='SubmitLogin']"));
            WebKeywords.Click(btnSubmitLogin);

            return new MyAccountPage(browser);
        }

        /// <summary>
        /// Create an account
        /// </summary>
        public MyAccountPage CreateAccount()
        {
            // CLick "sign in" menu
            WebKeywords.Click(btnSignIn);
            Thread.Sleep(2000);

            // Enter new email to create account
            IWebElement txtEmailCreate = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='email_create']"));
            WebKeywords.SetText(txtEmailCreate, "dvloi8@gmail.com");
            Thread.Sleep(2000);

            // Click "Create an account" to create account
            IWebElement btnCreateAnAccount  = BrowserFactory.Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));
            WebKeywords.Click(btnCreateAnAccount);
            Thread.Sleep(5000);

            // YOUR PERSONAL INFORMATION
            // Select Title for customer
            IWebElement rdoTitle = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='id_gender1']"));
            WebKeywords.Click(rdoTitle);
            Thread.Sleep(2000);

            // Enter fisrt name
            IWebElement txtFirstName = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='customer_firstname']"));
            WebKeywords.SetText(txtFirstName, "Loi");
            Thread.Sleep(2000);

            // Enter last name
            IWebElement txtLastName = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
            WebKeywords.SetText(txtLastName, "Dv");
            Thread.Sleep(2000);

            // Enter password
            IWebElement txtPassword = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='passwd']"));
            WebKeywords.SetText(txtPassword, "123456789");
            Thread.Sleep(2000);

            // YOUR ADDRESS
            // Enter address
            IWebElement txtAddress = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='address1']"));
            WebKeywords.SetText(txtAddress, "fpt hcm");
            Thread.Sleep(2000);

            // Enter city
            IWebElement txtCity = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='city']"));
            WebKeywords.SetText(txtCity, "hcm");
            Thread.Sleep(2000);

            // Select state
            IWebElement lblState = BrowserFactory.Driver.FindElement(By.XPath("//select[@id='id_state']"));
            WebKeywords.Select(lblState, WebKeywords.SelectType.SelectByIndex, "5");
            Thread.Sleep(2000);

            // Enter zip code
            IWebElement txtZipCode = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='postcode']"));
            WebKeywords.SetText(txtZipCode, "99999");
            Thread.Sleep(2000);

            // Select country
            IWebElement lblCountry = BrowserFactory.Driver.FindElement(By.XPath("//select[@id='id_country']"));
            WebKeywords.Select(lblState, WebKeywords.SelectType.SelectByValue, "21");
            Thread.Sleep(2000);

            // Enter mobile phone
            IWebElement txtMobilePhone = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='phone_mobile']"));
            WebKeywords.SetText(txtMobilePhone, "123456");
            Thread.Sleep(2000);

            // Enter Assign an address alias for future reference
            IWebElement txtAddressAlias = BrowserFactory.Driver.FindElement(By.XPath("//input[@id='alias']"));
            WebKeywords.SetText(txtAddressAlias, "hcm1");
            Thread.Sleep(2000);

            // Click "Register" button
            IWebElement btnRegister = BrowserFactory.Driver.FindElement(By.XPath("//button[@id='submitAccount']"));
            WebKeywords.Click(btnRegister);
            Thread.Sleep(2000);

            return new MyAccountPage(browser);
        }

        /// <summary>
        /// Scroll to element
        /// </summary>
        public void ScrollToElement()
        {
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)BrowserFactory.Driver;
            js2.ExecuteScript("scroll(0, 600);");
            Thread.Sleep(2000);

        }



        /// <summary>
        /// Order 1 product
        /// </summary>
        /// <returns></returns>
        public WomenPage ClickTabWomen()
        {
            Login();
            IWebElement tabWomen = BrowserFactory.Driver.FindElement(By.XPath("//a[@title='Women']"));
            WebKeywords.Click(tabWomen);
            Thread.Sleep(5000);

     
            IWebElement imgBlouse = BrowserFactory.Driver.FindElement(By.XPath("//img[@title='Blouse']"));
            ScrollToElement();
            WebKeywords.Click(imgBlouse);
            Thread.Sleep(10000);

            IWebElement btnAddToCart = BrowserFactory.Driver.FindElement(By.XPath("//*[@id='add_to_cart']/button/span"));
            WebKeywords.Click(btnAddToCart);
            Thread.Sleep(10000);

            IWebElement btnbtnProcced1 = BrowserFactory.Driver.FindElement(By.XPath("//*[@title='Proceed to checkout']"));
            WebKeywords.Click(btnbtnProcced1);
            Thread.Sleep(5000);

            IWebElement btnbtnProcced2 = BrowserFactory.Driver.FindElement(By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']//span[contains(text(),'Proceed to checkout')]"));
            ScrollToElement();
            WebKeywords.Click(btnbtnProcced2);
            Thread.Sleep(5000);

            IWebElement btnbtnProcced3 = BrowserFactory.Driver.FindElement(By.XPath("//button[@name='processAddress']"));
            ScrollToElement();
            WebKeywords.Click(btnbtnProcced3);
            Thread.Sleep(5000);

            IWebElement chkCgv = BrowserFactory.Driver.FindElement(By.XPath("//input[@type='checkbox']"));
            ScrollToElement();
            WebKeywords.Click(chkCgv);
            Thread.Sleep(5000);

            IWebElement btnSubmit = BrowserFactory.Driver.FindElement(By.XPath("//button[@name='processCarrier']"));
            ScrollToElement();
            WebKeywords.Click(btnSubmit);
            Thread.Sleep(5000);

            IWebElement btnPay = BrowserFactory.Driver.FindElement(By.XPath("//a[@title='Pay by check.']"));
            ScrollToElement();
            WebKeywords.Click(btnPay);
            Thread.Sleep(5000);

            IWebElement btnConfirm = BrowserFactory.Driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
            ScrollToElement();
            WebKeywords.Click(btnConfirm);
            Thread.Sleep(5000);




            return new WomenPage(browser);
        }


        /// <summary>
        /// Order 3 difference products
        /// </summary>
        /// <param name="pathProduct"></param>
        /// <returns></returns>
        public WomenPage ClickTabWomenWithDataDriven(string pathProduct)
        {
            Login();
            IWebElement tabWomen = BrowserFactory.Driver.FindElement(By.XPath("//a[@title='Women']"));
            WebKeywords.Click(tabWomen);
            Thread.Sleep(5000);


            IWebElement imgProduct = BrowserFactory.Driver.FindElement(By.XPath(pathProduct));
            ScrollToElement();
            WebKeywords.Click(imgProduct);
            Thread.Sleep(10000);

            IWebElement btnAddToCart = BrowserFactory.Driver.FindElement(By.XPath("//*[@id='add_to_cart']/button/span"));
            WebKeywords.Click(btnAddToCart);
            Thread.Sleep(10000);

            IWebElement btnbtnProcced1 = BrowserFactory.Driver.FindElement(By.XPath("//*[@title='Proceed to checkout']"));
            WebKeywords.Click(btnbtnProcced1);
            Thread.Sleep(5000);

            IWebElement btnbtnProcced2 = BrowserFactory.Driver.FindElement(By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']//span[contains(text(),'Proceed to checkout')]"));
            ScrollToElement();
            WebKeywords.Click(btnbtnProcced2);
            Thread.Sleep(5000);

            IWebElement btnbtnProcced3 = BrowserFactory.Driver.FindElement(By.XPath("//button[@name='processAddress']"));
            ScrollToElement();
            WebKeywords.Click(btnbtnProcced3);
            Thread.Sleep(5000);

            IWebElement chkCgv = BrowserFactory.Driver.FindElement(By.XPath("//input[@type='checkbox']"));
            ScrollToElement();
            WebKeywords.Click(chkCgv);
            Thread.Sleep(5000);

            IWebElement btnSubmit = BrowserFactory.Driver.FindElement(By.XPath("//button[@name='processCarrier']"));
            ScrollToElement();
            WebKeywords.Click(btnSubmit);
            Thread.Sleep(5000);

            IWebElement btnPay = BrowserFactory.Driver.FindElement(By.XPath("//a[@title='Pay by check.']"));
            ScrollToElement();
            WebKeywords.Click(btnPay);
            Thread.Sleep(5000);

            IWebElement btnConfirm = BrowserFactory.Driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
            ScrollToElement();
            WebKeywords.Click(btnConfirm);
            Thread.Sleep(5000);

            return new WomenPage(browser);
        }
        #endregion
    }
}
