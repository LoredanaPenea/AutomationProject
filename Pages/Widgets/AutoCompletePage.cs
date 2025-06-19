using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Widgets
{
    public class AutoCompletePage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;

        public AutoCompletePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }


        IWebElement multipleColor => webDriver.FindElement(By.Id("autoCompleteMultipleInput"));
        IWebElement singleColor => webDriver.FindElement(By.Id("autoCompleteSingleInput"));
        
        public void AddMultipleColorNames()
        {
            elementMethods.ClickOnElement(multipleColor);
            elementMethods.TypeTextInWebElement(multipleColor, "Blue");
            elementMethods.PressEnter(multipleColor);
            elementMethods.TypeTextInWebElement(multipleColor, "i");
            elementMethods.ArrowDown(multipleColor);
            elementMethods.ArrowDown(multipleColor);
            elementMethods.PressEnter(multipleColor);
        }
        public void AddSingleColorName()
        {
            elementMethods.ClickOnElement(singleColor);
            elementMethods.TypeTextInWebElement(singleColor, "magenta");
            elementMethods.PressEnter(singleColor);
        }           
    }
}
