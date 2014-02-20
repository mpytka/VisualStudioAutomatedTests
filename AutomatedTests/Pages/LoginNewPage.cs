using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class LoginNewPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public LoginNewPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;

            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not LoginNew Page");
            }
        }

        public FunctionsPage LogInFunction(string userName, string userPassword)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.LinkText("Log in"))).Click();
            Driver.FindElement(By.Id("UserName")).Clear();
            Driver.FindElement(By.Id("UserName")).SendKeys(userName);
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys(userPassword);
            Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return new FunctionsPage(Driver, PageName);
        }

        public IPage NavigateToPage(PageType nextPage)
        {
            switch (nextPage)
            {
                case PageType.Home:
                    break;
                case PageType.AboutPage:
                    break;
                case PageType.ButtonClickPage:
                    break;
                case PageType.CalculatorPage:
                    break;
                case PageType.LoginPage:
                    break;
                case PageType.LoginNewPage:
                    break;
                case PageType.ContactPage:
                    break;
                case PageType.FunctionsPage:
                    break;
                case PageType.ConcatPage:
                    break;
                default:
                    break;
            }
            return null;
        }
    
    }
}
