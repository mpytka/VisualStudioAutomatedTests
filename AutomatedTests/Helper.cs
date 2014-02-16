using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using AutomatedTests;

namespace AutomatedTests
{
    public class Helper
    {
        private IWebDriver driver;

        public Helper(IWebDriver dr)
        {
            driver = dr;
        }

        public Homepage LogOffButton()
        {
            driver.FindElement(By.Name("Log off")).Click();
            return new Homepage(driver);
        }
    }
}
