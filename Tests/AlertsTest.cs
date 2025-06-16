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
using AutomationProject.BasePage;

namespace AutomationProject.Tests
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

            alertsPage.ClickOnPromptButton("Loredana", "OK");
            alertsPage.ClickOnPromptButton("Popescu Maria", "Cancel");
        }
       
    }
}
