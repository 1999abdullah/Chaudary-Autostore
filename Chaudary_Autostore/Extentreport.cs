using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaudary_Autostore
{
    public class ExtentReport
    { 
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
    public static void LogReport(string testcase)
    {
        extentReports = new ExtentReports();
        dirpath = @"C:\Users\abdul\Source\Repos\1999abdullah\Chaudary-Autostore\Chaudary_Autostore\test_summery\Extent_report\" + testcase;

        ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

        htmlReporter.Config.Theme = Theme.Dark;

        extentReports.AttachReporter(htmlReporter);

    }
}
}
