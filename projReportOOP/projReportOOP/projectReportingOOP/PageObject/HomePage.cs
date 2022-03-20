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
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace projectReportingOOP.PageObject
{
    public class HomePage : BasePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        String home_url = "https://www.maccabi4u.co.il/14-he/Maccabi.aspx";

        public HomePage(IWebDriver driver,WebDriverWait wait) : base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        //elemnts 
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ucBigPromotion_rptPromotions_ctl00_divBottom']")]
        private IWebElement elem_macabi_dent_tab;

        [FindsBy(How = How.XPath, Using = "//a[@id='ctl00_ucLowerHeader_aLogoLink']")]
        private IWebElement elem_macabi_logo;

        
        //Methods
       
        public void openMacabiDentPage()
        {
            var elem_macabi_dent = wait.Until(ExpectedConditions.ElementToBeClickable(elem_macabi_dent_tab));
            moveToElement(elem_macabi_dent_tab,driver);
            elem_macabi_dent.Click();

        }
        public void goToHomePage()
        {
            goToPage(home_url,driver);
        }
        public void goToReport()
        {
            Thread.Sleep(5000);
            goToPage(@"C:\Users\Software Testing\Documents\MAC\projectReportingOOP\projectReportingOOP\Reports\index.html", driver);
            Thread.Sleep(60000);
        }

        public String getPageTitle()
        {
            return getPageTitle(driver);
        }
        
        
    }
}
