using AutomationProject.BasePage.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.BasePage
{
    public class BasePage
    {
        public WebDriver driver;

        [SetUp]
        public void InitializeBrowser()
        {
            driver = new BrowserFactory().GetBrowserFactory();
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
