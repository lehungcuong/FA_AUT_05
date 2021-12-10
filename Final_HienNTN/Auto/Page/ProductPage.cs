using OpenQA.Selenium;
using System.Threading;

namespace Auto.Page
{
    public class ProductPage : BasePage
    {

        public ProductPage(IWebDriver driver) : base(driver)
        {

        }
        //Element
        string size = "//select[@id='group_1']";
        IWebElement textColor => pageHelper.FindElement(By.XPath("//a[@id='color_16']"));
        IWebElement btnAddToCard => pageHelper.FindElement(By.XPath("//p[@id='add_to_cart']/button"));
        IWebElement btnProcessToCheckout => pageHelper.FindElement(By.XPath("//a[@class='btn btn-default button button-medium']/span"));
        IWebElement txtSendToAFriend => pageHelper.FindElement(By.XPath("//a[@id='send_friend_button']"));
        IWebElement txtNameOfYourFriend => pageHelper.FindElement(By.XPath("//input[@id='friend_name']"));
        IWebElement txtEmailAddressOfYourfriend => pageHelper.FindElement(By.XPath("//input[@id='friend_email']"));
        IWebElement btnSend => pageHelper.FindElement(By.XPath("//button[@id='sendEmail']/span"));
        /// <summary>
        /// Method click Add to card in Product Page
        /// </summary>
        public void ClickAddToCard()
        {
            pageHelper.SelectELByValue(size, "2");
            pageHelper.ClickJSEL(textColor);
            pageHelper.ClickJSEL(btnAddToCard);
            pageHelper.ClickJSEL(btnProcessToCheckout);
            Thread.Sleep(5000);
        }
        public void ClickSendToFriend()
        {
            //Click Send ToA Friend
            pageHelper.ClickJSEL(txtSendToAFriend);
            //Click and send key text box Name Of Your Friend
            pageHelper.ClickJSEL(txtNameOfYourFriend);
            pageHelper.SenkeyEL(txtNameOfYourFriend, "Thao");
            //Click and send key text box Email Address Of Your friend
            pageHelper.ClickJSEL(txtEmailAddressOfYourfriend);
            pageHelper.SenkeyEL(txtEmailAddressOfYourfriend, "abcdef@def.com");
            //Click button Send
            pageHelper.ClickJSEL(btnSend);


        }

    }
}
