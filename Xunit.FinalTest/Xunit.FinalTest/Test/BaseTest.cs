using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDriver;
using Xunit.Abstractions;
using Xunit.DriverFactory.Utilities;
using Xunit.Sdk;

namespace Xunit.FinalTest.Pages
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
            ReportHelper.CreateTestReport(GetDisplayName());

            // Create new driver and get config from configuaration file
            browserFactory = new BrowserFactory(ConfigHelper.GetValue("Driver"), ConfigHelper.GetValue("URL"));
        }

        /// <summary>
        /// Get current display name
        /// </summary>
        /// <param name="context"></param>
        /// <returns> String </returns>
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
        public void Dispose()
        {
            browserFactory.driver.Dispose();
            browserFactory.driver.Quit();
        }
    }
}
