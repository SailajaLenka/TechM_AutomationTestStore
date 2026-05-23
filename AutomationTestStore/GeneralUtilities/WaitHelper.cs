using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography;

namespace AutomationTestStore.GeneralUtilities
{
    public class WaitHelper
    {
        public readonly IWebDriver _driver;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement WaitForElement(By locator, int seconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));

            return wait.Until(driver => driver.FindElement(locator));
        }

        public int randomNumber()
        {
            int ranNumber = RandomNumberGenerator.GetInt32(0, 100);
            return ranNumber;
        }
    }
}
