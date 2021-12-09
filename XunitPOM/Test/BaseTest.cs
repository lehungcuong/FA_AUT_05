using System;
using Xunit;
using XunitPOM.Utilities;
using WebDriver;
using AventStack.ExtentReports;
using System.Linq;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XunitPOM.Test
{
    public class BaseTest : IDisposable, IClassFixture<ReportHelper>
    {
        public BrowserFactory BrowserFactory;
        public FactAttribute FactAttribute;
        ITestOutputHelper testOutputHelper;

        public BaseTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;

            // Create new test case report
            ReportHelper.CreateTestReport(GetDisplayName());

            // Create new driver and get config from configuaration file
            //BrowserFactory = new BrowserFactory(ConfigHelper.GetValue("Driver"), ConfigHelper.GetValue("URL"));

            // Create new driver and get config from json file
            BrowserFactory = new BrowserFactory(JsonHelper.GetValueByKeyRawData("Driver"), JsonHelper.GetValueByKeyRawData("URL"));
        }

        /// <summary>
        /// Get current display name
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetDisplayName()
        {
            var helper = (TestOutputHelper)testOutputHelper;

            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(helper);

            string DisplayName = test.TestCase.DisplayName;

            return DisplayName.Substring(0, DisplayName.IndexOf("Test") + 4);
        }

        /// <summary>
        /// Tear down
        /// </summary>
        /// Test context in Xunit
        public void Dispose()
        {
            BrowserFactory.driver.Dispose();
            BrowserFactory.driver.Quit();
        }
    }
}
