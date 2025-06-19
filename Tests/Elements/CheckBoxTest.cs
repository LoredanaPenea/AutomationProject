using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Elements
{
    public class CheckBoxTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        CheckBoxPage checkBoxPage;

        [Test]
        public void CheckBoxMethod()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            checkBoxPage = new CheckBoxPage(driver);

            homePage.ClickOnElementsCard();
            commonPage.GoToMenu("Check Box");
            checkBoxPage.ExpandCheckBoxMenu();

            /*
            IWebElement checkBoxExpandCollapse = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/button"));
            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            elementMethods.ClickOnElement(checkBoxExpandCollapse);

            IWebElement checkBoxDesktop = driver.FindElement(By.XPath("//*[@id=\"tree-node\"]/ol/li/ol/li[1]/span/label/span[1]"));
            elementMethods.ClickOnElement(checkBoxDesktop);
            bool checkBoxDesktopSelection = checkBoxDesktop.GetCssValue("svg").Contains("rct-icon rct-icon-uncheck");
            if (checkBoxDesktopSelection)
                Console.WriteLine("Check Box is not checked");
            else Console.WriteLine("Check Box is checked");
            */

        }
    }
}
