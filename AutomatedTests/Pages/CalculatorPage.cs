using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class CalculatorPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public CalculatorPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;

            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not CalculatorPage");
            }
        }

        public IPage ClickCalculatorNumber(KeyNumber key)
        {
            switch (key)
            {
                case KeyNumber.one:
                    Driver.FindElement(By.Name("one")).Click();
                    break;

                case KeyNumber.two:
                    Driver.FindElement(By.Name("two")).Click();
                    break;

                case KeyNumber.three:
                    Driver.FindElement(By.Name("three")).Click();
                    break;

                case KeyNumber.four:
                    Driver.FindElement(By.Name("four")).Click();
                    break;

                case KeyNumber.five:
                    Driver.FindElement(By.Name("five")).Click();
                    break;

                case KeyNumber.six:
                    Driver.FindElement(By.Name("six")).Click();
                    break;

                case KeyNumber.seven:
                    Driver.FindElement(By.Name("seven")).Click();
                    break;

                case KeyNumber.eight:
                    Driver.FindElement(By.Name("eight")).Click();
                    break;

                case KeyNumber.nine:
                    Driver.FindElement(By.Name("nine")).Click();
                    break;

                case KeyNumber.zero:
                    Driver.FindElement(By.Name("zero")).Click();
                    break;

                case KeyNumber.plus:
                    Driver.FindElement(By.Name("plus")).Click();
                    break;

                case KeyNumber.minus:
                    Driver.FindElement(By.Name("minus")).Click();
                    break;

                case KeyNumber.times:
                    Driver.FindElement(By.Name("times")).Click();
                    break;

                case KeyNumber.div:
                    Driver.FindElement(By.Name("div")).Click();
                    break;

                case KeyNumber.DoIt:
                    Driver.FindElement(By.Name("DoIt")).Click();
                    break;
            }
            return PagesFactory.CreatePage(PageType.CalculatorPage);
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

        public string CheckCalcInputValue()
        {
            string result = Driver.FindElement(By.Name("Input")).GetAttribute("value");
            return result;
        }
    }
}
