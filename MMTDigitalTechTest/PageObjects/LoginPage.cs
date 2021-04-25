using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MMTDigitalTechTest.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;
        WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        private IWebElement usernameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginBtn => driver.FindElement(By.Id("login-button"));

        public void Login()
        {
            usernameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginBtn.Click();
        }



    }
}
