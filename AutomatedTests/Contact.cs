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
    public class Contact
    {
        private IWebDriver driver;

        //konstruktor
        public Contact(IWebDriver dr)
        {
            dr = driver;
        }

    }
}
