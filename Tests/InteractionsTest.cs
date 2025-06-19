using OpenQA.Selenium.Chrome;
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

namespace AutomationProject.Tests
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
            /*
            List<IWebElement> listNumbers = driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']/div")).ToList();
            for (int i = 0; i < listNumbers.Count; i++)
                Console.WriteLine(listNumbers[i].Text); */      

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
