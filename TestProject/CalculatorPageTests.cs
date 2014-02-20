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
        private IWebDriver driver;
        //private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Logger Logger { get; set; }
        private string TestName { get; set; }
        private ConstantValues Constant { get; set; }

        IPage m_currentlytestingPage;

        [TestInitialize]
        public void SetupTest()
        {
            this.Logger = new Logger();
            driver = new FirefoxDriver();
            baseURL = "http://vm-at-qaevent13.fp.lan:81/";
            driver.Navigate().GoToUrl(baseURL);
            this.Logger.AddNewLog("Nastapila zmiana strony", baseURL);
            this.Logger.SaveLogs("Inicjalizator");
//Navigate to calculator page
            var page = new Helper(driver);
            (page as Helper).LoginWithLoginButton();
            var log = PagesFactory.CreatePage(PageType.LoginPage, this.driver,"Log in - My ASP.NET MVC Application");
            (log as LoginPage).LogInFunction("Automation", "Automation");
            var func = PagesFactory.CreatePage(PageType.FunctionsPage, this.driver,"Functions - My ASP.NET MVC Application");
            (func as FunctionsPage).GoToCalcPage();
            m_currentlytestingPage = PagesFactory.CreatePage(PageType.FunctionsPage, this.driver, "Calculator - My ASP.NET MVC Application");

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
        public void Testowa()
        {
            
            (m_currentlytestingPage as CalculatorPage).ClickCalculatorNumber(KeyNumber.one);

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
