using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace MMTDigitalTechTest.SeleniumUtils.Wrappers
{
    internal class WebDriverFactory
    {
        public virtual IWebDriver CreateLocalChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");
            return new ChromeDriver(options);            
        }

        //public virtual void CreateLocalFirefoxDriver()
        //{

            
        //}

        //public virtual void CreateLocalEdgeDriver()
        //{


        //}

        //public virtual void CreateLocalSafariDriver()
        //{


        //}


    }
}
