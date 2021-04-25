﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MMTDigitalTechTest.PageObjects
{
    public class ProductPage
    {
        public IWebDriver driver;
        WebDriverWait wait;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        private IWebElement c => driver.FindElement(By.Id("x"));


        public void x()
        {

        }



    }
}