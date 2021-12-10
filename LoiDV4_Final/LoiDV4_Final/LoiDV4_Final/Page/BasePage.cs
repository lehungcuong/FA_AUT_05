using DriverFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoiDV4_Final.Page
{
    public class BasePage
    {
        public BrowserFactory browser;
        public BasePage(BrowserFactory browser)
        {
            this.browser = browser;
        }


    }
}
