﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using static System.Net.Mime.MediaTypeNames;
using AutomationProject.HelperMethods;
using AutomationProject.BasePage;
using AutomationProject.Pages;
using AutomationProject.Pages.Interactions;

namespace AutomationProject.Tests.Interactions
{
    public class InteractionsTest : BasePage.BasePage
    {
        //ElementMethods elementMethod;
        HomePage homePage;
        CommonPage commonPage;
        InteractionsSortablePage interactionsSortablePage;
        InteractionsSelectablePage interactionsSelectablePage;

        [Test]
        public void InteractionsMenuSortable()
        {
            //elementMethod = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            interactionsSortablePage = new InteractionsSortablePage(driver);

            homePage.ClickOnInteractionsCard();
            commonPage.GoToMenu("Sortable");
            interactionsSortablePage.SortGridElements(); 

        }

        [Test]
        public void InteractionsMenuSelectable()
        {
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            interactionsSelectablePage = new InteractionsSelectablePage(driver);

            homePage.ClickOnInteractionsCard();
            commonPage.GoToMenu("Selectable");
            interactionsSelectablePage.SelectGridElements();

        }
    }
}
