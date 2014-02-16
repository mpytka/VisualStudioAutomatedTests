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
    public class Homepage
    {
        private IWebDriver driver;

        public Homepage(IWebDriver dr)
        {
            driver = dr;

            string defaultTitle = "Agenda: - My ASP.NET MVC Application";
            string actualTitle = dr.Title;

            if (!defaultTitle.Equals(actualTitle))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded!");
            }

        }

        public Login LoginButton()
        {
            driver.FindElement(By.XPath("//a[@href='/Account/Login']")).Click();
            return new Login(driver);
        }

        public Login LoginNEWButton()
        {
            driver.FindElement(By.XPath("//a[@href='/Account/LoginNew']")).Click();
            return new Login(driver);
        }


    }
}
