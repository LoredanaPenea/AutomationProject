using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.BasePage.Browser
{
    public class BrowserFactory
    {
        public WebDriver GetBrowserFactory()
        {
            string browser = "Edge";

            switch (browser)
            {
                case BrowserType.BROWSER_CHROME:
                    ChromeServices chromeDriver = new ChromeServices();
                    chromeDriver.OpenBrowser();
                    return chromeDriver.WebDriver;
                case BrowserType.BROWSER_EDGE:
                    EdgeServices edgeDriver = new EdgeServices();
                    edgeDriver.OpenBrowser();
                    return edgeDriver.WebDriver;
                default:
                    throw new NotImplementedException("Browser not defined");

            }
        }
    }
}
