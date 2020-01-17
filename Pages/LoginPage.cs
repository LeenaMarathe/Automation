using Automation.TestPHPTravel.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestPHPTravel.Pages
{
    public class LoginPage:BasePage
    {
        private readonly string _url = @"https://www.phptravels.net/admin";
        public IWebElement EmailTxt => DriverFactory.Driver.FindElement(By.Name("email"));
        public IWebElement PasswordTxt => DriverFactory.Driver.FindElement(By.Name("password"));
        public IWebElement LoginBtn => DriverFactory.Driver.FindElement(By.XPath("//form[1]/button/span"));

        public void Navigate() => DriverFactory.Driver.Navigate().GoToUrl(_url);
        public LoginPage EnterEmail(string email)
        {
            WaitForElementToBeClickable(EmailTxt);
            EmailTxt.Clear();
            EmailTxt.SendKeys(email);
            return this;
        }

        public LoginPage EnterPassword(string pwd)
        {
            PasswordTxt.Clear();
            PasswordTxt.SendKeys(pwd);
            return this;
        }

        public AdminPage ClickLogin()
        {
            WaitForElementToBeClickable(LoginBtn);
            LoginBtn.Click();
            return new AdminPage();
        }
        public AdminPage Login(string email,string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            AdminPage adminpage = ClickLogin();
            return adminpage;
        }

    }
}
