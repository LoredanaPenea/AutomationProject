using AutomationProject.Access;
using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages.Widgets
{
    public class SelectMenuPage
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        JavaScriptMethods jsMethods;

        public SelectMenuPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
        }
        IWebElement selectOptionDropDown => webDriver.FindElement(By.Id("withOptGroup"));
        IWebElement selectTitleDropDown => webDriver.FindElement(By.Id("selectOne"));
        IWebElement oldStyleMenuSelect => webDriver.FindElement(By.Id("oldSelectMenu"));
        IWebElement multiSelectDropdown => webDriver.FindElement(By.XPath("//div[contains(@class,'yk16xz-control')]"));
        IWebElement standardMultiSelect => webDriver.FindElement(By.Id("cars"));

        public void SelectAllOptions(SelectMenuData selectMenuData)
        {
           // Select Value
            elementMethods.SelectOptionFromDropDown(selectOptionDropDown,selectMenuData.SelectOption);
            //Select Title
            SelectTitleOption(selectMenuData.SelectTitle);
            //Old Style Select Menu
            elementMethods.SelectByText(oldStyleMenuSelect,selectMenuData.OldStyleSelectMenu);
            //Multiselect drop-down
            //MultiselectDropDownOption(selectMenuData.MultiselectDropDown);
            //Standard multi select
            StandardMultiselectOption(selectMenuData.StandardMultiselect);
            
        }

        public void SelectTitleOption(string option)
        {
            elementMethods.SelectOptionFromDropDown(selectTitleDropDown, option); 
        }
        public void MultiselectDropDownOption(string multiDropDownOptions)
        {
            List<string> optionsList = multiDropDownOptions.Split(',')
                               .Select(s => s.Trim())
                               .ToList();
          elementMethods.SelectMultipleOptionsFromDropDown(multiSelectDropdown, optionsList);
        }
        public void StandardMultiselectOption(string standardMultiSelectOptions)
        {
            jsMethods.ScrollPageVertically(1000);
            List<string> optionsList = standardMultiSelectOptions.Split(',')
                               .Select(s => s.Trim().ToLowerInvariant())
                               .ToList();
            foreach (string option in optionsList)
                elementMethods.SelectByValue(standardMultiSelect, option);
        }
    }
}
