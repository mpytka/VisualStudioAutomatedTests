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
    public class Login
    {
        private IWebDriver driver;
        
        //konstruktor
        public Login(IWebDriver dr)
        {
            driver = dr;

            string defaultTitle = "Log in - My ASP.NET MVC Application";
            string actualTitle = dr.Title;

            if (!defaultTitle.Equals(actualTitle))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not Login Page");
            }
        }

        public Functions LogInFunction(string userName, string userPassword)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.LinkText("Log in"))).Click();
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys(userName);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(userPassword);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return new Functions(driver);
        }

    }
}
