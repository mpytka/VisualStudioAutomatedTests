using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class LoginPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public LoginPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;


            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not Loginpage");
            }
        }

        public IPage LogInFunction(string userName, string userPassword)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.LinkText("Log in"))).Click();
            Driver.FindElement(By.Id("UserName")).Clear();
            Driver.FindElement(By.Id("UserName")).SendKeys(userName);
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys(userPassword);
            Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return PagesFactory.CreatePage(PageType.FunctionsPage);
        }

        public IPage NavigateToPage(PageType nextPage)
        {
            switch (nextPage)
            {
                case PageType.Home:
                    var waitForHomeLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForHomeLink.Until(r => r.FindElement(By.LinkText("Home"))).Click();
                    return PagesFactory.CreatePage(PageType.Home);

                case PageType.AboutPage:
                    var waitForAboutLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForAboutLink.Until(r => r.FindElement(By.LinkText("About"))).Click();
                    return PagesFactory.CreatePage(PageType.AboutPage);

                case PageType.LoginPage:
                    var waitForLoginLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForLoginLink.Until(r => r.FindElement(By.XPath("//a[@href='/Account/Login']"))).Click();
                    return Pages.PagesFactory.CreatePage(Pages.PageType.LoginPage);

                case PageType.LoginNewPage:
                    var waitForLoginNewLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForLoginNewLink.Until(r => r.FindElement(By.XPath("//a[@href='/Account/LoginNew']"))).Click();
                    return Pages.PagesFactory.CreatePage(Pages.PageType.LoginNewPage);

                case PageType.ContactPage:
                    var waitForContactLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForContactLink.Until(r => r.FindElement(By.LinkText("About"))).Click();
                    return PagesFactory.CreatePage(PageType.ContactPage);

                case PageType.FunctionsPage:
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    wait.Until(d => d.FindElement(By.LinkText("Log in"))).Click();
                    Driver.FindElement(By.Id("UserName")).Clear();
                    Driver.FindElement(By.Id("UserName")).SendKeys(WellKnownValues.user);
                    Driver.FindElement(By.Id("Password")).Clear();
                    Driver.FindElement(By.Id("Password")).SendKeys(WellKnownValues.password);
                    Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
                    return PagesFactory.CreatePage(PageType.FunctionsPage);
                
                default:
                    break;
            }
            return null;
        }
        
    
    }
}
