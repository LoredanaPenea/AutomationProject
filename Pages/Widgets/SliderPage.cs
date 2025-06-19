using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Widgets
{
    public  class SliderPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        ActionsMethods actionsMethods;
        public SliderPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            actionsMethods = new ActionsMethods(webDriver);
        }
        IWebElement sliderValue => webDriver.FindElement(By.Id("sliderValue"));
        IWebElement slider => webDriver.FindElement(By.XPath("//input[@type='range']"));
        public void MoveSlider() 
        {
            Console.WriteLine($"Initial slider value is: {sliderValue.GetAttribute("value")}");

            // Move the slider using Actions class
            actionsMethods.MoveSliderToRight(30, slider);
         
            Thread.Sleep(2000);

            Console.WriteLine($"New slider value is: {sliderValue.GetAttribute("value")}");

            actionsMethods.MoveSliderToLeft(60, slider);

            Console.WriteLine($"New slider value is: {sliderValue.GetAttribute("value")}");
        }
    }
}
