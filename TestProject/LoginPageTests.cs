using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTests;
using WebLogger;
using AutomatedTests.Pages;


namespace TestProject
{
    [TestClass]
    public class LoginPageTests
    {
        public IWebDriver driver;
        private bool acceptNextAlert = true;
        public Logger Logger { get; set; }
        private string TestName { get; set; }
        IPage m_currentlytestingPage;

        [TestInitialize]
        public void SetupTest()
        {
            this.Logger = new Logger();
            driver = new FirefoxDriver();
            PagesFactory.Configure(driver);
            driver.Navigate().GoToUrl(WellKnownValues.baseURL);
            this.Logger.AddNewLog("Nastapila zmiana strony", WellKnownValues.baseURL);
            this.Logger.SaveLogs("Inicjalizator");
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        [TestMethod]
        public void Name()
        {


        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
