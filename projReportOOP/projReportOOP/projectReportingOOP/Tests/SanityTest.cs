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
        private static String dir = @"C:\Users\Software Testing\Documents\MAC\projectReportingOOP\projectReportingOOP\Reports\";
        
        [Test,Order(1)]
        public void PageTestTelAviv()
        {
            //creating feature
            htmlReporter.Feature = htmlReporter.Extent.CreateTest<Feature>("טסט איתור מרפאה תל אביב").AssignCategory("בדיקות רגרסיה");
            var scenario = htmlReporter.Feature.CreateNode<Scenario>(" טסט איתור מרפאה תל אביב התחיל");
            try
            {
                homePage.goToHomePage();
                homePage.openMacabiDentPage();

                macabiDentPage.openMacabizahavTab();
                macabiDentPage.openMirpaaImHescem();

                madrichSherutimPage.selectNextWindow();
                madrichSherutimPage.searchForClinic("תל אביב - יפו");

                macabiSearchDEntalClinicPage.selectDays();
                macabiSearchDEntalClinicPage.selectHours();
                macabiSearchDEntalClinicPage.moveSlider();
                macabiSearchDEntalClinicPage.openSecondResultsPage();
                macabiSearchDEntalClinicPage.openNesZionClinic();

                clinicPage.addTorValues();
                clinicPage.addDateValues();
                clinicPage.addClinicValues();
                clinicPage.addCheckboxValues();
                scenario.CreateNode<Given>("טסט עבר בהצלחה").Log(Status.Pass, DateTime.Now.ToString());
                takeScreenshot(dir, "PageTestTelAviv", driver, scenario);
            }
            catch (Exception e)
            {
                failTest(e, "טסל- איתור מרפאה תל אביב -  לא עבר", scenario);
            }


            
        
        }
        [Test, Order(2)]
        public void PageTestHolon()
        {
            //creating feature
            htmlReporter.Feature = htmlReporter.Extent.CreateTest<Feature>("טסט איתור מרפאה חולון").AssignCategory("בדיקות רגרסיה");
            var scenario = htmlReporter.Feature.CreateNode<Scenario>("טסט איתור מרפאה חולון התחיל");
            try
            {

                homePage.goToHomePage();
                homePage.openMacabiDentPage();

                macabiDentPage.openMacabizahavTab();
                macabiDentPage.openMirpaaImHescem();

                madrichSherutimPage.selectNextWindow();
                madrichSherutimPage.searchForClinic("חולון");

                macabiSearchDEntalClinicPage.selectDays();
                macabiSearchDEntalClinicPage.selectHours();
                macabiSearchDEntalClinicPage.moveSlider();
                macabiSearchDEntalClinicPage.openSecondResultsPage();
                macabiSearchDEntalClinicPage.openNesZionClinic();

                clinicPage.addTorValues();
                clinicPage.addDateValues();
                clinicPage.addClinicValues();
                clinicPage.addCheckboxValues();
                scenario.CreateNode<Given>("טסט עבר בהצלחה").Log(Status.Pass, DateTime.Now.ToString());
                takeScreenshot(dir, "PageTestHolon", driver, scenario);
            }
            catch (Exception e)
            {
                failTest(e, "טסל- איתור מרפאה חולון -  לא עבר", scenario);
            }



        }
        [Test, Order(3)]
        public void PageTestJerusalem()
        {
            //creating feature
            htmlReporter.Feature = htmlReporter.Extent.CreateTest<Feature>("טסט איתור מרפאה בירושלים").AssignCategory("בדיקות רגרסיה");
            var scenario = htmlReporter.Feature.CreateNode<Scenario>("טסט איתור מרפאה בירושלים התחיל");
            try
            {
                homePage.goToHomePage();
                homePage.openMacabiDentPage();

                macabiDentPage.openMacabizahavTab();
                macabiDentPage.openMirpaaImHescem();

                madrichSherutimPage.selectNextWindow();
                madrichSherutimPage.searchForClinic("ירושלים");

                macabiSearchDEntalClinicPage.selectDays();
                macabiSearchDEntalClinicPage.selectHours();
                macabiSearchDEntalClinicPage.moveSlider();
                macabiSearchDEntalClinicPage.openNesZionClinic();

                clinicPage.addTorValues();
                clinicPage.addDateValues();
                clinicPage.addClinicValues();
                clinicPage.addCheckboxValues();
                scenario.CreateNode<Given>("טסט עבר בהצלחה")
                    .Log(Status.Pass, DateTime.Now.ToString());
                takeScreenshot(dir, "PageTestJerusalem", driver,scenario);
            }
            catch (Exception e)
            {
                failTest(e, "טסל- איתור מרפאה בירושלים -  לא עבר", scenario);
            }


            

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
