using AutomationFramework.Pages;
using AutomationTestStore.BaseClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestStore.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement homePageValidationText => Driver.FindElement(By.XPath("//*[@title='Automation Test Store']"));
        public IWebElement continueButton => Driver.FindElement(By.XPath("//*[@title='Continue']"));
    }
}
