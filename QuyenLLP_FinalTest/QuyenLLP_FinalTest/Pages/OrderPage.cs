using POM_Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyenLLP_FinalTest.Pages
{
    public class OrderPage : PageBase
    {
        public string processToCheckOut = "//p[@class='cart_navigation clearfix']//a[@title='Proceed to checkout']";
        public string processAddressBtn ="//button[@name='processAddress']";
        public string processCarrierBtn = "//button[@name='processCarrier']";
        public string termCheckBox = "//label[@for='cgv']";

        /// <summary>
        /// Click the Process Address button 
        /// </summary>
        public void ClickProcessAddressBtn()
        {
            BrowserFactory.ClickElenmentByJS(processAddressBtn);
            
        }
        /// <summary>
        /// Click on the Process Carrier button
        /// </summary>
        public void ClickProcessCarrierBtn() => BrowserFactory.ClickElenmentByJS(processCarrierBtn);
        /// <summary>
        /// Click on the Term Checkbox 
        /// </summary>
        public void ClickTermCheckBox() => BrowserFactory.ClickElenmentByJS(termCheckBox);
        /// <summary>
        /// Click the Process To CheckOut button
        /// </summary>
        public void ClickProcessToCheckOutBtn() => BrowserFactory.ClickElenmentByJS(processToCheckOut);
    }
}
