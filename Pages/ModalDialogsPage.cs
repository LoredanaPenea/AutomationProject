using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class ModalDialogsPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;
        WebDriverWait wait;

        public ModalDialogsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(2));
        }

        IWebElement smallModalBtn => webDriver.FindElement(By.Id("showSmallModal"));
        IWebElement largeModalBtn => webDriver.FindElement(By.Id("showLargeModal"));
        IWebElement closeSmallModal => webDriver.FindElement(By.Id("closeSmallModal"));
        IWebElement closeLargeModal => webDriver.FindElement(By.Id("closeLargeModal"));
        By modalContent => By.ClassName("modal-content");

        public void ClickSmallModalBtn()
        {
            elementMethods.ClickOnElement(smallModalBtn);
           
        }
        public void CloseSmallModal()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(modalContent));

            elementMethods.ClickOnElement(closeSmallModal);
        }
        public void ClickLargeModalBtn()
        { 
            elementMethods.ClickOnElement(largeModalBtn);
        }

        public void CloseLargeModal()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(modalContent));

            elementMethods.ClickOnElement(closeLargeModal);
        }
    }
}
