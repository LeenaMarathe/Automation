using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.TestPHPTravel.Factories
{
    public class DriverFactory
    {
        public static IWebDriver Driver;
       
        public static void  OpenBrowser() 
        {
            Driver = new InternetExplorerDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            Driver.Manage().Window.Maximize();
        }

        public static void CloseBrowser()
        {
            Driver.Quit();
        }

    }
}
