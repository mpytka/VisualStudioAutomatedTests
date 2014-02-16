using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using AutomatedTests;

namespace AutomatedTests
{
    
    public class Functions
    {
        private IWebDriver driver;
        const string baseURL = "http://vm-at-qaevent13.fp.lan:81/";
        public Functions(IWebDriver dr)
        {
            driver = dr;
        }


        public Calculator GoToCalcPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(r => r.FindElement(By.LinkText("Calculator"))).Click();
            return new Calculator(driver);
        }

        public ConCat GoToConCatPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(r => r.FindElement(By.LinkText("Concat"))).Click();
            return new ConCat(driver);
        }

        public ButtonClick GoToButtonClickPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(r => r.FindElement(By.LinkText("ButtonClick"))).Click();
            return new ButtonClick(driver);
        }

        public ConCat NavigateToConCatPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/Functions/Concat");
            return new ConCat(driver);
        }

        public Calculator NavigateToCalcPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/Functions/Calculator");
            return new Calculator(driver);
        }

        public ButtonClick NavigateToButtonClickPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/Functions/ButtonClick");
            return new ButtonClick(driver);
        }
        
    }
}
