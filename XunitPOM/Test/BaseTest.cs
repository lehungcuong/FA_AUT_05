using System;
using Xunit;
using XunitPOM.Utilities;
using WebDriver;
using AventStack.ExtentReports;

namespace XunitPOM.Test
{
    public class BaseTest : IDisposable
    {
        public BrowserFactory browserFactory;
        public FactAttribute FactAttribute;
        public XunitHelper XunitHelper;

        public BaseTest()
        {
            // Create new driver and get config from configuaration file
            browserFactory = new BrowserFactory(ConfigHelper.GetValue("Driver"), ConfigHelper.GetValue("URL"));

            // Create new driver and get config from json file
            //browserFactory = new BrowserFactory(JsonHelper.GetValueByKeyConfig("Driver"), JsonHelper.GetValueByKeyConfig("URL"));


        }

        /// <summary>
        /// Set report status 
        /// </summary>
        public static void ReportStatus()
        {
            if (BrowserFactory.status == true)
            {
                ReportHelper.test.Log(Status.Pass, "Test Pass");
            }
            else
            {
                ReportHelper.test.Log(Status.Fail, "Test Fail");
            }
        }

        /// <summary>
        /// Tear down
        /// </summary>
        /// Test context in Xunit
        public void Dispose()
        {
            ReportStatus();
            browserFactory.driver.Dispose();
            browserFactory.driver.Quit();
        }
    }
}
