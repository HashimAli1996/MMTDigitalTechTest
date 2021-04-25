using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MMTDigitalTechTest.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        private IWebElement usernameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginBtn => driver.FindElement(By.Id("login-button"));
        private string errorMsg => driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3")).Text;
        private string username = "standard_user";
        private string password = "secret_sauce";

        public void NoUsrNoPwd()
        {
            loginBtn.Click();
        }

        public void UserNoPwd()
        {
            usernameField.SendKeys(username);
            loginBtn.Click();
        }

        public void IncorrectDetails()
        {
            usernameField.SendKeys("beep");
            passwordField.SendKeys("boop");
            loginBtn.Click();
        }

        public void Login()
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginBtn.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("item_4_img_link")));
        }

        public String pullErrorMsg()
        {
            return errorMsg;
        }



    }
}
