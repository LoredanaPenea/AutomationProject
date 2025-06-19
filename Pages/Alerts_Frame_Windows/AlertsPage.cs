using AutomationProject.HelperMethods;
using AutomationProject.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Alerts_Frame_Windows
{
    public class AlertsPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;

        public AlertsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver; 
            elementMethods = new ElementMethods(webDriver);
        }

        IWebElement alertButton => webDriver.FindElement(By.Id("alertButton"));
        IWebElement alertTimerButton=> webDriver.FindElement(By.Id("timerAlertButton"));
        IWebElement confirmButton => webDriver.FindElement(By.Id("confirmButton"));
        IWebElement promptButton => webDriver.FindElement(By.Id("promtButton"));

        public void ClickOnAlertButton()
        {
            elementMethods.ClickOnElement(alertButton);
            IAlert alertOK = webDriver.SwitchTo().Alert();
            alertOK.Accept();
        }

        public string GetAlertText()
        {
            elementMethods.ClickOnElement(alertButton);
            IAlert alertOK = webDriver.SwitchTo().Alert();
            string textAlert = alertOK.Text;
            alertOK.Accept();

            return textAlert;
        }

        public void ClickOnAlertTimerButton()
        {
            elementMethods.ClickOnElement(alertTimerButton);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alertDelay = webDriver.SwitchTo().Alert();
            alertDelay.Accept();
        }

        public string GetAlertTimerText()
        {
            elementMethods.ClickOnElement(alertTimerButton);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
            wait.Until(ExpectedConditions.AlertIsPresent());

            IAlert alertDelay = webDriver.SwitchTo().Alert(); 
            string textAlertTimer = alertDelay.Text;
            alertDelay.Accept();

            return textAlertTimer;
        }

        public void ClickOnConfirmBoxButton(string option)
        {
            elementMethods.ClickOnElement(confirmButton);

            IAlert alertConfirm = webDriver.SwitchTo().Alert();
      
           if (option.Equals("OK"))
            {
                alertConfirm.Accept();
                string resultText = webDriver.FindElement(By.Id("confirmResult")).Text;
                Console.WriteLine(resultText);
            }
           else
            {
                alertConfirm.Dismiss();
                string resultText = webDriver.FindElement(By.Id("confirmResult")).Text;
                Console.WriteLine(resultText);

            }
        }
        
        public void ClickOnPromptButton(string text, string option)
        {
            elementMethods.ClickOnElement(promptButton);

            IAlert alertPrompt = webDriver.SwitchTo().Alert();
            alertPrompt.SendKeys(text);

            if (option.Equals("OK"))
            {
                alertPrompt.Accept();
                string resultText = webDriver.FindElement(By.Id("promptResult")).Text;
                Console.WriteLine(resultText);
            }
            else
            {
                alertPrompt.Dismiss();
                Console.WriteLine("You selected Cancel, no text to display");

            }
        }
    }
}
