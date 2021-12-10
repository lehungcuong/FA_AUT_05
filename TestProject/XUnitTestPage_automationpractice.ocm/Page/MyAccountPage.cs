using OpenQA.Selenium;

namespace XUnitTestPage_automationpractice.com.Page
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public string AccountName => Keyword.FindElement(By.XPath("//*[@class='account']/span")).Text;
        public IWebElement Btn_TShirt => Keyword.FindElement(By.XPath("//li/ul/li/a[@title='T-shirts' and text()='T-shirts']"));
        public IWebElement Btn_Dress => Keyword.FindElement(By.XPath("//li/ul/li/a[@title='Dresses' and text()='Dresses']"));

        public bool CheckUsername(string actualName) => actualName.Equals(AccountName);
        /// <summary>
        /// click to redirect page
        /// </summary>
        /// <returns></returns>
        public TShirtPage ClickOnTShirt()
        {
            Keyword.ClickElementJS(Btn_TShirt);
            return new TShirtPage(Driver);
        }
    }
}
