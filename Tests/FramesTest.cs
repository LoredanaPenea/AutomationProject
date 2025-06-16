using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class FramesTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        FramesPage framesPage;
        JavaScriptMethods jsMethods;
        NestedFramesPage nestedFramesPage;

        [Test]
        public void FramesInteractions()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            framesPage = new FramesPage(driver);

            jsMethods = new JavaScriptMethods(driver);
            jsMethods.ScrollPageVertically(1000);

            homePage.ClickOnAlertsFrameCard();
            commonPage.GoToMenu("Frames");

            framesPage.GetTextFromBigFrame();
            framesPage.GetTextFromLittleFrame();
            jsMethods.ScrollPageVertically(1000);
            framesPage.ScrollInsideFrame2();
            Console.WriteLine("Text returned from Frame1 is:" + framesPage.ReturnTextFromBigFrame());    
            Console.WriteLine("Text returned from Frame2 is:" + framesPage.ReturnTextFromLittleFrame());    

        }

        [Test]
        public void NestedFrames()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            nestedFramesPage = new NestedFramesPage(driver);

            jsMethods = new JavaScriptMethods(driver);
            jsMethods.ScrollPageVertically(1000);

            homePage.ClickOnAlertsFrameCard();
            commonPage.GoToMenu("Nested Frames");
            jsMethods.ScrollPageVertically(1000);

            nestedFramesPage.GetTextFromParentFrame();
            if (nestedFramesPage.VerifyTextFromParentFrame()) 
                Console.WriteLine("Text from Parent Frame is as expected");
            Console.WriteLine("Child frame text is: " + nestedFramesPage.GetTextFromChildFrame());

        }
        [Test]
        public void Modals() 
        {
            elementMethods = new ElementMethods(driver);
            jsMethods = new JavaScriptMethods(driver);

            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            var modalDialogsPage = new ModalDialogsPage(driver);

            jsMethods.ScrollPageVertically(1000);

            homePage.ClickOnAlertsFrameCard();
            commonPage.GoToMenu("Modal Dialogs");

            modalDialogsPage.ClickSmallModalBtn();
            modalDialogsPage.CloseSmallModal();
            modalDialogsPage.ClickLargeModalBtn();
            modalDialogsPage.CloseLargeModal();
        } 

    }
}
