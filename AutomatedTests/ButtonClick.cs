﻿using System;
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
            driver = dr;

            string defaultTitle = "ButtonClick - My ASP.NET MVC Application";
            string actualTitle = dr.Title;

            if (!defaultTitle.Equals(actualTitle))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded!");
            }
        }

    }
}
