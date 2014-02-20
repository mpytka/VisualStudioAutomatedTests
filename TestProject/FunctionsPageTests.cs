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
    public class FunctionsPageTests
    {
        private IWebDriver driver;
        //private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Logger Logger { get; set; }
        private string TestName { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Logger = new Logger();
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            string URL = ConstantValues.BaseURL();
            baseURL = "http://vm-at-qaevent13.fp.lan:81/";
            driver.Navigate().GoToUrl(baseURL);
            this.Logger.AddNewLog("Nastapila zmiana strony", baseURL);
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
        public void Testowa()
        {
            var page = PagesFactory.CreatePage(PageType.Home, this.driver, "Agenda: - My ASP.NET MVC Application");
            // tu trzeba kliknac w loguj z helpera  AutomatedTests.Helper.
            var log = PagesFactory.CreatePage(PageType.LoginPage, this.driver, "Log in - My ASP.NET MVC Application");
            (log as LoginPage).LogInFunction("Automation", "Automation");
            var func = PagesFactory.CreatePage(PageType.FunctionsPage, this.driver, "Functions - My ASP.NET MVC Application");
            (func as FunctionsPage).GoToCalcPage();
            var calc = PagesFactory.CreatePage(PageType.FunctionsPage, this.driver, "Calculator - My ASP.NET MVC Application");
            (calc as CalculatorPage).ClickCalculatorNumber(KeyNumber.one);

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
