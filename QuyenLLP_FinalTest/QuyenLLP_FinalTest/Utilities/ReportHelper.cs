using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuyenLLP_FinalTest.Utilities
{
    public class ReportHelper : IDisposable
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extentReports;
        public static ExtentTest extentTest;

        static string reportPath = Directory.GetParent(Environment.CurrentDirectory) + @"\Reports\Test_Reports_" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".html";
        public ReportHelper()
        {
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// Create Test report when start run test case
        /// </summary>
        /// <param name="name"></param>
        public static void CreateTestReport(string name)
        {
            extentTest = extentReports.CreateTest(name);
        }
        /// <summary>
        /// Dispose ExtentReports when run end
        /// </summary>
        public void Dispose()
        {
            extentReports.Flush();
            string oldPath = Directory.GetParent(Environment.CurrentDirectory) + @"\Reports\" + "index.html";
            File.Move(oldPath, reportPath);
        }

    }
}
