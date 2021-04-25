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

        [Test, Order(1)]
        [Description("Scenario 1: Clicking 'Log in' with no username or password")]
        public void UsernameRequiredScenario()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.NoUsrNoPwd();
            //below the assert tries matching the expected error message against the error message of the element at each state.
            Assert.AreEqual("Epic sadface: Username is required", loginPage.pullErrorMsg());
            commonUtils.PrintLogs("browser", driver);
        }

        [Test, Order(2)]
        [Description("Scenario 2: Username entered but no password")]
        public void PasswordRequiredScenario()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.UserNoPwd();
            //below the assert tries matching the expected error message against the error message of the element at each state.
            Assert.AreEqual("Epic sadface: Password is required", loginPage.pullErrorMsg());
            commonUtils.PrintLogs("browser", driver);
        }

        [Test, Order(3)]
        [Description("Scenario 3: Incorrect details entered ")]
        public void IncorrectDetailsScenario()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.IncorrectDetails();
            //below the assert tries matching the expected error message against the error message of the element at each state.
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", loginPage.pullErrorMsg());
            commonUtils.PrintLogs("browser", driver);
        }



        [Test, Order(4)]
        [Description("Scenario 4: Entering Correct username and password directs user to product page")]
        public void ValidDetailsScenario()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();
            //As this is the correct details scenario, the assert checks to see if the URL of the page the user is redirected to is correct
            //if false, it could mean the username and password was not accepted or the user faced another error
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
