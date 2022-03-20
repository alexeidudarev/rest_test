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
using NUnit.Framework;

namespace projectReportingOOP.PageObject
{
    public class HomePage : BasePageObject
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        String home_url = "http://automationpractice.com/index.php";

        public HomePage(IWebDriver driver,WebDriverWait wait) : base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = ".product_img_link")]
        private IWebElement elem_random_item;

       
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Add to cart')]")]
        private IWebElement elem_add_to_cart;

        [FindsBy(How = How.XPath, Using = "//*[@title='Proceed to checkout']")]
        private IWebElement elem_proceed_toCheckout;
       

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Product successfully added to your shopping cart')]")]
        private IWebElement elem_item_added;

        //Methods

        public void addItemToBasket()
        {
            var elem_item = wait.Until(ExpectedConditions.ElementToBeClickable(elem_random_item));
            mouseHover(elem_random_item,driver);
            elem_item.Click();

            var btn_add_to_cart = wait.Until(ExpectedConditions.ElementToBeClickable(elem_add_to_cart));
            elem_item.Click();

        }
        public void itemAddedSuccessfully()
        {
            var txtSuccess = wait.Until(ExpectedConditions.ElementToBeClickable(elem_item_added));
            Assert.IsNotNull(txtSuccess);
        }
        public void proceed_to_checkout()
        {
            var elem_checkout = wait.Until(ExpectedConditions.ElementToBeClickable(elem_proceed_toCheckout));
            moveToElement(elem_proceed_toCheckout, driver);
            elem_checkout.Click();
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
