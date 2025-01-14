﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Session3
{
    public class Widgets
    {
        IWebDriver webDriver;
       
        [Test]

        public void AutoCompleteMethod()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            IWebElement widgetsButton = webDriver.FindElement(By.XPath("//div[@class='card mt-4 top-card'][4]"));
            widgetsButton.Click();

            webDriver.FindElement(By.XPath("//*[text()='Auto Complete']")).Click();

            IWebElement multipleColor = webDriver.FindElement(By.Id("autoCompleteMultipleInput"));
            multipleColor.Click();
            multipleColor.SendKeys("Blue");
            multipleColor.SendKeys(Keys.Enter);
            multipleColor.SendKeys("i");
            multipleColor.SendKeys(Keys.ArrowDown);
            multipleColor.SendKeys(Keys.ArrowDown);
            multipleColor.SendKeys(Keys.Enter);
            IWebElement singleColor = webDriver.FindElement(By.Id("autoCompleteSingleInput"));
            singleColor.Click();
            singleColor.SendKeys("magenta");
            singleColor.SendKeys(Keys.Enter);

            jsExec.ExecuteScript("window.scrollTo(0,1000)");
            webDriver.FindElement(By.XPath("//*[text()='Select Menu']")).Click();

            IWebElement optionDropDown = webDriver.FindElement(By.Id("react-select-4-input"));
            IWebElement optionDropDownArrow = webDriver.FindElement(By.XPath("//*[@class=' css-tlfecz-indicatorContainer'][1]")); // By.XPath(//div[@id='withOptGroup']//*[@class=' css-tlfecz-indicatorContainer']);

            optionDropDownArrow.Click();
            optionDropDown.SendKeys(Keys.ArrowDown);
            optionDropDown.SendKeys(Keys.ArrowDown);
            optionDropDown.SendKeys(Keys.Enter);

           // IWebElement titleDropDown = webDriver.FindElement(By.XPath("//*[@class=' css-1wa3eu0-placeholder']")); 
            IWebElement titleDropDownArrow = webDriver.FindElement(By.XPath("//div[@id='selectOne']//*[@class=' css-tlfecz-indicatorContainer']"));

            //titleDropDown.Click();
            //titleDropDown.SendKeys("mr");
            //titleDropDown.SendKeys(Keys.ArrowDown);
            //titleDropDown.SendKeys(Keys.Enter);

            titleDropDownArrow.Click();
            titleDropDownArrow.SendKeys(Keys.ArrowDown);
            titleDropDownArrow.SendKeys(Keys.ArrowDown);
            titleDropDownArrow.SendKeys(Keys.Enter) ;
        }

        [TearDown]
        public void TearDown()
         {
           //webDriver.Quit();
           webDriver.Close();
         }
    }
}
