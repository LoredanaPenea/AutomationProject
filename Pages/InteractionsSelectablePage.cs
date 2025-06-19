using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class InteractionsSelectablePage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        public InteractionsSelectablePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        IWebElement gridMenu => webDriver.FindElement(By.Id("demo-tab-grid"));

        public void SelectGridElements()
        {
            elementMethods.ClickOnElement(gridMenu);

            List<IWebElement> listNumbersGrid = webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[@class='list-group-item list-group-item-action']")).ToList();
            for (int i = 0; i < listNumbersGrid.Count; i++)
            {
                if (i % 2 == 0)
                    elementMethods.ClickOnElement(listNumbersGrid[i]);
            }
        }
    }
}
