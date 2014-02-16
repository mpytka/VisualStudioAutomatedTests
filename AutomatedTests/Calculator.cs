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
    public class Calculator
    {
        private IWebDriver driver;
        public Calculator(IWebDriver dr)
        {
            driver = dr;

            string defaultTitle = "Calculator - My ASP.NET MVC Application";
            string actualTitle = dr.Title;

            if (!defaultTitle.Equals(actualTitle))
            {
                throw new PagesException("Wrong Page Has Just Been Loaded!");
            }
        }

        public Calculator ClickCalculatorNumber(KeyNumber key)
        {
            switch (key)
            {
                case KeyNumber.one:
                    driver.FindElement(By.Name("one")).Click();
                    break;

                case KeyNumber.two:
                    driver.FindElement(By.Name("two")).Click();
                    break;
                
                case KeyNumber.three:
                    driver.FindElement(By.Name("three")).Click();
                    break;
               
                case KeyNumber.four:
                    driver.FindElement(By.Name("four")).Click();
                    break;
               
                case KeyNumber.five:
                    driver.FindElement(By.Name("five")).Click();
                    break;
               
                case KeyNumber.six:
                    driver.FindElement(By.Name("six")).Click();
                    break;
               
                case KeyNumber.seven:
                    driver.FindElement(By.Name("seven")).Click();
                    break;

                case KeyNumber.eight:
                    driver.FindElement(By.Name("eight")).Click();
                    break;

                case KeyNumber.nine:
                    driver.FindElement(By.Name("nine")).Click();
                    break;
               
                case KeyNumber.zero:
                    driver.FindElement(By.Name("zero")).Click();
                    break;

                case KeyNumber.plus:
                    driver.FindElement(By.Name("plus")).Click();
                    break;

                case KeyNumber.minus:
                    driver.FindElement(By.Name("minus")).Click();
                    break;

                case KeyNumber.times:
                    driver.FindElement(By.Name("times")).Click();
                    break;

                case KeyNumber.div:
                    driver.FindElement(By.Name("div")).Click();
                    break;

                case KeyNumber.DoIt:
                    driver.FindElement(By.Name("DoIt")).Click();
                    break;

            }
            return new Calculator(driver);
        }

        public string CheckCalcInputValue()
        {
            string result = driver.FindElement(By.Name("Input")).GetAttribute("value");
            return result;
        }

    }
}
