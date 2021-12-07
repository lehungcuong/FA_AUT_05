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
        public BrowserFactory browserFactory;
        public FactAttribute FactAttribute;
        ITestOutputHelper testOutputHelper;

        public BaseTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;

            // Create new test case report
            ReportHelper.CreateTestReport(GetMethodName());

            // Create new driver and get config from configuaration file
            browserFactory = new BrowserFactory(ConfigHelper.GetValue("Driver"), ConfigHelper.GetValue("URL"));

            // Create new driver and get config from json file
            //browserFactory = new BrowserFactory(JsonHelper.GetValueByKeyConfig("Driver"), JsonHelper.GetValueByKeyConfig("URL"));
        }

        /// <summary>
        /// Get current method name
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetMethodName()
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
            browserFactory.driver.Dispose();
            browserFactory.driver.Quit();
        }
    }
}
