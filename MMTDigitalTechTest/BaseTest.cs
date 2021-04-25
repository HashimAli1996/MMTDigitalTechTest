using NUnit.Framework;
using OpenQA.Selenium;
using MMTDigitalTechTest.SeleniumUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMTDigitalTechTest
{
    [TestFixture(BrowserTarget.Chrome)]
    [TestFixture(BrowserTarget.Firefox)]
    [TestFixture(BrowserTarget.Edge)]
    //[TestFixture(BrowserTarget.IE)]
    //[Parallelizable(ParallelScope.All)]
    public abstract class BaseTest
    {
        protected LocalDriverBuilder builder;
        protected string startingUrl;
        protected string epochStartTime;
        protected string targetBrowser;
        protected CommonUtils commonUtils = new CommonUtils();

        protected BaseTest(string browser)
        {
            this.targetBrowser = browser;
            this.epochStartTime = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
        }

        public IWebDriver InitialiseDriver()
        {
            LocalDriverBuilder builder = new LocalDriverBuilder();
            this.startingUrl = "https://www.saucedemo.com/";
            var driver = builder.Launch(targetBrowser, this.startingUrl);
            return driver;
        }
    }
}
