﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using Xunit;

namespace XunitPOM.Utilities
{
    public class ReportHelper : IDisposable
    {
        public static ExtentReports extentReport;
        public static ExtentTest extentTest;
        private static string currentDate = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
        // Fix directory to bin
        private readonly static string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly static string ReportLocation = SolutionPath + @"\Reports\" + "Report " + currentDate + ".html";
        private static int count = 0;

        /// <summary>
        /// Init report helper and attach to html report
        /// </summary>
        public ReportHelper()
        {
            extentReport = new ExtentReports();
            ExtentHtmlReporter HtmlReporter = new(ReportLocation);
            HtmlReporter.Config.DocumentTitle = "My Automation Test Report";
            HtmlReporter.Config.ReportName = "Example Report";

            extentReport.AttachReporter(HtmlReporter);
        }

        /// <summary>
        /// Create test report
        /// </summary>
        /// <param name="DisplayName"></param>
        public static void CreateTestReport(string DisplayName = null)
        {
            extentTest = extentReport.CreateTest("Test case: " + TestCaseCount()).Info(DisplayName);
        }

        /// <summary>
        /// Empty Thunk
        /// </summary>
        public delegate void Thunk();

        /// <summary>
        /// Should not throw exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thunk"></param>
        public static void ShouldNotThrow<T>(Thunk thunk) where T : Exception
        {
            try
            {
                thunk.Invoke();
                extentTest.Log(Status.Pass, "Test case run successfully");
            }
            catch (T ex)
            {
                extentTest.Log(Status.Fail, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Automatically increase count for each test case
        /// </summary>
        /// <returns> current number of testcase </returns>
        public static int TestCaseCount() => count += 1;

        /// <summary>
        /// Once time tear down export and copy report
        /// </summary>
        public void Dispose()
        {
            extentReport.Flush();
            File.Move(SolutionPath + @"\Reports\" + "index.html", ReportLocation);
        }
    }
}
