using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Alerts_Frame_Windows
{
    public class FramesPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods javaExecutor;
        public FramesPage(IWebDriver webDriver) 
        { 
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            javaExecutor = new JavaScriptMethods(webDriver);
        }

        IWebElement frame1 => webDriver.FindElement(By.Id("frame1"));
        IWebElement frame2 => webDriver.FindElement(By.Id("frame2"));
        IWebElement textFrame1 => webDriver.FindElement(By.Id("sampleHeading"));
        IWebElement textFrame2 => webDriver.FindElement(By.Id("sampleHeading"));

        public void GetTextFromBigFrame()
        {
            javaExecutor.ScrollPageVertically(1000);
            webDriver.SwitchTo().Frame(frame1);
            Console.WriteLine($"Text Frame 1 is: {textFrame1.Text}");
            webDriver.SwitchTo().DefaultContent();
        }

        public string ReturnTextFromBigFrame()
        {
            webDriver.SwitchTo().Frame(frame1);
            return textFrame1.Text;
        }

        public void GetTextFromLittleFrame()
        {
            webDriver.SwitchTo().Frame(frame2);
            javaExecutor.ScrollPageVertically(1000);
            Console.WriteLine($"Text Frame 2 is: {textFrame2.Text}");
            webDriver.SwitchTo().DefaultContent();
        }

        public string ReturnTextFromLittleFrame()
        {
            webDriver.SwitchTo().DefaultContent();
            webDriver.SwitchTo().Frame(frame2);
            return textFrame2.Text;
            
        }
        public void ScrollInsideFrame2()
        {
            webDriver.SwitchTo().Frame(frame2);
            javaExecutor.ScrollPageDynamically(1000,1000);
            webDriver.SwitchTo().DefaultContent();
        }
    }
}
