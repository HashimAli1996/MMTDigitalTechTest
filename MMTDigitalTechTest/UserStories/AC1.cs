using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using MMTDigitalTechTest.PageObjects;

namespace MMTDigitalTechTest.UserStories
{
    public class AC1 : BaseTest
    {
        public AC1(string browser) : base(browser)
        {

        }

        protected static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = InitialiseDriver();
        }

        [Test]
        public void validusrpwd()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();

            

            Assert.IsTrue(driver.Url == "https://www.saucedemo.com/inventory.html");
            commonUtils.PrintLogs("browser", driver);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
