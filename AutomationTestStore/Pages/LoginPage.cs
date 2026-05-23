using AutomationFramework.Pages;
using AutomationTestStore.GeneralUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTestStore.TestScripts;
using AutomationTestStore.BaseClass;

namespace AutomationTestStore.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
           
        }
        public IWebElement login => Driver.FindElement(By.XPath("//a[contains(text(),'Login or register')]"));
        public IWebElement loginId => Driver.FindElement(By.Id("loginFrm_loginname"));
        public IWebElement loginPassword => Driver.FindElement(By.Id("loginFrm_password"));
        public IWebElement loginButton => Driver.FindElement(By.XPath("//button[@title='Login']"));
        public IWebElement accountVerification => Driver.FindElement(By.XPath("//div[contains(text(),'Welcome back')]"));
        public IWebElement loginErrorMessage => Driver.FindElement(By.XPath("//div[@class='alert alert-error alert-danger']"));


        public void Login(string user, string pass)
        {   
            login.Click();
            loginId.SendKeys(user);
            loginPassword.SendKeys(pass);
            loginButton.Click();

        }
    }
}
