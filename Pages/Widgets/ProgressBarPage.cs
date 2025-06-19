using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Widgets
{
    public class ProgressBarPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        public ProgressBarPage(IWebDriver webDriver) 
        { 
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }
        IWebElement startBtn => webDriver.FindElement(By.Id("startStopButton"));
        IWebElement progressBar => webDriver.FindElement(By.XPath("//div[@class='progress']//div[@role='progressbar']"));
        public void StartStopProgressBar()
        {
            
            elementMethods.ClickOnElement(startBtn); //start

            Thread.Sleep(3000); //wait  for 3 seconds

            elementMethods.ClickOnElement(startBtn); //stop

            Console.WriteLine($"Progress stopped at: {progressBar.GetAttribute("aria-valuenow")}%");

            elementMethods.ClickOnElement(startBtn);

            Thread.Sleep(10000);

            int progressValue = int.Parse(progressBar.GetAttribute("aria-valuenow"));

            if (progressValue == 100)
            {
                Console.WriteLine("Progress bar is 100%");
                IWebElement resetBtn = webDriver.FindElement(By.Id("resetButton"));
                elementMethods.ClickOnElement(resetBtn);
            }
        }
    }
}
