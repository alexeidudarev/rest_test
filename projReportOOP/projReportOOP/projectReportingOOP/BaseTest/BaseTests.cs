using AventStack.ExtentReports.Gherkin.Model;
using projectReportingOOP.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projectReportingOOP.BaseTest
{
    public class BaseTests 
    {

        public IWebDriver driver;
        protected  WebDriverWait wait;
        public HomePage homePage;
        public MacabiDentPage macabiDentPage;
        public MadrichSherutimPage madrichSherutimPage;
        public MacabiSearchDEntalClinicPage macabiSearchDEntalClinicPage;
        public ClinicPage clinicPage;
        public static  HtmlReporter htmlReporter =  new HtmlReporter();


        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver,wait);
            macabiDentPage = new MacabiDentPage(driver);
            madrichSherutimPage = new MadrichSherutimPage(driver,wait);
            macabiSearchDEntalClinicPage = new MacabiSearchDEntalClinicPage(driver,wait);
            clinicPage = new ClinicPage(driver,wait);
           

            
        }
        [OneTimeTearDown]
        public void  setUp()
        {
            Thread.Sleep(1000);
        }

        [TearDown]
        public void Cleanup()
        {
            
            try
            {
                htmlReporter.Extent.Flush();
            }
            finally
            {
                
                driver.Quit();
            }
        }
    }
}
