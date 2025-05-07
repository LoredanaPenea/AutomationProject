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

        public ModalDialogsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }

        IWebElement smallModalBtn => webDriver.FindElement(By.Id("showSmallModal"));
        IWebElement largeModalBtn => webDriver.FindElement(By.Id("showLargeModal"));
        IWebElement closeSmallModal => webDriver.FindElement(By.Id("closeSmallModal"));
        
        public void ClickSmallModalBtn()
        {
            elementMethods.ClickOnElement(smallModalBtn);
           // smallModalBtn.Click();
        }
        public void CloseSmallModal()
        {
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(2));
            //By modalContent = By.ClassName("modal-content");
            wait.Until(ExpectedConditions.ElementIsVisible((By.ClassName("modal-content"))));

            elementMethods.ClickOnElement(closeSmallModal);
        }
        public void ClickLargeModalBtn()
        { 
            elementMethods.ClickOnElement(largeModalBtn);
        }

        public void CloseLargeModal()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible((By.ClassName("modal-content"))));

            webDriver.FindElement(By.Id("closeLargeModal")).Click();
        }
    }
}
