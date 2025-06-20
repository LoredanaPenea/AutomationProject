using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Interactions
{
    public class InteractionsSortablePage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        public InteractionsSortablePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        IWebElement gridMenu => webDriver.FindElement(By.Id("demo-tab-grid"));

        public void SortGridElements() {

            elementMethods.ClickOnElement(gridMenu);
            
            List<IWebElement> listElementsGrid = webDriver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//div[@class='list-group-item list-group-item-action']")).ToList();
            List<string> elementsFromGridToText = new List<string>();

            Dictionary<string, IWebElement> elementMapping = new Dictionary<string, IWebElement>();

            foreach (IWebElement element in listElementsGrid)
            {
                elementsFromGridToText.Add(element.Text.Trim());
                elementMapping[element.Text.Trim()] = element;  // Store element reference by text

            }
            /*
            Console.WriteLine("Elements form grid to text:");
            foreach (string elementtext in elementsFromGridToText)
                Console.WriteLine($"{elementtext}"); */

            Dictionary<string, int> textToNumber = new Dictionary<string, int>()
            {
                { "One", 1 }, { "Two", 2 }, { "Three", 3 },
                { "Four", 4 }, { "Five", 5 }, { "Six", 6 },
                { "Seven", 7 }, { "Eight", 8 }, { "Nine", 9 }
            };

            // Custom sort logic
            elementsFromGridToText.Sort((a, b) =>
            {
                int numA = textToNumber[a];
                int numB = textToNumber[b];
                // If one is odd and the other is even, prioritize odd numbers
                if (numA % 2 != numB % 2)
                    return numA % 2 == 0 ? 1 : -1;
                // Otherwise, maintain natural order
                return numA.CompareTo(numB);
            });
            Console.WriteLine(string.Join(", ", elementsFromGridToText));
        }
    }
}
