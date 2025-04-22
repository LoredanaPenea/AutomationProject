using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class HomePage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        IList<IWebElement> cards => webDriver.FindElements(By.XPath("//div[@class='card mt-4 top-card']"));
        IWebElement elementsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][1]"));
        IWebElement formsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][2]"));
        IWebElement alertsFrameButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
        IWebElement widgetsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
        IWebElement interactionsButton => webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][5]"));
        public void ClickOnElementsCard()
        {
            elementMethods.ClickOnElement(elementsButton);
           // elementMethods.ClickOnElement(cards[0]);
        }
        
        public void ClickOnFormsCard()
        {
            elementMethods.ClickOnElement(formsButton);
        }

        public void ClickOnAlertsFrameCard()
        {
            elementMethods.ClickOnElement(cards[2]);
        }

        public void ClickOnWidgetsCard()
        {
            elementMethods.ClickOnElement(widgetsButton);
        }

        public void ClickOnInteractionsCard()
        {
            elementMethods.ClickOnElement(cards[4]);
        }

        public void ClickOnBookStoreCard()
        {
            elementMethods.ClickOnElement(cards[5]);
        }
    }
}
