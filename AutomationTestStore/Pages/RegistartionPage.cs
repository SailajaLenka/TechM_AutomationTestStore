using AutomationFramework.Pages;
using AutomationTestStore.BaseClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestStore.Pages
{
    public class RegistartionPage : BasePage
    {        
        public RegistartionPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement firstName => Driver.FindElement(By.Id("AccountFrm_firstname"));
        public IWebElement lasttName => Driver.FindElement(By.Id("AccountFrm_lastname"));
        public IWebElement address1 => Driver.FindElement(By.Id("AccountFrm_address_1"));
        public IWebElement eMail => Driver.FindElement(By.Id("AccountFrm_email"));
        public IWebElement city => Driver.FindElement(By.Id("AccountFrm_city"));
        public IWebElement region => Driver.FindElement(By.Id("AccountFrm_zone_id"));
        public IWebElement postcode => Driver.FindElement(By.Id("AccountFrm_postcode"));
        public IWebElement country => Driver.FindElement(By.Id("AccountFrm_country_id"));
        public IWebElement loginName => Driver.FindElement(By.Id("AccountFrm_loginname"));
        public IWebElement password => Driver.FindElement(By.Id("AccountFrm_password"));
        public IWebElement passwordConfirm => Driver.FindElement(By.Id("AccountFrm_confirm"));
        public IWebElement privacyPolicy => Driver.FindElement(By.Id("AccountFrm_agree"));
        public IWebElement registrationButton => Driver.FindElement(By.XPath("//*[@title='Continue']"));

        public By ByAccountVerification = By.XPath("//div[contains(text(),'Welcome back')]");
        public IWebElement accountVerification => Driver.FindElement(ByAccountVerification);
        public IWebElement logoff => Driver.FindElement(By.XPath("//ul[@class='side_account_list']/li[10]"));
    }
}
