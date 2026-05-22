using AutomationTestStore.BaseClass;
using AutomationTestStore.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography;

namespace AutomationTestStore.TestScripts
{
    [TestFixture]
    public class Tests : Driver
    {
        HomePage hp = new HomePage();
        public static IWebElement homePageValidationText = driver.FindElement(By.XPath("//*[@title='Automation Test Store']"));
        public static IWebElement continueButton = driver.FindElement(By.XPath("//*[@title='Continue']"));
        public static IWebElement firstName;
        public static IWebElement lasttName;
        public static IWebElement address1;
        public static IWebElement eMail;
        public static IWebElement city;
        public static IWebElement region;
        public static IWebElement postcode;
        public static IWebElement country;
        public static IWebElement loginName;
        public static IWebElement password;
        public static IWebElement passwordConfirm;
        public static IWebElement privacyPolicy;
        public static IWebElement registrationButton; 
        public static IWebElement accountVerification;
        public static IWebElement logoff;
        public static IWebElement login;
        public static IWebElement loginId;
        public static IWebElement loginPassword;
        public static IWebElement loginButton;
        //public static IWebElement firstName = driver.FindElement(By.Id("AccountFrm_firstname")); 
        //public static IWebElement lasttName = driver.FindElement(By.Id("AccountFrm_lastname"));
        //public static IWebElement address1 = driver.FindElement(By.Id("AccountFrm_address_1"));
        //public static IWebElement eMail = driver.FindElement(By.Id("AccountFrm_email"));
        //public static IWebElement city = driver.FindElement(By.Id("AccountFrm_city"));
        //public static IWebElement region = driver.FindElement(By.Id("AccountFrm_zone_id"));
        //public static IWebElement postcode = driver.FindElement(By.Id("AccountFrm_postcode"));
        //public static IWebElement country = driver.FindElement(By.Id("AccountFrm_country_id"));
        //public static IWebElement loginName = driver.FindElement(By.Id("AccountFrm_loginname"));
        //public static IWebElement password = driver.FindElement(By.Id("AccountFrm_password"));
        //public static IWebElement passwordConfirm = driver.FindElement(By.Id("AccountFrm_confirm"));
        //public static IWebElement privacyPolicy = driver.FindElement(By.Id("AccountFrm_agree"));

        public static int randomNumber = RandomNumberGenerator.GetInt32(0, 100);
        [Test]
        public void HomePageTest()
        {

            // 'driver' is accessible here because it's protected in BaseTest
            //driver.Url = "https://automationteststore.com/index.php?rt=account/login";
            //driver.Navigate().GoToUrl("https://example.com");
            // Your test logic...
            string expectedText = "Automation Test Store";
            string actualText = homePageValidationText.Text;
            Assert.AreEqual(expectedText, expectedText, "No text as " + expectedText + " on the home page");
            continueButton.Click();
        }

        [Test]
        public void RegestrationPageTest()
        {          
                  
            continueButton.Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            firstName = driver.FindElement(By.Id("AccountFrm_firstname"));
            lasttName = driver.FindElement(By.Id("AccountFrm_lastname"));
            address1 = driver.FindElement(By.Id("AccountFrm_address_1"));
            eMail = driver.FindElement(By.Id("AccountFrm_email"));
            city = driver.FindElement(By.Id("AccountFrm_city"));
            region = driver.FindElement(By.Id("AccountFrm_zone_id"));
            postcode = driver.FindElement(By.Id("AccountFrm_postcode"));
            country = driver.FindElement(By.Id("AccountFrm_country_id"));
            loginName = driver.FindElement(By.Id("AccountFrm_loginname"));
            password = driver.FindElement(By.Id("AccountFrm_password"));
            passwordConfirm = driver.FindElement(By.Id("AccountFrm_confirm"));
            privacyPolicy = driver.FindElement(By.Id("AccountFrm_agree"));
            registrationButton = driver.FindElement(By.XPath("//*[@title='Continue']"));
            
            Actions actions = new Actions(driver);
            SelectElement select = new SelectElement(region);
            actions.MoveToElement(firstName).Click().SendKeys("Test0000"+ randomNumber).Build().Perform();
            actions.MoveToElement(lasttName).Click().SendKeys("Test456").Build().Perform();
            actions.MoveToElement(eMail).Click().SendKeys("test"+randomNumber+"@gmail.com").Build().Perform();
            actions.MoveToElement(address1).Click().SendKeys("gdgdfgdf").Build().Perform();
            actions.MoveToElement(city).Click().SendKeys("testcityerrwer").Build().Perform();
            actions.MoveToElement(region).Click().Build().Perform();
            select.SelectByText("Aberdeen");
            actions.MoveToElement(postcode).Click().SendKeys("AB10").Build().Perform();
            actions.MoveToElement(loginName).Click().SendKeys("Test"+ randomNumber + "Test").Build().Perform();
            actions.MoveToElement(password).Click().SendKeys("password@123").Build().Perform();
            actions.MoveToElement(passwordConfirm).Click().SendKeys("password@123").Build().Perform();
            privacyPolicy.Click();
            actions.SendKeys(Keys.End).Perform();
            registrationButton.Click();
            accountVerification = driver.FindElement(By.XPath("//div[contains(text(),'Welcome back')]"));
            string expectedText = "Welcome back Test0000" + randomNumber;
            string actualText = accountVerification.Text;
            Assert.That(actualText, Is.EqualTo(expectedText), "No text as " + expectedText + " upon registration page");
            logoff = driver.FindElement(By.XPath("//ul[@class='side_account_list']/li[10]"));
            logoff.Click();
            login = driver.FindElement(By.XPath("//a[contains(text(),'Login or register')]"));
            login.Click();
            loginId = driver.FindElement(By.Id("loginFrm_loginname"));
            loginPassword = driver.FindElement(By.Id("loginFrm_password"));
            loginButton = driver.FindElement(By.XPath("//button[@title='Login']"));
            actions.MoveToElement(loginId).Click().SendKeys("Test" + randomNumber + "Test").Build().Perform();
            actions.MoveToElement(loginPassword).Click().SendKeys("password@123").Build().Perform();
            loginButton.Click();
            Assert.That(actualText, Is.EqualTo(expectedText), "No text as " + expectedText + " on the login page");

        }

    }
}