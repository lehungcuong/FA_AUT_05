using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class BasePage
    {

        public Browser browser;
        public BasePage(Browser browser)
        {
            this.browser = browser;
        }

        public void Dispose()
        {
            Browser.Driver.Close();
            Browser.Driver.Quit();
        }
    }
}
