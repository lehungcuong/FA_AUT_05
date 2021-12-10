using OpenQA.Selenium;

namespace Auto.Page
{
    public class AccountPage : BasePage
    {
        /// <summary>
        /// Contructpr Account Page
        /// </summary>
        /// <param name="driver"></param>
        public AccountPage(IWebDriver driver) : base(driver)
        {

        }
        //Element
        IWebElement radioTitle => Driver.FindElement(By.XPath("//input[@id ='id_gender2']"));
        IWebElement txtFirstName => pageHelper.FindElement(By.XPath("//input[@id ='customer_firstname']"));
        IWebElement txtLastName => pageHelper.FindElement(By.XPath("//input[@id ='customer_lastname']"));
        IWebElement txtPassword => pageHelper.FindElement(By.XPath("//input[@id ='passwd']"));

        string dropDay = "//select[@id='days']";
        string drpMonth = "//select[@id='months']";
        string drpYear = "//select[@id='years']";
        IWebElement labelSingup => pageHelper.FindElement(By.XPath("//label[text()='Sign up for our newsletter!']"));
        IWebElement txtCompany => pageHelper.FindElement(By.XPath("//input[@id='company']"));
        IWebElement txtAddress => pageHelper.FindElement(By.XPath("//input[@id='address1']"));
        IWebElement txtCity => pageHelper.FindElement(By.XPath("//input[@id='city']"));
        string drpState = "//select[@id='id_state']";
        IWebElement drpZip_PostalCode => pageHelper.FindElement(By.XPath("//input[@id='postcode']"));
        IWebElement txtMobilePhone => pageHelper.FindElement(By.XPath("//input[@id='phone_mobile']"));
        IWebElement btnRegister => pageHelper.FindElement(By.XPath("//span[text()='Register']"));
        IWebElement title => pageHelper.FindElement(By.XPath("//h3[@class='page-subheading' and text()='Your personal information']"));
        /// <summary>
        /// Input Infomation Account
        /// </summary>
        public void InputInfomationAccount()
        {
            //Click on radio Title
            pageHelper.ClickJSEL(radioTitle);
            //Click and send key textbox FirstName
            pageHelper.ClickJSEL(txtFirstName);
            pageHelper.SenkeyEL(txtFirstName, "Hien");
            //Click and send key textbox LastName
            pageHelper.ClickJSEL(txtLastName);
            pageHelper.SenkeyEL(txtLastName, "Nguyen");
            //Click and send key textbox Password
            pageHelper.ClickJSEL(txtPassword);
            pageHelper.SenkeyEL(txtPassword, "12345");
            //select by Value dropdown Day            
            pageHelper.SelectELByValue(dropDay, "19");
            //select by Value dropdown Month   
            pageHelper.SelectELByValue(drpMonth, "9");
            //select by Value dropdown Year 
            pageHelper.SelectELByValue(drpYear, "1999");
            //Click label Sign up
            pageHelper.ClickJSEL(labelSingup);
            //Click and send key textbox Company
            pageHelper.ClickJSEL(txtCompany);
            pageHelper.SenkeyEL(txtCompany, "FPT");
            //Click and send key textbox Address
            pageHelper.ClickJSEL(txtAddress);
            pageHelper.SenkeyEL(txtAddress, "Quan 9");
            //Click and send key textbox City
            pageHelper.ClickJSEL(txtCity);
            pageHelper.SenkeyEL(txtCity, "TP HCM");
            //select by Value dropdown State
            pageHelper.SelectELByValue(drpState, "15");
            //select by Value dropdown zip Postal Code
            pageHelper.ClickJSEL(drpZip_PostalCode);
            pageHelper.SenkeyEL(drpZip_PostalCode, "63000");
            //Click and send key textbox Mobile Phone
            pageHelper.ClickJSEL(txtMobilePhone);
            pageHelper.SenkeyEL(txtMobilePhone, "0971214034");
            //Click button Register
            pageHelper.ClickJSEL(btnRegister);
        }
        public bool VerifyTitle()
        {
            return pageHelper.ValidateWebTitle("YOUR PERSONAL INFORMATION", title) ? true : false;
        }
    }
}
