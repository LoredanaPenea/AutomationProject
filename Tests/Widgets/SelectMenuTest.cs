using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using AutomationProject.HelperMethods;
using AutomationProject.BasePage;
using AutomationProject.Pages;
using AutomationProject.Access;
using AutomationProject.Pages.Widgets;

namespace AutomationProject.Tests.Widgets
{
    public class SelectMenuTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;

        [Test]
        public void SelectMenuTestMethod()
        {
            //using XML data
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            SelectMenuPage selectMenuPage = new SelectMenuPage(driver);
            var selectMenuData = new SelectMenuData(1);

            homePage.ClickOnWidgetsCard();
            commonPage.GoToMenu("Select Menu");
            selectMenuPage.SelectAllOptions(selectMenuData);
           
        }
    }
}
