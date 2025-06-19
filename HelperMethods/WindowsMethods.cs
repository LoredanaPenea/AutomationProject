using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.HelperMethods
{
    public class WindowsMethods
    {
        IWebDriver webDriver;
        string parentWindow;
        public WindowsMethods(IWebDriver webDriver)
        {
            this.webDriver = webDriver;

        }
        public void OpenChildWindowOrTab(IWebElement element)
        {
            parentWindow = webDriver.CurrentWindowHandle;
            int before = webDriver.WindowHandles.Count;

            element.Click();

            // Wait until a new handle is present
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.WindowHandles.Count > before);

            string childWindow = webDriver.WindowHandles.Except(new[] { parentWindow }).First();  // the new handle
            webDriver.SwitchTo().Window(childWindow);
           
        }
        public string GetTextFromChildWindowOrTab()
        {
            string text = webDriver.FindElement(By.Id("sampleHeading")).Text;

            //webDriver.Close();
            webDriver.SwitchTo().Window(parentWindow);

            return text;
        }
    }
}
