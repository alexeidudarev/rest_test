using projectReportingOOP.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectReportingOOP.PageObject
{
    public class ClinicPage : BasePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ClinicPage(IWebDriver driver, WebDriverWait wait) :base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "זימון תור")]
        private IWebElement elem_zimun_tor_button;

        [FindsBy(How = How.CssSelector, Using = " div.appointment-dropdown.search_clinic > div")]
        private IWebElement elem_select_tor;

        [FindsBy(How = How.CssSelector, Using = " div.appointment-dropdown.search_clinic > ul > li:nth-child(1) > label")]
        private IWebElement elem_select_tor_dental;

        //bdateselector hasDatepicker
        [FindsBy(How = How.CssSelector, Using = "div>input.bdateselector.hasDatepicker")]
        private IWebElement elem_date_picker;

        [FindsBy(How = How.CssSelector, Using = " div.search_clinic > span > input")]
        private IWebElement elem_clinic_picker;

        [FindsBy(How = How.CssSelector, Using = "div.under_eighteen_error_message.one.active > div > span > input")]
        private IWebElement elem_check_box;

        [FindsBy(How = How.CssSelector, Using = "div > div.submit_step_1 > div > input[type=submit]")]
        private IWebElement elem_btn_hemsheh;

        public String getPageTitle()
        {
            return driver.Title;
        }
        private void selectNextWindow()
        {

            driver.SwitchTo().Window(driver.WindowHandles[2]);

        }
        public void addTorValues()
        {
            
            //move to next tab focus
            selectNextWindow();

            var select_tor = wait.Until(ExpectedConditions.ElementToBeClickable(elem_select_tor));
            moveToElement(elem_select_tor, driver);
            select_tor.Click();

            var select_tor_dental = wait.Until(ExpectedConditions.ElementToBeClickable(elem_select_tor_dental));
            moveToElement(elem_select_tor_dental, driver);
            select_tor_dental.Click();

          
        }
        public void addDateValues()
        {
            var date_picker = wait.Until(ExpectedConditions.ElementToBeClickable(elem_date_picker));
            date_picker.SendKeys("1 בינואר 1983");

        }
        public void addClinicValues()
        {
            var clinic_picker = wait.Until(ExpectedConditions.ElementToBeClickable(elem_clinic_picker));
            clinic_picker.SendKeys("נס ציונה");
        }
        public void addCheckboxValues()
        {
            var check_box = wait.Until(ExpectedConditions.ElementToBeClickable(elem_check_box));
            check_box.Click();

            var btn_hemsheh = wait.Until(ExpectedConditions.ElementToBeClickable(elem_btn_hemsheh));
            btn_hemsheh.Click();
        }
    }
}
