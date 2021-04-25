using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MMTDigitalTechTest.PageObjects
{
    public class ProductPage
    {
        public IWebDriver driver;
        private WebDriverWait wait;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private IWebElement basketCounter => driver.FindElement(By.XPath("//div[@id='shopping_cart_container']/a/span"));
        private IWebElement item1addToCartBtn => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement removeFromCartBtn => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        private IWebElement sidemenuBtn => driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement resetBtn => driver.FindElement(By.Id("reset_sidebar_link"));
        private IWebElement item2addToCartBtn => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));


        public void x()
        {

        }

        public IWebElement BasketCounter()
        {
            return basketCounter;
        }

        public void AddProduct1()
        {
            item1addToCartBtn.Click();
        }

        public IWebElement RemoveFromCartBtn()
        {
            return removeFromCartBtn;
        }

        public void ResetPage()
        {
            sidemenuBtn.Click();
            resetBtn.Click();
            sidemenuBtn.Click();
        }

        public void AddProduct2()
        {
            item2addToCartBtn.Click();
        }
    }
}
