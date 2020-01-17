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
    public class ResultsPage:BasePage
    {       
        public IWebElement ResultTitle => DriverFactory.Driver.FindElement(By.XPath("//h3[@class='heading-title']/span[2]"));
      
        public ReadOnlyCollection<IWebElement> HotelNames => DriverFactory.Driver.FindElements(By.XPath("//*[@id='LIST']/li//a"));
        public ReadOnlyCollection<IWebElement> Prices => DriverFactory.Driver.FindElements(By.XPath("//div[@class='price']/span"));

        public bool VerifyResultTitle(string dest)
        {
            WaitForElementToBeClickable(ResultTitle);
            if (ResultTitle.Text.Equals(dest))
            {
                return true;
            }
            return false;
        }

        public void PrintResults()
        {
            var combined = HotelNames.Zip(Prices, (name, price) => new { name = name, price = price });
            foreach (var c in combined)
            {
                Console.WriteLine($"{ c.name} : { c.price}");
            }
        }
    }
}
