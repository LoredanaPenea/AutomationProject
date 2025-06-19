using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Widgets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Widgets
{
    public class SliderAndProgressBarTest : BasePage.BasePage
    {
        HomePage homePage;
        CommonPage commonPage;

        [Test]

        public void ProgressBarTestMethod()
        {
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            ProgressBarPage progressBarPage = new ProgressBarPage(driver);

            homePage.ClickOnWidgetsCard();
            commonPage.GoToMenu("Progress Bar");
            progressBarPage.StartStopProgressBar(); 
          
        }

        [Test]
        public void SliderTestMethod()
         {
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            SliderPage sliderPage = new SliderPage(driver);
            
            homePage.ClickOnWidgetsCard();
            commonPage.GoToMenu("Slider");
            sliderPage.MoveSlider();

            }

        }
}
