using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class BasePage
    {
        public readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
