using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.BasePage.Browser
{
    public class ChromeServices : IBrowserService
    {
        public WebDriver WebDriver { get; private set; }
        public object BrowserOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--no-sandbox");
            return chromeOptions;
        }

        public void OpenBrowser()
        {
            ChromeOptions options = (ChromeOptions)BrowserOptions();
            WebDriver = new ChromeDriver(options);

        }
    }
}
