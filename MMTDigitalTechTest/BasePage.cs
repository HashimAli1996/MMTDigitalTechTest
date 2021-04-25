using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace MMTDigitalTechTest
{

    [TestFixture]
    public class BasePage
    {
        public static IWebDriver driver;
        private WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            BasePage.driver = driver;
        }

        public BasePage() { }

        public void runDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-infobars");

            driver = new ChromeDriver(options);
        }

        [TearDown]
        public void cleanUp()
        {
            Console.WriteLine("cleaning driver....");
            driver.Quit();
            driver.Dispose();
        }

        public void WaitForElementById(String id)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public void WaitForElement(String xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void WaitForElementToBeClickable(String locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
        }


    }
}
