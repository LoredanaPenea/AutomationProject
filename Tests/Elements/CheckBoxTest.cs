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


        }
    }
}
