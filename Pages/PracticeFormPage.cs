using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class PracticeFormPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public PracticeFormPage(IWebDriver webDriver)
        { 
            this.webDriver = webDriver;
            this.elementMethods = new ElementMethods(webDriver);
        }

        IWebElement firstNameElement => webDriver.FindElement(By.Id("firstName"));
        IWebElement lastNameElement => webDriver.FindElement(By.Id("lastName"));
        IWebElement emailElement => webDriver.FindElement(By.Id("userEmail"));
        IWebElement mobilePhoneElement => webDriver.FindElement(By.Id("userNumber"));
        IWebElement currentAddressElement => webDriver.FindElement(By.Id("currentAddress"));

        IWebElement genderMaleRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
        IWebElement genderFemaleRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
        IWebElement genderOtherRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-3']"));

        IWebElement sportsCheckBox => webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']"));
        IWebElement readingCheckBox => webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']"));
        IWebElement musicCheckBox => webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-3']"));

        public void CompleteFirstRegion(string firstName, string lastName, string email, string mobilePhone, string currentAddress)
        {
            elementMethods.FillElement(firstNameElement, firstName);
            elementMethods.FillElement(lastNameElement, lastName);
            elementMethods.FillElement(emailElement, email);
            elementMethods.FillElement(mobilePhoneElement, mobilePhone);
            elementMethods.FillElement(currentAddressElement, currentAddress);
        }

        public void SelectGender(string gender)
        {
            switch (gender)
            {
                case "Male":
                    elementMethods.ClickOnElement(genderMaleRadioButton);
                    break;
                case "Female":
                    elementMethods.ClickOnElement(genderFemaleRadioButton);
                    break;
                case "Other":
                    elementMethods.ClickOnElement(genderOtherRadioButton);
                    break;
            }
        }

        public void SelectHobbies()
        {
            List<IWebElement> hobbiesList = new List<IWebElement>();
            hobbiesList.Add(sportsCheckBox);
            hobbiesList.Add(readingCheckBox);
            hobbiesList.Add(musicCheckBox);

            string[] hobbiesArray = ["Sports", "Reading", "Music"];

            foreach (IWebElement hobby in hobbiesList)
            {
                foreach (string item in hobbiesArray)
                    if (hobby.Text.Equals(item)) elementMethods.ClickOnElement(hobby);
            }

        }

    }

}
