using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectReportingOOP.BaseTest
{
    public class HtmlReporter
    {

        private ExtentReports extent;
        private ExtentHtmlReporter htmlreporter;
        private ExtentTest feature;
        public static String basePath = AppDomain.CurrentDomain.BaseDirectory;


        public HtmlReporter()
        {
            //creating html reporter
            htmlreporter = new ExtentHtmlReporter(@"C:\Users\Software Testing\Documents\MAC\projectReportingOOP\projectReportingOOP\Reports\ExtentReport.html");
            htmlreporter.Config.Theme = Theme.Dark;
            htmlreporter.Config.DocumentTitle = "Test Report |  QA Team";
            htmlreporter.Config.ReportName = "QA Team | Alex";

            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);
        }

        public ExtentReports Extent { get => extent; set => extent = value; }
        public ExtentHtmlReporter Htmlreporter { get => htmlreporter; set => htmlreporter = value; }
        public ExtentTest Feature { get => feature; set => feature = value; }
    }
}
