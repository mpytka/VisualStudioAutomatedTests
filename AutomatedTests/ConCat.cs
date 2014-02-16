using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using AutomatedTests;
using System.Windows.Forms; 

namespace AutomatedTests
{
    public class ConCat
    {
        private IWebDriver driver;
        public ConCat(IWebDriver dr)
        {
            dr = driver;
        }

        public string InputFirstString()
        {
            driver.FindElement(By.Name("textbox1")).Clear();
            driver.FindElement(By.Name("textbox1")).SendKeys("Windows");
            string res = driver.FindElement(By.Name("textbox1")).GetAttribute("value");
            return res;
        }

        public ConCat InputString(StringsToInput str)
        {
            switch (str)
            {
                case StringsToInput.Windows:
                    var textbox1 = new System.Windows.Forms.TextBox();
                    driver.FindElement(By.Name("textbox1")).Clear();
                    driver.FindElement(By.Name("textbox1")).SendKeys("Windows");
                    return new ConCat(driver);

                 
                 case StringsToInput.Phone:
                    driver.FindElement(By.Name("textbox2")).SendKeys("Phone");
                    return new ConCat(driver);
            }
            return new ConCat(driver);
        }

        public ConCat ClickCombineButton()
        {
            driver.FindElement(By.Id("but")).Click();
            return new ConCat(driver);
        }

    }
}
