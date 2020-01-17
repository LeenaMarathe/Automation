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
    public class BasePage
    {
        public void WaitForElementToBeClickable(IWebElement element)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(5);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                if (ele.Displayed && ele.Enabled)
                {
                    return true;
                }
                return false;
            });
            wait.Until(waiter);
        }
    }
}
