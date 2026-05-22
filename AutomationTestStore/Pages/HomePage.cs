using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTestStore.BaseClass;
using OpenQA.Selenium;

namespace AutomationTestStore.Pages
{
    internal class HomePage : Driver
    {
        public static IWebElement homePageValidationText = driver.FindElement(By.XPath("//*[@title='Automation Test Store']"));
        public static IWebElement continueButton = driver.FindElement(By.XPath("//*[@title='Continue']"));
    }
}
