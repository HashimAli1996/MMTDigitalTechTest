using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMTDigitalTechTest.PageObjects
{
    class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {
            LoginPage.driver = driver;
        }



    }
}
