using POM_Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyenLLP_FinalTest.Pages
{
    public class CreateAccountPage : PageBase
    {
        #region xpath in YOUR PERSONAL INFORMATION form
        public string firstNamePersonalXpath = "//*[@id='customer_firstname']";
        public string lastNamePersonalXpath = "//*[@id='customer_lastname']";
        public string passwordPersonalXpath = "//*[@id='passwd']";
        #endregion
        #region xpath in YOUR ADDRESS form
        public string firstNameAddressXpath = "//*[@id='firstname']";
        public string lastNameAddressXpath = "//*[@id='lastname']";
        public string addressXpath = "//*[@id='address1']";
        public string cityXpath = "//*[@id='city']";
        public string stateXpath = "//*[@id='id_state']";
        public string postCodeXpath = "//*[@id='postcode']";
        public string phoneMobileXpath = "//*[@id='phone_mobile']";
        public string registerBtnXpath = "//*[@id='submitAccount']";
        #endregion

        /// <summary>
        /// Write Infomation in the Create Account page
        /// </summary>
        /// <param name="firstNamePersonal"></param>
        /// <param name="lastNamePersonal"></param>
        /// <param name="password"></param>
        /// <param name="firstNameAddress"></param>
        /// <param name="lastNameAddress"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="code"></param>
        /// <param name="phone"></param>
        public void WriteInfomation(string firstNamePersonal, string lastNamePersonal, string password, 
                                     string firstNameAddress, string lastNameAddress, string address,
                                        string city, string state, string code, string phone)
        {
            BrowserFactory.SendValue(firstNamePersonalXpath, firstNamePersonal);
            BrowserFactory.SendValue(lastNamePersonalXpath, lastNamePersonal);
            BrowserFactory.SendValue(passwordPersonalXpath, password);
            BrowserFactory.SendValue(firstNameAddressXpath, firstNameAddress);
            BrowserFactory.SendValue(lastNameAddressXpath, lastNameAddress);
            BrowserFactory.SendValue(addressXpath, address);
            BrowserFactory.SendValue(cityXpath, city);
            BrowserFactory.SelectValueInDropDown(stateXpath, state);
            BrowserFactory.SendValue(postCodeXpath, code);
            BrowserFactory.SendValue(phoneMobileXpath, phone);
            BrowserFactory.ClickElenment(registerBtnXpath);

        }
    }
}
