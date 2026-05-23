using AutomationTestStore.BaseClass;
using AutomationTestStore.Pages;
using AutomationTestStore.GeneralUtilities;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography;

namespace AutomationTestStore.TestScripts
{
    [TestFixture]
    public class TestCases : BaseTest
    {       
        [Test]
        public void RegestrationPageTest()
        {
            HomePage homePage = new HomePage(WebDriver);
            RegistartionPage regPage = new RegistartionPage(WebDriver);
            WaitHelper waits = new WaitHelper(WebDriver);
            waits.WaitForElement(homePage.ByContinueButton,10);
            homePage.continueButton.Click();
            int ranNum = waits.randomNumber();

            Actions actions = new Actions(WebDriver);
            SelectElement select = new SelectElement(regPage.region);
            regPage.firstName.SendKeys("Test0000" + ranNum);
            regPage.lasttName.SendKeys("Test456");
            regPage.eMail.SendKeys("test1208" + ranNum + "@gmail.com");
            regPage.address1.SendKeys("gdgdfgdf");
            regPage.city.SendKeys("testcityerrwer");
            regPage.region.Click();
            select.SelectByText("Aberdeen");
            regPage.postcode.SendKeys("AB10");
            regPage.loginName.SendKeys("Test" + ranNum + "Test");
            regPage.password.SendKeys("password@123");
            regPage.passwordConfirm.SendKeys("password@123");
            regPage.privacyPolicy.Click();
            actions.SendKeys(Keys.End).Perform();
            regPage.registrationButton.Click();
            string expectedText = "Welcome back Test0000" + ranNum;
            waits.WaitForElement(regPage.ByAccountVerification, 10);
            string actualText = regPage.accountVerification.Text;

            /* Validating the registration success or not */
            actualText.Should().Be(expectedText, "No text as " + expectedText + " upon successful registration");
            regPage.logoff.Click();
        }

        /* Created some users for positive and negative testing */
        [TestCase("Test980764367", "password@123", "Test0000111")]
        [TestCase("TestPostive12345", "!ndia@2026", "TestStore1")]
        public void LogInPositiveTest(string username, string password, string loginname)
        {
            /* Login Positive Scenario*/
            RegistartionPage regPage = new RegistartionPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.Login(username,password);
            string expectedText = "Welcome back " + loginname;
            string actualText = regPage.accountVerification.Text;
            actualText.Should().Be(expectedText, "No text as " + expectedText + " on the login page");            
        }

        /* Correct Username and Wrong Password */
        [TestCase("TestPostive12345", "!ndid@2026", " Incorrect login or password provided." )]

        /* Correct Password and Wrong UserName */
        [TestCase("TestPostive123456", "!ndia@2026", "Incorrect login or password provided.")]
        public void LogInNegativeTest(string username, string password, string expectedErrorMessage)
        {
            /* Login negative Scenario */
            RegistartionPage regPage = new RegistartionPage(WebDriver);
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.Login(username,password);
            string actualErrorMessage = loginPage.loginErrorMessage.Text;
            actualErrorMessage.Should().EndWith(expectedErrorMessage, "No text as " + expectedErrorMessage + " on the login page");
        }
    }
}