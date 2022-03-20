using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectReportingOOP.BasePage
{
    public class WebDriverFactory
    {

        public static IWebDriver driver { get; set; }

        public static IWebDriver Create(String browserType)
        {
            IWebDriver driver;
            switch (browserType)
            {
                case "Firefox":
                    var profile = new FirefoxProfile();
                    profile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "dev_authorizetionservicentlm");
                    var opts = new FirefoxOptions();
                    opts.Profile = profile;
                    //opts.UseLegacyImplementation = true;
                    driver = new FirefoxDriver(opts);
                    break;
                case "Chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    options.AddArguments("disable-infobars");
                    options.AddArguments("no-sandbox");
                    options.AddArguments("disable-extensions");
                    driver = new ChromeDriver(options);
                    driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    var ieOptions = new InternetExplorerOptions
                    {
                        BrowserCommandLineArguments = "-private",
                        EnsureCleanSession = true
                    };
                    driver = (IWebDriver)new InternetExplorerDriver();
                    break;
                default:
                    throw new InvalidOperationException("Unable to find driver for '" + browserType);
            }
            
            return driver;
        }
    }

}
