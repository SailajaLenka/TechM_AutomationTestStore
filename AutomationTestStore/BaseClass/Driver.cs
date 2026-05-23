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

        ////Configuration config = new Configuration();
        //public static IWebDriver driver;
        
        //[SetUp]
        //public void Setup()
        //{
        //    driver = new ChromeDriver();
        //    driver.Url = "https://automationteststore.com/index.php?rt=account/login";
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        //}

        //[TearDown]
        //public void Cleanup()
        //{
        //    if (driver != null)
        //    {
        //        driver.Quit();
        //        driver.Dispose();
        //    }
        //}
    }
}
