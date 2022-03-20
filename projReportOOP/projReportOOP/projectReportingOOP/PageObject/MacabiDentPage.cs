using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using projectReportingOOP.BasePage;
using NUnit.Framework;

namespace projectReportingOOP.PageObject
{
    public class MacabiDentPage : BasePageObject
    {

        private IWebDriver driver;

        public MacabiDentPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }



        //elemnts 
        [FindsBy(How = How.XPath, Using = "//a[@id='ctl00_ContentPlaceHolder1_ucCompositionPane_ctl02_rpt_ctl01_ancTab']")]
        private IWebElement elem_macabi_zahav_tab;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'https://serguide.maccabi4u.co.il/heb/DentistOffices/')]")]
        private IWebElement elem_macabi_zahav_im_heskem_link;

        [FindsBy(How = How.XPath, Using = "//img[@id='ctl00_ucHorizontalBannerLevelTwo_imgBanner']")]
        private IWebElement elem_macabi_zahav_immageBanner;

        //Methods

        public void openMacabizahavTab()
        {
            
            moveToElement(elem_macabi_zahav_tab, driver);
            elem_macabi_zahav_tab.Click();
        }
        
        public void openMirpaaImHescem()
        {
            moveToElement(elem_macabi_zahav_im_heskem_link, driver);
            elem_macabi_zahav_im_heskem_link.Click();
        }

     
        
    }
}
