using System;
using TestFactory;
using XUnitTestPage_automationpractice.com.Utilities;

namespace XUnitTestPage_automationpractice.com.Test
{
    public class BaseTest : IDisposable
    {
        public static BrowserFactory browserFactory;

        public BaseTest()
        {
            browserFactory = new BrowserFactory(JsonHelper.GetValue("Driver"), JsonHelper.GetValue("URL"));
        }
        /// <summary>
        /// tear down
        /// </summary>
        public void Dispose()
        {
            browserFactory.Driver.Dispose();
        }
    }
}
