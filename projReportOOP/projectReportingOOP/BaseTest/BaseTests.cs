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
using projectReportingOOP.ApiObjects;

namespace projectReportingOOP.BaseTest
{
    public class BaseTests 
    {

        public IWebDriver driver;
        protected  WebDriverWait wait;
        public HomePage homePage;
        public Basket basket;
        public Customer_Support customer_support;
        public ReqResApi reqResApi;
        public static  HtmlReporter htmlReporter =  new HtmlReporter();


        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver,wait);
            basket = new Basket(driver, wait);
            customer_support = new Customer_Support(driver, wait);
            reqResApi = new ReqResApi();
           
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
