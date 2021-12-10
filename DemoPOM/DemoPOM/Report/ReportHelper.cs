using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace DemoPOM.Report
{
    public class ReportHelper 
    {
        ExtentReports extent;
        private ExtentTest test;
        /// <summary>
        /// Constructor ExtentReportHP
        /// </summary>
       public ReportHelper()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"D:\FA_AUT_05\DemoPOM\DemoPOM\Report\ReportFile" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlReporter);
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            htmlReporter.Config.ReportName = " Testing";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AddSystemInfo("Application Under Test", "TestCase");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        /// <summary>
        /// Create Test
        /// </summary>
        /// <param name="testName"></param>
        /// <param name="description"></param>
        public void CreateTest(string testName, string description)
        {
            test = extent.CreateTest(testName, description);
        }
        /// <summary>
        /// Set step Status Pass
        /// </summary>
        /// <param name="stepDescription"></param>
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        /// <summary>
        /// Pass TC
        /// </summary>
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully!");
        }
        /// <summary>
        /// Set step warning
        /// </summary>
        /// <param name="stepDescription"></param>
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        /// <summary>
        /// Set test status Fail
        /// </summary>
        /// <param name="message"></param>
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        /// <summary>
        /// Set step skip
        /// </summary>
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        /// <summary>
        /// Method close
        /// </summary>
        public void Close()
        {
            extent.Flush();
        }
    }
}
