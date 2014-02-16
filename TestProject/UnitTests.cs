using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTests;

namespace TestProject
{
    [TestClass]
    public class UnitTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://vm-at-qaevent13.fp.lan:81/";
            driver.Navigate().GoToUrl(baseURL);

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
        public void ChecksLoggingInToTheFunctionPage()
        {
            var login = new Login(driver);
            login.LogIn("Automation", "Automation");
            
        }

        [TestMethod]
        public void ChecksTheResultOfTheCalculation()
        {
            //arrange
            var login = new Login(driver);
            var func = new Functions(driver);
            var calc = new Calculator(driver);
           
            //act
            login.LogIn("Automation", "Automation");
            func.NavigateToCalcPage();
            calc.ClickCalculatorNumber(KeyNumber.one);
            calc.ClickCalculatorNumber(KeyNumber.plus);
            calc.ClickCalculatorNumber(KeyNumber.two);
            calc.ClickCalculatorNumber(KeyNumber.DoIt);
            
            //assert
            Assert.AreEqual("3", calc.CheckCalcInputValue());
        }

        [TestMethod]
        public void ChecksIfCombineButtonAddsStringsToEachOther()
        {
            //arrange

            var login = new Login(driver);
            var func = new Functions(driver);
            var concat = new ConCat(driver);

            //act

            login.LogIn("Automation", "Automation");
            func.NavigateToConCatPage();

            concat.InputString(StringsToInput.Windows);

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
