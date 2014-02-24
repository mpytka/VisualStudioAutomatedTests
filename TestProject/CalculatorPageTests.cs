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
    public class CalculatorPageTests
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
            var setvalues = new DataRetrieval();
            setvalues.LoadValues("user", "password"); //wyszukiwanie po tagu w xml
            driver.Navigate().GoToUrl(WellKnownValues.baseURL);
            this.Logger.AddNewLog("Nastapila zmiana strony", WellKnownValues.baseURL);
            this.Logger.SaveLogs("Inicjalizator");

            //arrange
            m_currentlytestingPage = PagesFactory.SetPage(PageType.CalculatorPage);

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
        public void ChecksIfACalculationValueIsCorrect()
        {
            //act
            (m_currentlytestingPage as CalculatorPage).ClickCalculatorNumber(KeyNumber.one);
            (m_currentlytestingPage as CalculatorPage).ClickCalculatorNumber(KeyNumber.plus);
            (m_currentlytestingPage as CalculatorPage).ClickCalculatorNumber(KeyNumber.one);
            (m_currentlytestingPage as CalculatorPage).ClickCalculatorNumber(KeyNumber.DoIt);
            string result = (m_currentlytestingPage as CalculatorPage).CheckCalcInputValue();
            //assert
            Assert.AreEqual("2", result);
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
