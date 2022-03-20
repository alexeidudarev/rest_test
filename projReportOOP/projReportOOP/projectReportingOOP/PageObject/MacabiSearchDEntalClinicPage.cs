using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;
using projectReportingOOP.BasePage;
using System.Reflection;

namespace projectReportingOOP.PageObject
{
    public class MacabiSearchDEntalClinicPage :BasePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        

        public MacabiSearchDEntalClinicPage(IWebDriver driver, WebDriverWait wait):base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//label//input[@id='DaysOfWeek1']")]
        private IWebElement elem_day1;

        [FindsBy(How = How.XPath, Using = "//label//input[@id='DaysOfWeek3']")]
        private IWebElement elem_day3;

        [FindsBy(How = How.XPath, Using = "//label//input[@id='DaysOfWeek6']")]
        private IWebElement elem_day6;

        [FindsBy(How = How.XPath, Using = "//label//input[@id='Hours1']")]
        private IWebElement elem_hours;


        [FindsBy(How = How.CssSelector, Using = " div.tooltip.tooltip-main.top.in > div.tooltip-inner")]
        private IWebElement elem_slider;

        [FindsBy(How = How.XPath, Using = "//div[@id='']")]
        private IWebElement elem_slider_m;


        [FindsBy(How = How.XPath, Using = "//*[@id='page-link2']")]
        private IWebElement elem_page_results_2;

        [FindsBy(How = How.XPath, Using = "//a[@id='index2']")]
        private IWebElement elem_clinic_nes_ziona;

        [FindsBy(How = How.CssSelector, Using = "div.disNonePrint.noFixed > div > a")]
        private IWebElement elem_zimun_tor_button;

        public String getPageTitle()
        {
            return driver.Title;
        }

        public void selectDays()
        {
            Thread.Sleep(1000);
            elem_day1.Click();
            Thread.Sleep(1000);
            elem_day3.Click();
            Thread.Sleep(1000);
            elem_day6.Click();
        }
        
        public void selectHours()
        {
            elem_hours.Click();
          
        }
        public void moveSlider()
        {
            Thread.Sleep(1000);

            Actions action = new Actions(driver);
            
            action.ClickAndHold(elem_slider_m)
                .MoveByOffset((-(int)elem_slider.Size.Width*4), 0).Release().Perform();

        }
        public void openSecondResultsPage()
        {
            try
            {
                Thread.Sleep(1000);
                var next_page  =  wait.Until(ExpectedConditions.ElementToBeClickable(elem_page_results_2));
                moveToElement(elem_page_results_2, driver);
                next_page.Click();
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }
        public void openNesZionClinic()
        {

            try
            {
                Thread.Sleep(5000);
                var nes_ziona_clinic =  wait.Until(ExpectedConditions.ElementToBeClickable(elem_clinic_nes_ziona));
                moveToElement(elem_clinic_nes_ziona, driver);
                nes_ziona_clinic.Click();

                Thread.Sleep(1000);
                var zimun_tor_button =  wait.Until(ExpectedConditions.ElementToBeClickable(elem_zimun_tor_button));
                moveToElement(elem_zimun_tor_button, driver);
                zimun_tor_button.Click();
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
         
        }
        

        public void selectNextWindow()
        {
            
            driver.SwitchTo().Window(driver.WindowHandles[1]);

        }
     

    }
}
