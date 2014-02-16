using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using AutomatedTests;

namespace AutomatedTests
{
    public class ButtonClick
    {
        private IWebDriver driver;
        public ButtonClick(IWebDriver dr)
        {
            dr = driver;
        }

    }
}
