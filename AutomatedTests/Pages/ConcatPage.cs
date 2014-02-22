using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class ConcatPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public ConcatPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;

            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not Concat Page");
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

                case PageType.ContactPage:
                    var waitForContactLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForContactLink.Until(r => r.FindElement(By.LinkText("About"))).Click();
                    return PagesFactory.CreatePage(PageType.ContactPage);

                case PageType.HomeWithLogOff:
                    var waitForLogOffLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForLogOffLink.Until(r => r.FindElement(By.Name("Log off"))).Click();
                    return Pages.PagesFactory.CreatePage(Pages.PageType.Home);

                case PageType.FunctionsPage:
                    var waitForFunctionsLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForFunctionsLink.Until(r => r.FindElement(By.LinkText("Functions"))).Click();
                    return PagesFactory.CreatePage(PageType.FunctionsPage);

                default:
                    break;
            }
            return null;
        }

        public IPage ClickCombineButton()
        {
            Driver.FindElement(By.Id("but")).Click();
            return this;
        }

        public IPage EnterText(string FieldName, string Text)
        {
            Driver.FindElement(By.Name(FieldName)).Clear();
            Driver.FindElement(By.Name(FieldName)).SendKeys(Text);
            return this;
        }
    }
}
