using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Tests
{
    public class TextBoxTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        TextBoxPage textBoxPage;

        [Test]
        public void TextBoxMethod()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            textBoxPage = new TextBoxPage(driver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            homePage.ClickOnElementsCard();
            commonPage.GoToMenu("Text Box");

            textBoxPage.FillInTextBoxForm("Ionela Ionescu", "ionescuionela@test.com", "Street no.15 \n Craiova City", "Street no.15 bis\n Craiova City");
            textBoxPage.VerifyTextBoxOutput("Ionela Ionescu", "ionescuionela@test.com", "Street no.15 \n Craiova City", "Street no.15 bis\n Craiova City");

            //Check Box - Elements menu item
            /*
            IWebElement elementCheckBoxButon = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            elementMethods.ClickOnElement(elementCheckBoxButon);

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