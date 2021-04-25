using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using MMTDigitalTechTest.PageObjects;

namespace MMTDigitalTechTest.UserStories
{
    public class AC2 : BaseTest
    {
        public AC2(string browser) : base(browser)
        {

        }

        protected static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = InitialiseDriver();
        }

        [Test, Order(1)]
        [Description("Scenario 1: Whilst focussed on Username field, hitting tab directs user to password field")]
        public void UsernameFocusTabKey()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.FocusElement(loginPage.UsernameField());
            loginPage.ClickTab(loginPage.UsernameField());

            //Checks that the goal element is the same as the element which is currently being focussed on in webdriver state
            Assert.AreEqual(loginPage.PasswordField(), driver.SwitchTo().ActiveElement());
        }

        [Test, Order(2)]
        [Description("Scenario 2: Whilst focussed on Password field, hitting tab directs user to Log In Button")]
        public void PasswordFocusTabKey()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.FocusElement(loginPage.PasswordField());
            loginPage.ClickTab(loginPage.PasswordField());

            //Checks that the goal element is the same as the element which is currently being focussed on in webdriver state
            Assert.AreEqual(loginPage.LogInButton(), driver.SwitchTo().ActiveElement());
        }

        [Test, Order(3)]
        [Description("Scenario 3: with the Log In button in focus, hitting enter will attempt to log user in through AC1 Scenarios ")]
        public void LogInBtnFocusEnterKey()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ACCESSIBILITYNoUsrNoPwd();
            //below the assert tries matching the expected error message against the error message of the element at each state.
            Assert.AreEqual("Epic sadface: Username is required", loginPage.pullErrorMsg());

            loginPage.ACCESSIBILITYUserNoPwd();
            Assert.AreEqual("Epic sadface: Password is required", loginPage.pullErrorMsg());

            loginPage.ACCESSIBILITYIncorrectDetails();
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", loginPage.pullErrorMsg());

            loginPage.ACCESSIBILITYLogin();
            Assert.IsTrue(driver.Url == "https://www.saucedemo.com/inventory.html");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
