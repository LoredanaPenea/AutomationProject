using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationProject.HelperMethods
{
    public class ElementMethods
    {
        IWebDriver Driver;
        JavaScriptMethods jsMethods;

        public ElementMethods(IWebDriver driver) 
        {
            Driver = driver;
            jsMethods = new JavaScriptMethods(driver);
        }

        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

        public void FillElement(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        
        public void TypeTextInWebElement(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        
        public void PressEnter(IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }

        public void ArrowDown(IWebElement element)
        {
            element.SendKeys(Keys.ArrowDown);
        }
        public void SelectAll(IWebElement element)
        {
            element.SendKeys(Keys.Control + "a");
        }
        public void SelectByText(IWebElement element, string text)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(text);
        }
        public void SelectByValue(IWebElement element, string value)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByValue(value);
        }
        public void SelectValueFromDynamicDropDown(string text)
        {
            IWebElement option = Driver.FindElement(By.XPath($"//div[contains(@id, 'react-select') and text()='{text}']"));
            Console.WriteLine($"options is: {option.Text}");
            if (option.Text == text)
                ClickOnElement(option);
            else Console.WriteLine("Given state/city is not an option in the drop-down");
        }

        public void SelectOptionFromDropDown(IWebElement element, string text)
        {
            element.Click();
            // option nodes get an auto-generated id that starts with "react-select"
            IWebElement option = Driver.FindElement(By.XPath($"//div[contains(@id, 'react-select') and text()='{text}']"));
            ClickOnElement(option);
        }

        public void SelectMultipleOptionsFromDropDown(IWebElement element, List<string> options)
        {
            IWebElement selectedOption;
            jsMethods.ScrollPageVertically(1000);

            element.Click();

            foreach (string option in options)
            {
                selectedOption = Driver.FindElement(By.XPath($"//div[contains(@id, 'react-select') and text()='{option}']"));
                selectedOption.Click();
            }
        }
        public void SelectElementFromListByText(IList<IWebElement> elementsList, string text)
        {
            foreach (IWebElement element in elementsList)
            {
                if (element.Text == text)
                    ClickOnElement(element);
            }
        }

        public DateTime FormatDate(string date)
        {
            var values = date.Split(',').Select(int.Parse).ToArray();
            var day = values[0];
            var month = values[1];
            var year = values[2];  

            var currentDate = DateTime.Now;
            var formattedDate = currentDate.AddDays(day).AddMonths(month).AddYears(year);

            return formattedDate;
        }
    }
}
