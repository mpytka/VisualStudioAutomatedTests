using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public static class PagesFactory
    {
        public static IPage CreatePage(PageType pt, IWebDriver iwd, string pageName)
        {
            switch (pt)
            {
                case PageType.Home:
                    if (pageName == "") pageName = "Agenda: - My ASP.NET MVC Application";
                   return new Home(iwd, pageName);

                case PageType.AboutPage:
                    if (pageName == "") pageName = "About - My ASP.NET MVC Application";
                    return new AboutPage(iwd, pageName);
                case PageType.ButtonClickPage:
                    if (pageName == "") pageName = "ButtonClick - My ASP.NET MVC Application";
                    return new ButtonClickPage(iwd, pageName);
                case PageType.CalculatorPage:
                    if (pageName == "") pageName = "Calculator - My ASP.NET MVC Application";
                    return new CalculatorPage(iwd, pageName);
                case PageType.LoginPage:
                    if (pageName == "") pageName = "Log in - My ASP.NET MVC Application";
                    return new LoginPage(iwd, pageName);
                case PageType.LoginNewPage:
                    if (pageName == "") pageName = "Log in NEW - My ASP.NET MVC Application";
                    return new LoginNewPage(iwd, pageName);
                case PageType.ContactPage:
                    if (pageName == "") pageName = "Contact - My ASP.NET MVC Application";
                    return new ContactPage(iwd, pageName);
                case PageType.FunctionsPage:
                    if (pageName == "") pageName = "Functions - My ASP.NET MVC Application";
                    return new FunctionsPage(iwd, pageName);
                case PageType.ConcatPage:
                    if (pageName == "") pageName = "Concat - My ASP.NET MVC Application";
                    return new ConcatPage(iwd, pageName);
                default:
                    break;
            }
            return null;
        }
    }
}
