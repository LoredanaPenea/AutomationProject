using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.HelperMethods
{
    public class ActionsMethods
    {
        IWebDriver webDriver;
        Actions actionsMethods;

        public ActionsMethods(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            actionsMethods = new Actions(webDriver);
        }
        public void DragRightAndDownByOffsets(int dx, int dy, IWebElement element)
        {
            actionsMethods.ClickAndHold(element)
                   .MoveByOffset(dx, dy)
                   .Pause(TimeSpan.FromSeconds(1))
                   .Release()
                   .Perform();
        }

        public void MoveSliderToRight(int dx, IWebElement element)
        {
            actionsMethods.ClickAndHold(element)
                   .MoveByOffset(dx, 0) // Move the slider to the right
                   .Release()
                   .Perform();
        }

        public void MoveSliderToLeft (int dx, IWebElement element)
        {
            actionsMethods.ClickAndHold(element)
                 .MoveByOffset(0, dx) // Move the slider to the left
                 .Release()
                 .Perform();
        }
    }
}
