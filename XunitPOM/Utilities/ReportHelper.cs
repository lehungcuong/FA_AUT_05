using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace XunitPOM.Utilities
{
    public class ReportHelper : IDisposable
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        private static string currentDate = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
        private readonly static string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly static string ReportLocation = SolutionPath + @"\Reports\" + "Report " + currentDate + ".html";
        private static int count = 0;

        /// <summary>
        /// Init report helper and attach to html report
        /// </summary>
        public ReportHelper()
        {
            extent = new ExtentReports();
            ExtentHtmlReporter HtmlReporter = new(ReportLocation);
            HtmlReporter.Config.DocumentTitle = "My Test Automation Report";
            HtmlReporter.Config.ReportName = "Example Report";

            extent.AttachReporter(HtmlReporter);
        }

        public static int TestCaseCount() => count += 1;

        /// <summary>
        /// One time tear down export and copy report
        /// </summary>
        public void Dispose()
        {
            extent.Flush();
            File.Move(SolutionPath + @"\Reports\" + "index.html", ReportLocation);
        }
    }
}
