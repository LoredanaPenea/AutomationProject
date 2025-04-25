using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;

namespace AutomationProject.Tests
{
    public class AlertsTest
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        AlertsPage alertsPage;
        JavaScriptMethods jsMethods;

        [Test]
        public void AlertsInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);
            homePage = new HomePage(webDriver);
            commonPage = new CommonPage(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
            alertsPage = new AlertsPage(webDriver);

            jsMethods.ScrollPageVertically(1000);

            homePage.ClickOnAlertsFrameCard();
            commonPage.GoToMenu("Alerts");

            jsMethods.ScrollPageVertically(1000);

            alertsPage.ClickOnAlertButton();
            Console.WriteLine("Alert text is: " + alertsPage.GetAlertText());

            alertsPage.ClickOnAlertTimerButton();
            Console.WriteLine($"{alertsPage.GetAlertTimerText()}");

            alertsPage.ClickOnConfirmBoxButton("OK");
            alertsPage.ClickOnConfirmBoxButton("Cancel");

            alertsPage.ClickOnPromptButton("Loredana", "OK");
            alertsPage.ClickOnPromptButton("Popescu Maria", "Cancel");
        }
        [TearDown]
        public void TearDown()
        {
            // webDriver.Close();
            webDriver.Dispose();
        }
    }
}
