using System;
using Xunit;
using XunitPOM.Utilities;
using WebDriver;
using Xunit.Abstractions;
using AventStack.ExtentReports;

namespace XunitPOM.Test
{
    public class BaseTest : IDisposable
    {
        public BrowserFactory browserFactory;
        public FactAttribute FactAttribute;
        public XunitHelper XunitHelper;
        public ITestOutputHelper output;

        public BaseTest()
        {
            // Create new driver and get config from configuaration file
            browserFactory = new BrowserFactory(ConfigHelper.GetValue("Driver"), ConfigHelper.GetValue("URL"));
            
            // Create new driver and get config from json file
            //DriverFactory = new DriverFactory(JsonHelper.getValue("Driver"), JsonHelper.getValue("URL"));
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
