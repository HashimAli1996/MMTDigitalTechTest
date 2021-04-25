using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using MMTDigitalTechTest.PageObjects;

namespace MMTDigitalTechTest.UserStories
{
    public class AC3 : BaseTest
    {
        public AC3(string browser) : base(browser)
        {

        }

        protected static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = InitialiseDriver();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();
        }

        [Test, Order(1)]
        [Description("Scenario 1: Whilst Logged in, when user adds item to empty basket it changes button state and creates a counter with the value 1")]
        public void AddProductToCart()
        {
            ProductPage productPage = new ProductPage(driver);

            //add product
            productPage.AddProduct1();

            //assert add to cart button changes to remove button
            Assert.IsTrue(productPage.RemoveFromCartBtn().Displayed);

            //Assert Counter is 1
            Assert.IsTrue(productPage.BasketCounter().Text == "1");

        }

        [Test, Order(2)]
        [Description("Scenario 1: Whilst Logged in, when user adds item to empty basket it changes button state and creates a counter with the value 1")]
        public void AddMultipleProducts()
        {
            ProductPage productPage = new ProductPage(driver);
            //Add product and assert Counter is 1
            productPage.AddProduct1();
            Assert.IsTrue(productPage.BasketCounter().Text == "1");

            //Add another item and confirm counter increments
            productPage.AddProduct2();

            //Assert Counter is 2
            Assert.IsTrue(productPage.BasketCounter().Text == "2");

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}