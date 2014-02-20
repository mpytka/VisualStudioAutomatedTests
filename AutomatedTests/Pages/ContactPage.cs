using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public class ContactPage : IPage
    {
        public IWebDriver Driver { get; set; }
        public string PageName { get; set; }

        public ContactPage(IWebDriver iwd, string pageName)
        {
            this.Driver = iwd;
            this.PageName = pageName;

            this.CheckPageName();
        }

        public void CheckPageName()
        {
            if (!this.Driver.Title.Equals(this.PageName))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded! It is not Contact Page");
            }
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
