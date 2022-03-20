using projectReportingOOP.BaseTest;
using projectReportingOOP.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectReportingOOP.BasePage
{
    public class BasePageObject : BaseTests
    {
     
        protected IWebDriver driver;
        private IJavaScriptExecutor js;


        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
            js = (IJavaScriptExecutor)driver;

            
            ChromeOptions options = new ChromeOptions();                     
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
        }

        public static void Click(IWebElement el,IWebDriver driver)

        {
             IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
             js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid Lime;');", el);
            
            try
            {
                el.Click();
            }
            catch (Exception ex)
            {
                if (ex is ElementNotVisibleException)
                {
                    js.ExecuteScript("arguments[0].click();", el);
                }
                else
                {
                    throw ex;
                }

            }
        }


        public void Green_Click(IWebElement el)
        {
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 5px solid Lime;');", el);
         
            try
            {
                el.Click();
            }
            catch (Exception ex)
            {
                if (ex is ElementNotVisibleException)
                {
                    js.ExecuteScript("arguments[0].click();", el);
                }
                else
                {
                    throw ex;
                }
            }
        }
        public static void moveToElement(IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);

            actions.MoveToElement(element);

            actions.Perform();
        }
        public static  void goToPage(String url, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(url);
        }


        public static  String getPageTitle(IWebDriver driver)
        {
            return driver.Title;
        }

        // Checks whether the  Logo is displayed properly or not
        public bool getLTPageLogo(IWebElement element)
        {
            return element.Displayed;
        }

        public void load_complete(int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
