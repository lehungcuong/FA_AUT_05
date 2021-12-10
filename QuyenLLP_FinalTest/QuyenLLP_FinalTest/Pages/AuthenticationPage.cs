using POM_Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuyenLLP_FinalTest.Pages
{
    public class AuthenticationPage : PageBase
    {
        public string emailCreateXpath = "//*[@id='email_create']";
        public string createButton = "//*[@id='SubmitCreate']";
        public string emailXpath = "//*[@id='email']";
        public string passXpath = "//*[@id='passwd']";
        public string signinBtnXpath = "//*[@id='SubmitLogin']";
        public void SendEmailCreate() => BrowserFactory.SendValue(emailCreateXpath, "quyen12345@gmail.com");
        public void SendEmailLogin() => BrowserFactory.SendValue(emailXpath, "lelamphuongquyen@gmail.com");
        public void SendPassLogin() => BrowserFactory.SendValue(passXpath, "123456");

        /// <summary>
        /// Click On Create Button 
        /// </summary>
        public void ClickOnCreateButton()
        {
            BrowserFactory.ClickElenment(createButton);
            Thread.Sleep(10000);
        }

        /// <summary>
        /// Click On Sign Button
        /// </summary>
        public void ClickOnSignBtn() => BrowserFactory.ClickElenment(signinBtnXpath);

        /// <summary>
        /// Assert Title on Login - My Store
        /// </summary>
        /// <returns></returns>
        public bool AssertTitle()
        {
            return BrowserFactory.AsstertTitlePage("Login - My Store");
        }

    }
}
