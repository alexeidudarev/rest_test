using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using projectReportingOOP.BaseTest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projectReportingOOP.Tests
{
     public class SanityTest : BaseTests
    {
        private static String dir = @"C:\Users\Software Testing\Documents\Projects\projReportOOP\projectReportingOOP\Reports\";
        
        [Test,Order(1)]
        public void byOneProduct()
        {
            //creating feature
            htmlReporter.Feature = htmlReporter.Extent.CreateTest<Feature>("Buy one product").AssignCategory("regression");
            var scenario = htmlReporter.Feature.CreateNode<Scenario>("Buy one product test started");
            try
            {
                homePage.goToHomePage();
                homePage.addItemToBasket();
                homePage.proceed_to_checkout();
                basket.verifyQuantity();
                basket.verifyDesciption();

                basket.searchItem("Printed Chiffon Dress");
                basket.assertSearchResult();
                basket.open_support_page();

                customer_support.send_suport_form();
                customer_support.verify_message_submitted();


                scenario.CreateNode<Given>("Buy one product test succeed").Log(Status.Pass, DateTime.Now.ToString());
                takeScreenshot(dir, "Product_Added", driver, scenario);
            }
            catch (Exception e)
            {
                failTest(e, "Buy one product test failed", scenario);
            }

        }

        [Test, Order(2)]
        public void send_support_ticket()
        {
            //creating feature
            htmlReporter.Feature = htmlReporter.Extent.CreateTest<Feature>("send_support_ticket").AssignCategory("regression");
            var scenario = htmlReporter.Feature.CreateNode<Scenario>("send_support_ticket test started");
            try
            {
                homePage.goToHomePage();
                basket.open_support_page();

                customer_support.send_suport_form();
                customer_support.verify_message_submitted();


                scenario.CreateNode<Given>("send_support_ticket test succeed").Log(Status.Pass, DateTime.Now.ToString());
                takeScreenshot(dir, "send_support_ticket", driver, scenario);
            }
            catch (Exception e)
            {
                failTest(e, "send_support_ticket test failed", scenario);
            }

        }
        [Test, Order(3)]
        public void apiTesting()
        {
            reqResApi.getAllUsers();
        }



        [Test, Order(4)]
        public void getHtmlResults()
        {
            try
            {
                homePage.goToReport();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption in test :" + e.StackTrace.ToString());
            }


           
        }
        private void failTest(Exception e, String errorDescription, ExtentTest scenario)
        {

            Console.WriteLine("Exeption in test :" + e.StackTrace.ToString());
            Console.WriteLine("Exeption in description :" + errorDescription);
            scenario.CreateNode<Given>("טסט נכשל ").Log(Status.Fail, DateTime.Now.ToString());
            scenario.CreateNode<Given>(errorDescription).Log(Status.Fail, DateTime.Now.ToString());
            takeScreenshot(dir, errorDescription, driver, scenario);
            Assert.Fail();
        }

        private static void takeScreenshot(String parentDirName, String methodName, IWebDriver driver, ExtentTest test)
        {
            //To take screenshot
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();

            //To save screenshot
            file.SaveAsFile(parentDirName  + methodName+ ".png", ScreenshotImageFormat.Png);

            Thread.Sleep(5000);
            //create new node 
            ExtentTest t = test;
            t.CreateNode<Given>("screenshot").Info("Details", MediaEntityBuilder.CreateScreenCaptureFromPath(parentDirName + methodName+ ".png").Build());
        }
    } 
}
