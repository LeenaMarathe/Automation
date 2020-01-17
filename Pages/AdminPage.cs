using Automation.TestPHPTravel.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestPHPTravel.Pages
{
    public class AdminPage : BasePage
    {
        private Dictionary<string, string> data = new Dictionary<string, string>();
        public IWebElement DashboardTitle => DriverFactory.Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[2]/p"));

        public IWebElement ToursMenu => DriverFactory.Driver.FindElement(By.XPath("//a[@href='#Tours']"));

        public IWebElement ReviewMenu => DriverFactory.Driver.FindElement(By.XPath(" //a[contains(text(),'Reviews')]"));

        public IWebElement EditButton => DriverFactory.Driver.FindElement(By.XPath("(//a[contains(@title,'Edit')])[1]"));

        public IWebElement OverallTab => DriverFactory.Driver.FindElement(By.XPath("//a[contains(text(),'Overall')]"));

        public IWebElement OverallLabel => DriverFactory.Driver.FindElement(By.Id("overall"));

        public IWebElement ReviewType(string type) => DriverFactory.Driver.FindElement(By.XPath($"//label[contains(text(),'{type}')]/parent::div/div/select"));

        public IWebElement SaveBtn => DriverFactory.Driver.FindElement(By.XPath("//a[contains(text(),'Save & Return')]"));

        public bool VerifyDashboardTitle(string title)
        {
            WaitForElementToBeClickable(DashboardTitle);
            if (DashboardTitle.Text.Equals(title))
            {
                return true;
            }
            return false;
        }

        public AdminPage ClickToursMenu()
        {
            WaitForElementToBeClickable(ToursMenu);
            Actions action = new Actions(DriverFactory.Driver);
            action.MoveToElement(ToursMenu).Perform();
            ToursMenu.Click();
            return this;
        }

        public AdminPage ClickReviewMenu()
        {
            WaitForElementToBeClickable(ReviewMenu);
            ReviewMenu.Click();
            return this;
        }

        public AdminPage ClickEdit()
        {
            EditButton.Click();
            return this;
        }

        public AdminPage ClickOverallTab()
        {
            OverallTab.Click();
            return this;
        }
        public AdminPage SelectRating(string type, string rating)
        {
            SelectElement s = new SelectElement(ReviewType(type));
            s.SelectByValue(rating);
            return this;
        }
        public AdminPage SaveRating()
        {
            SaveBtn.Click();
            return this;
        }

        public void StoreRating()
        {
            data.Add("overall", OverallLabel.GetAttribute("value"));
        }

        public bool CompareRating()
        {
            if (OverallLabel.GetAttribute("value").Equals(data["overall"]))
                {
                return false;
            }
            else return true;
        }
    }
}
