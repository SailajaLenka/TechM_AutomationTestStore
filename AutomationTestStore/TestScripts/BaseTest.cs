using NUnit.Framework;
using OpenQA.Selenium;
using AutomationTestStore.BaseClass;

namespace AutomationTestStore.TestScripts
{
    public class BaseTest
    {
        public IWebDriver WebDriver;

        [SetUp]
        public void Setup()
        {
            WebDriver = Driver.InitializeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
            WebDriver.Dispose();
        }
    }
}
