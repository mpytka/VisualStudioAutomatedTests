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
        }

        public Calculator ClickCalculatorNumber(KeyNumber key)
        {
            switch (key)
            {
                case KeyNumber.one:
                    driver.FindElement(By.Name("one")).Click();
                    return new Calculator(driver);

                case KeyNumber.two:
                    driver.FindElement(By.Name("two")).Click();
                    return new Calculator(driver);
                
                case KeyNumber.three:
                    driver.FindElement(By.Name("three")).Click();
                    return new Calculator(driver);
               
                case KeyNumber.four:
                    driver.FindElement(By.Name("four")).Click();
                    return new Calculator(driver);
               
                case KeyNumber.five:
                    driver.FindElement(By.Name("five")).Click();
                    return new Calculator(driver);
               
                case KeyNumber.six:
                    driver.FindElement(By.Name("six")).Click();
                    return new Calculator(driver);
               
                case KeyNumber.seven:
                    driver.FindElement(By.Name("seven")).Click();
                    return new Calculator(driver);

                case KeyNumber.eight:
                    driver.FindElement(By.Name("eight")).Click();
                    return new Calculator(driver);

                case KeyNumber.nine:
                    driver.FindElement(By.Name("nine")).Click();
                    return new Calculator(driver);
               
                case KeyNumber.zero:
                    driver.FindElement(By.Name("zero")).Click();
                    return new Calculator(driver);

                case KeyNumber.plus:
                    driver.FindElement(By.Name("plus")).Click();
                    return new Calculator(driver);

                case KeyNumber.minus:
                    driver.FindElement(By.Name("minus")).Click();
                    return new Calculator(driver);

                case KeyNumber.times:
                    driver.FindElement(By.Name("times")).Click();
                    return new Calculator(driver);

                case KeyNumber.div:
                    driver.FindElement(By.Name("div")).Click();
                    return new Calculator(driver);

                case KeyNumber.DoIt:
                    driver.FindElement(By.Name("DoIt")).Click();
                    return new Calculator(driver);

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
