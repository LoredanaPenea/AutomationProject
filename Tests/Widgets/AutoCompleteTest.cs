using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Widgets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Widgets
{
    public class AutoCompleteTest : BasePage.BasePage
    {
        HomePage homePage;
        CommonPage commonPage;

        [Test]
        public void AutoCompleteMethod()
        { 
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            AutoCompletePage autoCompletePage = new AutoCompletePage(driver);

            homePage.ClickOnWidgetsCard();
            commonPage.GoToMenu("Auto Complete");
            autoCompletePage.AddMultipleColorNames();
            autoCompletePage.AddSingleColorName();
           
        }
    }
}
