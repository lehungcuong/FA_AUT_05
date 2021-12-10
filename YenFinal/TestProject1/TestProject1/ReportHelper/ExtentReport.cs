using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using Xunit;

namespace TestProject1.ReportHelper

{
    public class ExtentReportsHelper : IDisposable
    {
        public static ExtentReports extentReports;
        public static ExtentTest extentTest;
        public ExtentHtmlReporter extentHtmlReporter;

        static string reportPath = Directory.GetParent(@"../").FullName + @"/Report" + @"/Report" + DateTime.Now.ToString("dd-MM-yyyy-HHmmss") + ".html";////solution//Report/Report dd-MM-yyyy-HHmmss

        public ExtentReportsHelper()
        {
            extentHtmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public static void CreateTestReporst(string TestReportName)
        {
            // test report
            extentTest = extentReports.CreateTest(TestReportName);
        }

        public void Dispose()
        {
            extentReports.Flush();
            var oldPath = Directory.GetParent(@"../").FullName + Path.DirectorySeparatorChar + "Report" + Path.DirectorySeparatorChar + "index.html";
            File.Move(oldPath, reportPath);
        }
    }
}