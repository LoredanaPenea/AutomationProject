using AutomationProject.Access;
using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject.Tests.Elements
{
    public class TextBoxTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        TextBoxPage textBoxPage;
        JavaScriptMethods jsMethods;

        [Test]
        public void TextBoxMethod()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            textBoxPage = new TextBoxPage(driver);
            var textBoxData = new TextBoxData(1);

            jsMethods = new JavaScriptMethods(driver);
            jsMethods.ScrollPageVertically(800);

            homePage.ClickOnElementsCard();
            commonPage.GoToMenu("Text Box");

            textBoxPage.FillInTextBoxFormUsingXML(textBoxData);
            textBoxPage.DisplayOutputData();

            textBoxData = new TextBoxData(2);
            textBoxPage.FillInTextBoxFormUsingXML(textBoxData);
            textBoxPage.DisplayOutputData();

        }

    }
}