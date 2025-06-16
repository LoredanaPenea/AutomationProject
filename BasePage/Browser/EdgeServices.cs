using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.BasePage.Browser
{
    public class EdgeServices : IBrowserService
    {
        public WebDriver WebDriver { get; private set; }
        public object BrowserOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--window-size=1920,1080");
            edgeOptions.AddArgument("--disable-gpu");
            edgeOptions.AddArgument("--no-sandbox");
            return edgeOptions;
        }

        public void OpenBrowser()
        {
            EdgeOptions options = (EdgeOptions)BrowserOptions();
            WebDriver = new EdgeDriver(options);

        }
    }
}
