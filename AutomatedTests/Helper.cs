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
        private IWebDriver Driver;
        public string PageName { get; set; }

        public Helper(IWebDriver iwd)
        {
            this.Driver = iwd;
        }

        public Pages.IPage LogOffButton()
        {
            this.Driver.FindElement(By.Name("Log off")).Click();
            return Pages.PagesFactory.CreatePage(Pages.PageType.LoginPage, Driver, PageName);
        }

        public Pages.IPage LoginWithLoginButton()
        {
            this.Driver.FindElement(By.XPath("//a[@href='/Account/Login']")).Click();
            return Pages.PagesFactory.CreatePage(Pages.PageType.LoginPage, Driver, PageName);
        }

        public Pages.IPage LoginWithNEWButton()
        {
            this.Driver.FindElement(By.XPath("//a[@href='/Account/LoginNew']")).Click();
            return Pages.PagesFactory.CreatePage(Pages.PageType.LoginPage, Driver, PageName);
        }

    }
}
