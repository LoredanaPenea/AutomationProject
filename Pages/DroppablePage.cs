using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class DroppablePage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;
        ActionsMethods actionsMethods;

        public DroppablePage (IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
            actionsMethods = new ActionsMethods(webDriver);
        }

        IWebElement preventPropogation => webDriver.FindElement(By.Id("droppableExample-tab-preventPropogation"));

        public void DragAndDrop()
        {
            elementMethods.ClickOnElement(preventPropogation);

            IWebElement dragBox = webDriver.FindElement(By.Id("dragBox"));

            // Move the element in different directions using Actions class instance
            actionsMethods.DragRightAndDownByOffsets(200,100,dragBox);
            /*
            actions.ClickAndHold(dragBox)
                       .MoveByOffset(200, 0) // Move right
                       .Pause(TimeSpan.FromSeconds(1)) // Pause for visualization
                       .MoveByOffset(0, 100) // Move down 
                       .Release()
                       .Click()
                       .Perform();*/

            IWebElement notGreedyDropBox = webDriver.FindElement(By.Id("notGreedyDropBox"));
            IWebElement notGreedyInnerDropBox = webDriver.FindElement(By.Id("notGreedyInnerDropBox"));

            IWebElement paragraph1 = notGreedyDropBox.FindElement(By.TagName("p"));
            IWebElement paragraph2 = notGreedyInnerDropBox.FindElement(By.TagName("p"));


            if (paragraph1.Text.Equals("Dropped!"))
            {
                Console.WriteLine("DragMe was dropped in the not greedy outer droppable");
                if (paragraph2.Text.Equals("Dropped!"))
                    Console.WriteLine("DragMe was dropped in the not greedy inner droppable too");
            }
            else if (paragraph2.Text.Equals("Dropped!"))
                Console.WriteLine("DragMe was dropped in the not greedy inner droppable");
            else Console.WriteLine("DragMe was not dropped in the not greedy droppable");

            Thread.Sleep(2000);
            jsMethods.ScrollElementIntoView(dragBox);

            actionsMethods.DragRightAndDownByOffsets(100,300,dragBox);
           /* actions.ClickAndHold(dragBox)
                   .MoveByOffset(0, 300) // Move down 
                   .Pause(TimeSpan.FromSeconds(1)) // Pause for visualization
                   .MoveByOffset(100, 0) // Move right
                   .Release()
                   .Click()
                   .Perform(); */

            IWebElement greedyDropbox = webDriver.FindElement(By.Id("greedyDropBox"));
            IWebElement greedyInnerDropbox = webDriver.FindElement(By.Id("greedyDropBoxInner"));

            IWebElement paragraph3 = greedyDropbox.FindElement(By.TagName("p"));
            IWebElement paragraph4 = greedyInnerDropbox.FindElement(By.TagName("p"));


            if (paragraph3.Text.Equals("Dropped!"))
            {
                Console.WriteLine("DragMe was dropped in the greedy outer droppable");
                if (paragraph4.Text.Equals("Dropped!"))
                    Console.WriteLine("DragMe was dropped in the greedy inner droppable too");
            }
            else if (paragraph4.Text.Equals("Dropped!"))
                Console.WriteLine("DragMe was dropped in the greedy inner droppable");
            else Console.WriteLine("DragMe was not dropped in the greedy droppable");
        }
    }
}
