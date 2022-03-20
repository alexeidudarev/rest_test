using projectReportingOOP.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace projectReportingOOP.PageObject
{
    public class Basket : BasePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Basket(IWebDriver driver, WebDriverWait wait) :base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'1 Product')]")]
        private IWebElement elem_quantitty;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Faded Short Sleeve T-shirts')]")]
        private IWebElement elem_descritpion;
    

        [FindsBy(How = How.CssSelector, Using = "logo img-responsive")]
        private IWebElement elem_logo;
     

        [FindsBy(How = How.CssSelector, Using = "#search_query_top")]
        private IWebElement elem_search;

      
        [FindsBy(How = How.XPath, Using = "//h1[ contains(text(),'Search') ]//span[contains(text(),'\"Printed Chiffon Dress\"')]")]
        private IWebElement elem_search_result_title;


        [FindsBy(How = How.XPath, Using = 
            "//body/div[@id='page']/div[2]/div[1]/div[3]/div[2]/ul[1]/li[1]/div[1]/div[1]/div[1]/a[@title='Printed Chiffon Dress']")]
        private IWebElement elem_item_first_result;

        //
        [FindsBy(How = How.CssSelector, Using = "#contact-link a")]
        private IWebElement elem_support;



        public String getPageTitle()
        {
            return driver.Title;
        }
        private void selectNextWindow()
        {

            driver.SwitchTo().Window(driver.WindowHandles[2]);

        }
        public void verifyQuantity()
        {
            var txt_quantity = wait.Until(ExpectedConditions.ElementToBeClickable(elem_quantitty));
            Assert.IsNotNull(txt_quantity);
        }
        public void verifyDesciption()
        {
            var txt_desciption = wait.Until(ExpectedConditions.ElementToBeClickable(elem_descritpion));
            Assert.IsNotNull(txt_desciption);
        }
        public void searchItem(string item)
        {
            var input_search = wait.Until(ExpectedConditions.ElementToBeClickable(elem_search));
            moveToElement(input_search, driver);
            input_search.Clear();
            input_search.SendKeys(item);
            input_search.Click();
            input_search.SendKeys(Keys.Enter);
        }

        public void assertSearchResult()
        {
            var txt_search_result = wait.Until(ExpectedConditions.ElementToBeClickable(elem_search_result_title));
            Assert.IsNotNull(txt_search_result);

            var elem_first = wait.Until(ExpectedConditions.ElementToBeClickable(elem_item_first_result));
            Assert.IsNotNull(elem_first);
        }
        public void open_support_page()
        {
            var btn_support = wait.Until(ExpectedConditions.ElementToBeClickable(elem_support));
            moveToElement(btn_support, driver);
            btn_support.Click();
        }

    }
}
