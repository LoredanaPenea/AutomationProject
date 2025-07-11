using AutomationProject.Access;
using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Alerts_Frame_Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Alerts_Frame_Windows
{
    public class AlertsTest : BasePage.BasePage
    {

        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        AlertsPage alertsPage;
        JavaScriptMethods jsMethods;

        [Test]
        public void AlertsInteractions()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            jsMethods = new JavaScriptMethods(driver);
            alertsPage = new AlertsPage(driver);
            var alertsData = new AlertsData(1);

            jsMethods.ScrollPageVertically(500);

            homePage.ClickOnAlertsFrameCard();
            commonPage.GoToMenu("Alerts");

            jsMethods.ScrollPageVertically(1000);

            alertsPage.ClickOnAlertButton();
            Console.WriteLine("Alert text is: " + alertsPage.GetAlertText());

            alertsPage.ClickOnAlertTimerButton();
            Console.WriteLine($"{alertsPage.GetAlertTimerText()}");

            alertsPage.ClickOnConfirmBoxButton("OK");
            alertsPage.ClickOnConfirmBoxButton("Cancel");

           // alertsPage.ClickOnPromptButton("Loredana", "OK");
           // alertsPage.ClickOnPromptButton("Popescu Maria", "Cancel");

            alertsPage.ClickOnPromptButtonData(alertsData, "OK");
            alertsPage.ClickOnPromptButtonData(alertsData, "Cancel");
        }
       
    }
}
