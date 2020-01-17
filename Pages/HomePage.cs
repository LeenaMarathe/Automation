using Automation.TestPHPTravel.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestPHPTravel.Pages
{
    public class HomePage:BasePage
    {
        private readonly string _url = @"https://www.phptravels.net/index.php";

        public IWebElement DestinationTxt => DriverFactory.Driver.FindElement(By.XPath("//form[@name='HOTELS']/div/div/div[1]/div/div[2]/div"));
        public IWebElement CheckInDt => DriverFactory.Driver.FindElement(By.Name("checkin"));
        public IWebElement CheckOutDt => DriverFactory.Driver.FindElement(By.Name("checkout"));

        public IWebElement SearchBtn => DriverFactory.Driver.FindElement(By.XPath("//div[1]/div/div/form/div/div/div[4]/button[contains(text(),'Search')]"));
        
        public void Navigate() => DriverFactory.Driver.Navigate().GoToUrl(_url);
        

        public ResultsPage Search(string destination,string checkin,string checkout) {
            EnterDestinationTxt(destination);
            EnterCheckInDt(checkin);
            EnterCheckOutDt(checkout);
            ResultsPage result = ClickSearch();
            return result;
        }

        public HomePage EnterDestinationTxt(string dest)
        {
            DestinationTxt.Click();
            IWebElement element = DriverFactory.Driver.FindElement(By.XPath("//div[6]/div[@class='select2-search']/input"));
            element.Clear();
            element.SendKeys(dest);            
            element = DriverFactory.Driver.FindElement(By.XPath($"//span[@class='select2-match' and contains(text(),'{dest}')]"));
            WaitForElementToBeClickable(element);
            element.Click();
            return this;
        }

        public HomePage EnterCheckInDt(string checkin)
        {
            CheckInDt.Clear();
            CheckInDt.SendKeys(checkin);
            return this;
        }

        public HomePage EnterCheckOutDt(string checkout)
        {
            CheckOutDt.Clear();
            CheckOutDt.SendKeys(checkout);
            return this;
        }
        public ResultsPage ClickSearch()
        {
            WaitForElementToBeClickable(SearchBtn);
            SearchBtn.Click();
            return new ResultsPage();
        }
    }
}
