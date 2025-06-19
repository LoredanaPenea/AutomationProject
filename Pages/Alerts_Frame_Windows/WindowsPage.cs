using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Alerts_Frame_Windows
{
    public class WindowsPage
    {
        public IWebDriver driver;
        public ElementMethods elementMethods;
        public JavaScriptMethods jsMethods;
        public WindowsMethods windowsMethods;
        public WindowsPage(IWebDriver webDriver)
        {
            driver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
            windowsMethods = new WindowsMethods(webDriver);
        }
        IWebElement newTabButton => driver.FindElement(By.Id("tabButton"));
        IWebElement newWindowButton => driver.FindElement(By.Id("windowButton"));

         public void ClickNewTab()
         {
            windowsMethods.OpenChildWindowOrTab(newTabButton);
            string newTabText = windowsMethods.GetTextFromChildWindowOrTab();
            Console.WriteLine($"New tab text is {newTabText}");
        }

        public void ClickNewWindow()
        {
            windowsMethods.OpenChildWindowOrTab(newWindowButton);
            string newWindowText = windowsMethods.GetTextFromChildWindowOrTab();
            Console.WriteLine($"New window text is {newWindowText}");
        }
    }
}
