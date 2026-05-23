using AutomationTestStore.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomationTestStore.BaseClass
{
     
    public static class Driver
    {

        public static IWebDriver webDriver { get; private set; }

        public static IWebDriver InitializeDriver()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(Config.BaseUrl);
            webDriver.Manage().Window.Maximize();

            return webDriver;
        }

        public static void QuitDriver()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
