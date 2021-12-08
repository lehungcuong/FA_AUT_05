using System;

using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestPOM.Pages
{
    class ContentRequest : IDisposable
    {
        
        static ExtentTest test;
        static ExtentReports extent;

        //C:\Users\Quang\Desktop\TestPOM_QuangTD20_01122021\TestPOM\FileExtentReports\
        //"C:\\Users\\Quang\\Desktop\\TestPOM_QuangTD20_01122021\\TestPOM\\FileExtentReports\\Reports08-12-2021-07-12-59.html"
        static string PathExtentReport = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
            @"\FileExtentReports\Reports" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".html";
        public ContentRequest()
        {
            extent = new ExtentReports();
            var FileHTMLReporter = new ExtentHtmlReporter(PathExtentReport);
            extent.AttachReporter(FileHTMLReporter);
            //var htmlreporter = new ExtentHtmlReporter(@"C:\Users\Quang\Desktop\TestPOM_QuangTD20_01122021\TestPOM\ExtentReport\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            //extent.AttachReporter(htmlreporter);

        }
        public static void CreatTest(string testName,string testinfor)
        {
            test = extent.CreateTest(testName).Info(testinfor);
            //test.Log(Status.Info, status);
        }

        public static void CreatLogInfo(string status)
        {
            
            test.Log(Status.Info, status);
            
        }

        public static void CreatLogPass(string status)
        {

            test.Log(Status.Pass, status);
        }

        public static void CreatLogFail(string status)
        {

            test.Log(Status.Fail, status);
        }

        public void Dispose()
        {
            extent.Flush();
            var oldPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\\FileExtentReports\" + "index.html";
            File.Move(oldPath, PathExtentReport);
        }
    }
}
