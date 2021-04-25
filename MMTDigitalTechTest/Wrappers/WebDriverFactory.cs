using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Microsoft.Edge.SeleniumTools;

namespace MMTDigitalTechTest.SeleniumUtils.Wrappers
{
    internal class WebDriverFactory
    {
        protected static IWebDriver driver;

        public virtual IWebDriver CreateLocalChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");
            return new ChromeDriver(options);            
        }

        public virtual IWebDriver CreateLocalFirefoxDriver()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        public virtual IWebDriver CreateLocalEdgeDriver()
        {
            var options = new EdgeOptions();
            options.UseChromium = true;
            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public virtual IWebDriver CreateLocalIEDriver()
        {
            driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            return driver;

        }


    }
}
