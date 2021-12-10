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
        public static string reportPath = Directory.GetParent(Environment.CurrentDirectory) + 
            @"\Result" + DateTime.Now.ToString("dd-MM-yyyy-HH-MM-ss") + ".html";

        /// <summary>
        /// Constructor of Report Helper
        /// </summary>
        public ReportHelper()
        {
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// Creat an Extend Report
        /// </summary>
        /// <param name="testName"></param>
        public static void CreatTest(string testName)
        {
            extentTest = extentReports.CreateTest(testName);
        }

        /// <summary>
        /// Flush and Change name of Report
        /// </summary>
        public void Dispose()
        {
            extentReports.Flush();
            var oldPath = Directory.GetParent(Environment.CurrentDirectory) + @"\" + "index.html";
            File.Move(oldPath, reportPath);
        }
    }
}
