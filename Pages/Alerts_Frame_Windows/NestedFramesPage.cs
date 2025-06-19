using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Alerts_Frame_Windows
{
    public class NestedFramesPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;
        public NestedFramesPage(IWebDriver webDriver) 
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
        }

        IWebElement parentFrame => webDriver.FindElement(By.Id("frame1"));
        IWebElement bodyParentFrame => webDriver.FindElement(By.TagName("body"));
        IWebElement childFrame => webDriver.FindElement(By.TagName("iframe"));
        IWebElement bodyChildFrame => webDriver.FindElement(By.TagName("p"));

        public string GetTextFromParentFrame()
        {
            jsMethods.ScrollPageVertically(1000);
            webDriver.SwitchTo().Frame(parentFrame);
            return bodyParentFrame.Text;
        }

        public string GetTextFromChildFrame()
        {
            webDriver.SwitchTo().Frame(childFrame);
            return bodyChildFrame.Text;
        }
        
        public bool VerifyTextFromParentFrame()
        {
            webDriver.SwitchTo().DefaultContent();
            string actualParentFrameText = GetTextFromParentFrame();
            if (actualParentFrameText.Equals("Parent frame"))
                return true;
            else return false;
        }
        
    }
}
