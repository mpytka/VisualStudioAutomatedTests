using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class AboutPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public AboutPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;
            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not AboutPage");
            }
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
                
                default:
                    break;
            }
            return null;
        }
    }
}
