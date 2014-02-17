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


namespace TestProject
{
    [TestClass]
    public class UnitTests
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
            //zrobic fabryke stron enumem
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
        public void ChecksLoggingInToTheFunctionPage()
        {
            var login = new Login(driver);
            login.LogInFunction("Automation", "Automation");
            
        }
        
        //testowe, nieczytelne, ze ja pierdole
        [TestMethod]
        public void ChecksTheResultOfTheCalculation()
        {
            //arrange
            this.Logger = new Logger();
            //testcontext - do wyciagniecia (do spr)  !!!!!!!!!!!!!!!!
            this.TestName = "ChecksTheResultOfTheCalculation";
            //na potrzebe testu czy działa
            for (int i = 0; i < 100; i++)
            {
                this.Logger.AddNewLog("TESTLOG - CheckTheResultOfTheCalculation", i.ToString());
            }
            Homepage home = new Homepage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.LinkText("Log in")));
            Login login = home.LoginWithLoginButton();
            Functions func = login.LogInFunction("Automation", "Automation");
            Calculator calc = func.NavigateToCalcPage();
            calc.ClickCalculatorNumber(KeyNumber.one);
            calc.ClickCalculatorNumber(KeyNumber.plus);
            calc.ClickCalculatorNumber(KeyNumber.two);
            calc.ClickCalculatorNumber(KeyNumber.DoIt);
            
            //assert
            Assert.AreEqual("3", calc.CheckCalcInputValue());
        }

       //bez asercji, dla testow czy sie tekst wpiesuje
        [TestMethod]
        public void EntersTextToTextbox()
        {
            Homepage home = new Homepage(driver);
            Login login = home.LoginWithLoginButton();
            Functions func = login.LogInFunction("Automation", "Automation");
            ConCat concat = func.NavigateToConCatPage();
            concat.EnterText("textbox1", "Test");
            
        }

        [TestMethod]
        public void ChecksIfCombineButtonAddsStringsToEachOther()
        {
            //arrange

            var login = new Login(driver);
            var func = new Functions(driver);
            var concat = new ConCat(driver);

            //act

            login.LogInFunction("Automation", "Automation");
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
