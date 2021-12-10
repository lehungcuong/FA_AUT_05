using POM_Driver;
using QuyenLLP_FinalTest.Utilities;
using System;
using Xunit;

namespace QuyenLLP_FinalTest.Tests
{
    public class BaseTest : IDisposable, IClassFixture<ReportHelper>
    {
        ReadConfig readConfig;
        public BrowserFactory browser;
        public BaseTest()
        {
            readConfig = new ReadConfig();
            browser = new BrowserFactory(readConfig.GetBrowserType(), readConfig.GetStartUrl());
            BrowserFactory.driver.Url = readConfig.GetStartUrl();
        }
        /// <summary>
        /// tear down
        /// </summary>
        public void Dispose()
        {
            BrowserFactory.driver.Quit();
        }

    }
}
