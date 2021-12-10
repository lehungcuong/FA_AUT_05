using BrowserFactory;
using BrowserFactory.Configuration;
using Final.Utilities;
using OpenQA.Selenium;
using System;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Final.Tests
{
    public class BaseTest : IDisposable, IClassFixture<TestFixture>
    {
        public IWebDriver driver;
        public static TestFixture fixture;
        string testName = string.Empty;
        ITestOutputHelper testOutputHelper;

        public BaseTest(TestFixture testFixture, ITestOutputHelper testOutputHelper)
        {
            driver = new BrowsersFactory().Create(new LocalDriverConfig(TestConfig.Browser));
            this.testOutputHelper = testOutputHelper;
            fixture = testFixture;
            testName = GetMethodName();
            fixture.Report.CreateReport(testName);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        public string GetMethodName()
        {
            var helper = (TestOutputHelper)testOutputHelper;

            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(helper);

            return testName = test.TestCase.DisplayName.Substring(0, test.TestCase.DisplayName.IndexOf("Test") + 4);
        }
    }

    public class TestFixture : IDisposable
    {

        public HtmlReport Report;

        public TestFixture()
        {
            Report = new HtmlReport();
        }

        public void Dispose()
        {
            Report.Dispose();
        }
    }
}
