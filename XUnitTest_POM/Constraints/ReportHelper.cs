using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace XUnitTest_POM.Constraints
{
    public class ReportHelper : IDisposable
    {
        public static ExtentReports extentReports;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest extentTest;

        private readonly static string reportPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + 
            @"\Reports\Result" + DateTime.Now.ToString("dd-MM-yyyy-HH-MM-ss") + ".html";

        public ReportHelper()
        {
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        public static void CreatTest(string testName)
        {
            extentTest = extentReports.CreateTest(testName);
        }

        public void Dispose()
        {
            extentReports.Flush();
            var oldPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Reports\" + "index.html";
            File.Move(oldPath, reportPath);
        }
    }
}
