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
        private static IWebDriver m_iwd;
        //IPage m_currentlytestingPage;

        public static void Configure(IWebDriver iwd)
        {
            m_iwd = iwd;
        }

        public static IPage CreatePage(PageType pt)
        {
            string pageName = string.Empty;
            switch (pt)
            {
                case PageType.Home:
                   pageName = "Agenda: - My ASP.NET MVC Application";
                   return new Home(m_iwd, pageName);
                case PageType.AboutPage:
                    pageName = "About - My ASP.NET MVC Application";
                    return new AboutPage(m_iwd, pageName);
                case PageType.ButtonClickPage:
                   pageName = "ButtonClick - My ASP.NET MVC Application";
                    return new ButtonClickPage(m_iwd, pageName);
                case PageType.CalculatorPage:
                    pageName = "Calculator - My ASP.NET MVC Application";
                    return new CalculatorPage(m_iwd, pageName);
                case PageType.LoginPage:
                    pageName = "Log in - My ASP.NET MVC Application";
                    return new LoginPage(m_iwd, pageName);
                case PageType.LoginNewPage:
                    pageName = "Log in NEW - My ASP.NET MVC Application";
                    return new LoginNewPage(m_iwd, pageName);
                case PageType.ContactPage:
                    pageName = "Contact - My ASP.NET MVC Application";
                    return new ContactPage(m_iwd, pageName);
                case PageType.FunctionsPage:
                    pageName = "Functions - My ASP.NET MVC Application";
                    return new FunctionsPage(m_iwd, pageName);
                case PageType.ConcatPage:
                    pageName = "Concat - My ASP.NET MVC Application";
                    return new ConcatPage(m_iwd, pageName);
                default:
                    break;
            }
            return null;
        }

        public static IPage SetPage(PageType pt)
        {
            switch (pt)
            {
                case PageType.Home:
                    break;
               
                case PageType.AboutPage:
                    var home = PagesFactory.CreatePage(PageType.Home);
                    home.NavigateToPage(PageType.AboutPage);
                    return PagesFactory.CreatePage(PageType.AboutPage);

                case PageType.ButtonClickPage:
                    var hel = new Helper(m_iwd);
                    hel.LoginWithLoginButton();
                    var loginpag = PagesFactory.CreatePage(PageType.LoginPage);
                    loginpag.NavigateToPage(PageType.FunctionsPage);
                    var fun = PagesFactory.CreatePage(PageType.FunctionsPage);
                    fun.NavigateToPage(PageType.ButtonClickPage);
                    return PagesFactory.CreatePage(PageType.ButtonClickPage);
                
                case PageType.CalculatorPage:
                    var helpe = new Helper(m_iwd);
                    helpe.LoginWithLoginButton();
                    var loginpa = PagesFactory.CreatePage(PageType.LoginPage);
                    loginpa.NavigateToPage(PageType.FunctionsPage);
                     var funcp = PagesFactory.CreatePage(PageType.FunctionsPage);
                    funcp.NavigateToPage(PageType.CalculatorPage);
                    return PagesFactory.CreatePage(PageType.CalculatorPage);
               
                case PageType.LoginPage:
                    var helper = new Helper(m_iwd);
                    helper.LoginWithLoginButton();
                    return PagesFactory.CreatePage(PageType.LoginPage);
                
                case PageType.LoginNewPage:
                    break;
                case PageType.ContactPage:
                    break;
                
                case PageType.FunctionsPage:
                   var page = new Helper(m_iwd);
                    page.LoginWithLoginButton();
                    var log = PagesFactory.CreatePage(PageType.LoginPage);
                    log.NavigateToPage(PageType.FunctionsPage);
                    return PagesFactory.CreatePage(PageType.FunctionsPage);
               
                case PageType.ConcatPage:
                    var help = new Helper(m_iwd);
                    help.LoginWithLoginButton();
                    var loginp = PagesFactory.CreatePage(PageType.LoginPage);
                    loginp.NavigateToPage(PageType.FunctionsPage);
                    var functions = PagesFactory.CreatePage(PageType.FunctionsPage);
                    functions.NavigateToPage(PageType.ConcatPage);
                    return PagesFactory.CreatePage(PageType.ConcatPage);
                
                case PageType.HomeWithLogOff:
                    break;
                default:
                    break;
            }
            return null;
        }
       
    }
}
