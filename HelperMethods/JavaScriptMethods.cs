using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.HelperMethods
{
    public class JavaScriptMethods
    {
        IWebDriver webDriver;
        IJavaScriptExecutor jsExec;

        public JavaScriptMethods(IWebDriver webDriver) 
        {
            this.webDriver = webDriver;
            this.jsExec = (IJavaScriptExecutor)webDriver;
        }

        public void ScrollPageHorizontally(int pixelX)
        {
            jsExec.ExecuteScript($"window.scrollTo({pixelX},0)");
        }

        public void ScrollPageVertically(int pixelY)
        {
            jsExec.ExecuteScript($"window.scrollTo(0,{pixelY})");
        }

        public void ScrollPageDynamically(int pixelX, int pixelY)
        {
            jsExec.ExecuteScript($"window.scrollTo({pixelX}, {pixelY} )");
        }
        public void ScrollElementIntoView(IWebElement element)
        {
            jsExec.ExecuteScript("arguments[0].scrollIntoView(arguments[1]);",element);
        }
    }
}
