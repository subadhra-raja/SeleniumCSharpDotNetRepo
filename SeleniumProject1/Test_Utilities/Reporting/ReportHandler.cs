using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumProject1.Test_Utilities.Reporting
{
   public class ReportHandler
    {
        public static ExtentHtmlReporter htmlReporter;

        public static ExtentReports extent;
        /// <summary>
        /// Default Constructor
        /// </summary>
        private ReportHandler()
        {

        }
        /// <summary>
        /// Method to initialize ExtentReport 
        /// </summary>
        public static void getinstance()
        {
            if (extent ==null)
            {
                string reportPath = "C:\\Reporting\\Reports\\Report.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
        }

        /// <summary>
        /// Method to Close ExtentReport instance
        /// </summary>
        public static void CloseReportInstance()
        {
            extent.Flush();
        }

    }
}
