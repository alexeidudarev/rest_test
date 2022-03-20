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
    public class Customer_Support : BasePageObject
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public Customer_Support(IWebDriver driver, WebDriverWait wait) : base(driver)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        //elemnts 
        [FindsBy(How = How.CssSelector, Using = "#id_contact")]
        private IWebElement elem_customer_select;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement elem_email;
       
        [FindsBy(How = How.CssSelector, Using = "#message")]
        private IWebElement el_message;

        [FindsBy(How = How.CssSelector, Using = "#submitMessage")]
        private IWebElement elem_submit;

        //.alert.alert-success
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success")]
        private IWebElement elem_succeess;

        //Methods

        public void send_suport_form()
        {
            var select_subject = wait.Until(ExpectedConditions.ElementToBeClickable(elem_customer_select));
            moveToElement(select_subject, driver);
            var selectElement = new SelectElement(select_subject);
            selectElement.SelectByText("Customer service");

            var elem_mail = wait.Until(ExpectedConditions.ElementToBeClickable(elem_email));
            moveToElement(elem_mail, driver);
            elem_email.Clear();
            elem_email.SendKeys("a@a.com");

            var elem_message = wait.Until(ExpectedConditions.ElementToBeClickable(el_message));
            moveToElement(elem_message, driver);
            elem_email.Clear();
            elem_email.SendKeys("some text");

            var btn_submit = wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit));
            moveToElement(btn_submit, driver);
            btn_submit.Click();
        }

        public void verify_message_submitted()
        {
            var msg_succeess = wait.Until(ExpectedConditions.ElementToBeClickable(elem_succeess));
            Assert.IsNotNull(msg_succeess);
        }

     
        
    }
}
