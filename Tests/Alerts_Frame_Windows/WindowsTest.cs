using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Alerts_Frame_Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Alerts_Frame_Windows
{
    public class WindowsTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;
        HomePage homePage;
        CommonPage commonPage;
        WindowsPage windowsPage;


        [Test]
        public void WindowsInteractions()
        {
            elementMethods = new ElementMethods(driver);

            jsMethods = new JavaScriptMethods(driver);
            jsMethods.ScrollPageVertically(1000);

            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            windowsPage = new WindowsPage(driver);

            homePage.ClickOnAlertsFrameCard();
            commonPage.GoToMenu("Browser Windows");
            
            windowsPage.ClickNewTab();
            windowsPage.ClickNewWindow();
            
        }

    }
}
