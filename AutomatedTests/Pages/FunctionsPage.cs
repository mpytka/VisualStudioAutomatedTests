using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class FunctionsPage : IPage
    {
        const string baseURL = "http://vm-at-qaevent13.fp.lan:81/";
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public FunctionsPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;

            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not Functions Page");
            }
        }

        public IPage NavigateToPage(PageType nextPage)
        {
            switch (nextPage)
            {
                case PageType.ButtonClickPage:
                    var waitForButtonClickLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForButtonClickLink.Until(r => r.FindElement(By.LinkText("ButtonClick"))).Click();
                    return PagesFactory.CreatePage(PageType.ButtonClickPage);
                
                case PageType.CalculatorPage:
                    var waitForCalculatorLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    waitForCalculatorLink.Until(r => r.FindElement(By.LinkText("Calculator"))).Click();
                    return PagesFactory.CreatePage(PageType.CalculatorPage);
                
                case PageType.ConcatPage:
                     var waitForConcatLink = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                     waitForConcatLink.Until(r => r.FindElement(By.LinkText("Concat"))).Click();
                     return PagesFactory.CreatePage(PageType.ConcatPage);

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
                
                //stad da sie dostac do home page rowniez za pomoca logoff
                default:
                    break;
            }
            return null;
        }

        //Navigate to page using URL
        public IPage NavigateToConCatPage()
        {
            Driver.Navigate().GoToUrl(baseURL + "/Functions/Concat");
            return PagesFactory.CreatePage(PageType.ConcatPage);
        }

        public IPage NavigateToCalcPage()
        {
            Driver.Navigate().GoToUrl(baseURL + "/Functions/Calculator");
            return PagesFactory.CreatePage(PageType.CalculatorPage);
        }

        public IPage NavigateToButtonClickPagePage()
        {
            Driver.Navigate().GoToUrl(baseURL + "/Functions/ButtonClick");
            return PagesFactory.CreatePage(PageType.ButtonClickPage);
        }
    }
}
