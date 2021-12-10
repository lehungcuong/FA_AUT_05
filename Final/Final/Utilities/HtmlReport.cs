using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace Final.Utilities
{
    public class HtmlReport : IDisposable
    {

        public ExtentTest test;
        public ExtentReports extent = new ExtentReports();
        static string[] paths = { Environment.CurrentDirectory, "Report", "UnitTest1.html" };
        string newPath = Path.Combine(paths);

        public HtmlReport()
        {
            var htmlreporter = new ExtentHtmlReporter(newPath);
            extent.AttachReporter(htmlreporter);
        }

        public void CreateReport(string testname)
        {
            test = extent.CreateTest(testname).Info("Item");
        }

        public void PassReport(string passContent)
        {
            test.Log(Status.Pass, passContent);
        }


        public void FailReport(string failContent)
        {
            test.Log(Status.Fail, failContent, MediaEntityBuilder.CreateScreenCaptureFromPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Report\Image.png").Build());
        }

        public void Dispose()
        {
            extent.Flush();
        }
    }
}
