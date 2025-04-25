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
    public class FramesTest
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        FramesPage framesPage;
        JavaScriptMethods jsMethods;
        NestedFramesPage nestedFramesPage;

        [Test]
        public void FramesInteractions()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);
            homePage = new HomePage(webDriver);
            commonPage = new CommonPage(webDriver);
            framesPage = new FramesPage(webDriver);

            jsMethods = new JavaScriptMethods(webDriver);
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
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);
            homePage = new HomePage(webDriver);
            commonPage = new CommonPage(webDriver);
            nestedFramesPage = new NestedFramesPage(webDriver);

            jsMethods = new JavaScriptMethods(webDriver);
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
        public void Modals() // to be updated
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement alertsFramesButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][3]"));
            elementMethods.ClickOnElement(alertsFramesButton);

            List<IWebElement> listFrames = webDriver.FindElements(By.XPath("//div[@class='element-list collapse show']//li[@class='btn btn-light ']")).ToList();
            elementMethods.ClickOnElement(listFrames[4]);

            IWebElement smallModal = webDriver.FindElement(By.Id("showSmallModal"));
            elementMethods.ClickOnElement(smallModal);
        }

        [TearDown]
        public void TearDown()
        {
            //webDriver.Close();
              webDriver.Dispose();
        }
    }
}
