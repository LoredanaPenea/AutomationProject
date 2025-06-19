using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Elements
{
    public class CheckBoxPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;
        public CheckBoxPage(IWebDriver webDriver) 
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
        }
        IWebElement checkBoxExpandCollapse => webDriver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/button"));
        IWebElement checkBoxDesktop => webDriver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/ol/li[1]/span/label/span[1]"));

        public void ExpandCheckBoxMenu()
        {
            elementMethods.ClickOnElement(checkBoxExpandCollapse);

            elementMethods.ClickOnElement(checkBoxDesktop);
            bool checkBoxDesktopSelection = checkBoxDesktop.GetCssValue("svg").Contains("rct-icon rct-icon-uncheck");
            if (checkBoxDesktopSelection)
                Console.WriteLine("Check Box is not checked");
            else Console.WriteLine("Check Box is checked");
        }
    }
}
