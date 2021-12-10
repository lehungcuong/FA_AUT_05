using OpenQA.Selenium;
using Xunit;

namespace DiemHL1_FinalTest.Test
{
    public class OrderTest : BaseTest
    {
        [Fact(DisplayName = "Verify button add to card open page correct")]
        public void LoginTestCase()
        {
            // Step 1.  Scroll down to "Popular" component from home screen
            IJavaScriptExecutor scrollInBookNow = (IJavaScriptExecutor)browserFactory.Driver;
            scrollInBookNow.ExecuteScript("scroll(0, 1000);");

            // Step 2. At item click button "add to card"
        }
    }
}
