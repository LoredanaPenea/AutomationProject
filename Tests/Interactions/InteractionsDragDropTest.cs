using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Interactions
{
    public class InteractionsDragDropTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        DroppablePage droppablePage;

        [Test]
        public void DragAndDropTest()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            droppablePage = new DroppablePage(driver);

            homePage.ClickOnInteractionsCard();
            commonPage.GoToMenu("Droppable");
            droppablePage.DragAndDrop();

        }
    }
}
