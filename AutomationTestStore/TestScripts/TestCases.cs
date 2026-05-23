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
            homePage.continueButton.Click();
            int ranNum = waits.randomNumber();

            Actions actions = new Actions(WebDriver);
            SelectElement select = new SelectElement(regPage.region);
            actions.MoveToElement(regPage.firstName).Click().SendKeys("Test0000" + ranNum).Build().Perform();
            actions.MoveToElement(regPage.lasttName).Click().SendKeys("Test456").Build().Perform();
            actions.MoveToElement(regPage.eMail).Click().SendKeys("test" + ranNum + "@gmail.com").Build().Perform();
            actions.MoveToElement(regPage.address1).Click().SendKeys("gdgdfgdf").Build().Perform();
            actions.MoveToElement(regPage.city).Click().SendKeys("testcityerrwer").Build().Perform();
            actions.MoveToElement(regPage.region).Click().Build().Perform();
            select.SelectByText("Aberdeen");
            actions.MoveToElement(regPage.postcode).Click().SendKeys("AB10").Build().Perform();
            actions.MoveToElement(regPage.loginName).Click().SendKeys("Test" + ranNum + "Test").Build().Perform();
            actions.MoveToElement(regPage.password).Click().SendKeys("password@123").Build().Perform();
            actions.MoveToElement(regPage.passwordConfirm).Click().SendKeys("password@123").Build().Perform();
            regPage.privacyPolicy.Click();
            actions.SendKeys(Keys.End).Perform();
            regPage.registrationButton.Click();
            string expectedText = "Welcome back Test0000" + ranNum;
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