namespace BrowserFactory.Configuration
{
    public class LocalDriverConfig
    {
        public string Browser { get; set; }

        public LocalDriverConfig(string browser)
        {
            Browser = browser;
        }
    }
}
