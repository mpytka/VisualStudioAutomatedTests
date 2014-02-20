using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Pages
{
    public interface IPage
    {
        IWebDriver Driver { get; set; }

        string PageName { get; set; }

        void CheckPageName();

        IPage NavigateToPage(PageType nextPage);
    }

}
