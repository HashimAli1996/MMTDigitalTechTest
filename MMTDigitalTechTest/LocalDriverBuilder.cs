using System;
using System.Collections.Generic;
using System.Text;
using MMTDigitalTechTest.SeleniumUtils.Wrappers;
using OpenQA.Selenium;

namespace MMTDigitalTechTest.SeleniumUtils
{
    public class LocalDriverBuilder
    {

        private readonly WebDriverFactory factory;

        internal LocalDriverBuilder(WebDriverFactory factory)
        {
            this.factory = factory;
        }

        public virtual IWebDriver Launch(string browserTarget, string startingUrl)
        {
            var driver = CreateWebDriver(browserTarget);
            driver.Navigate().GoToUrl(startingUrl);
            return driver;
        }

        private IWebDriver CreateWebDriver(string browserTarget)
        {
            switch (browserTarget)
            {
                case BrowserTarget.Chrome:
                    return factory.CreateLocalChromeDriver();
                //case BrowserTarget.Edge:
                //    return factory.CreateLocalEdgeDriver();
                //case BrowserTarget.Firefox:
                //    return factory.CreateLocalFirefoxDriver();
                //case BrowserTarget.Safari:
                //    return factory.CreateLocalSafariDriver();
                default:
                    throw new NotSupportedException($"{browserTarget} is not supported local browser type.");
            }
        }

    }
}
