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
    public class MadrichSherutimPage : BasePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public MadrichSherutimPage(IWebDriver driver, WebDriverWait wait) : base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#react-select-City_select--value > div.Select-input > input")]
        private IWebElement elem_search_town;

        [FindsBy(How = How.XPath, Using = "//div[@id='SearchButton']")]
        private IWebElement elem_button_search;


        public void selectNextWindow()
        {
          
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine(driver.CurrentWindowHandle);
           
        }

        public void searchForClinic(String town)
        {
            
            Actions action = new Actions(driver);
            
            try
            {
                elem_search_town.SendKeys(town);
                elem_search_town.Click();
                elem_search_town.SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    string err = e.InnerException.Message;
                }
            }
            Thread.Sleep(500);
            elem_button_search.Click();
            

        }
        

        
    }
}
