using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace MMTDigitalTechTest.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;
        private WebDriverWait wait;
        private Actions action;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            this.action =  new Actions(driver);
        }

        private IWebElement usernameField => driver.FindElement(By.Id("user-name"));
        private IWebElement passwordField => driver.FindElement(By.Id("password"));
        private IWebElement loginBtn => driver.FindElement(By.Id("login-button"));
        private string errorMsg => driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3")).Text;
        private string username = "standard_user";
        private string password = "secret_sauce";

        public IWebElement PasswordField()
        {
            return passwordField;
        }

        public IWebElement UsernameField()
        {
            return usernameField;
        }

        public IWebElement LogInButton()
        {
            return loginBtn;
        }

        public void ClickTab(IWebElement element)
        {
            element.SendKeys(Keys.Tab);
        }

        public void FocusElement(IWebElement element)
        {
            action.MoveToElement(element).Perform();
        }

        public void ClickEnter(IWebElement webElement)
        {
            webElement.SendKeys(Keys.Enter);
        }

        public String pullErrorMsg()
        {
            return errorMsg;
        }

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

        public void ACCESSIBILITYNoUsrNoPwd()
        {
            FocusElement(loginBtn);
            ClickEnter(loginBtn);
        }

        public void ACCESSIBILITYUserNoPwd()
        {
            usernameField.SendKeys(username);
            FocusElement(loginBtn);
            ClickEnter(loginBtn);
            Clear();
        }

        public void ACCESSIBILITYIncorrectDetails()
        {
            Clear();
            usernameField.SendKeys("beep");
            passwordField.SendKeys("boop");
            FocusElement(loginBtn);
            ClickEnter(loginBtn);
            Clear();
        }

        public void ACCESSIBILITYLogin()
        {
            Clear();
            usernameField.SendKeys(username);
            passwordField.Clear();
            passwordField.SendKeys("secret_sauce");

            FocusElement(loginBtn);
            ClickEnter(loginBtn);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("item_4_img_link")));
        }

        public void Clear()
        {
            usernameField.Clear();
            passwordField.Clear();
        }



    }
}
