using System;
using XUnitTest_POM.Constraints;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Test
{
    public class BaseTest : IDisposable
    {
        public BrowserFactory browserFactory;

        /// <summary>
        /// Constructor of BaseTest
        /// </summary>
        public BaseTest()
        {
            browserFactory = new BrowserFactory(Type(), ConfigHelper.GetValue("uri"));
        }

        /// <summary>
        /// Return Browser type
        /// </summary>
        /// <returns> Browser type </returns>
        public static BrowserType Type()
        {
            var app = ConfigHelper.GetValue("browser");
            Enum.TryParse(app, out BrowserType type);
            return type;
        }

        /// <summary>
        /// Close browser
        /// </summary>
        public void Dispose()
        {
             BrowserFactory.CloseBrowser();
        }
    }
}
