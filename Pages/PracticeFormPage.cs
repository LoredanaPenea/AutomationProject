using AutomationProject.Access;
using AutomationProject.HelperMethods;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class PracticeFormPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public JavaScriptMethods jsMethods;
       // WebDriverWait wait;

        public PracticeFormPage(IWebDriver webDriver)
        { 
            this.webDriver = webDriver;
            this.elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
        }

        IWebElement firstNameElement => webDriver.FindElement(By.Id("firstName"));
        IWebElement lastNameElement => webDriver.FindElement(By.Id("lastName"));
        IWebElement emailElement => webDriver.FindElement(By.Id("userEmail"));
        IWebElement mobilePhoneElement => webDriver.FindElement(By.Id("userNumber"));
        IWebElement currentAddressElement => webDriver.FindElement(By.Id("currentAddress"));

        IWebElement genderMaleRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-1']"));
        IWebElement genderFemaleRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-2']"));
        IWebElement genderOtherRadioButton => webDriver.FindElement(By.XPath("//label[@for='gender-radio-3']"));
        IWebElement dateOfBirth => webDriver.FindElement(By.Id("dateOfBirthInput"));
        IWebElement datePickerMonth => webDriver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
        IWebElement datePickerYear => webDriver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
        IWebElement sportsCheckBox => webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']"));
        IWebElement readingCheckBox => webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']"));
        IWebElement musicCheckBox => webDriver.FindElement(By.XPath("//label[@for='hobbies-checkbox-3']"));

        IWebElement elementSubjects => webDriver.FindElement(By.Id("subjectsInput"));
        IWebElement uploadPictureBtn => webDriver.FindElement(By.Id("uploadPicture"));
        IWebElement selectStateDropDown => webDriver.FindElement(By.Id("state"));
        IWebElement selectCityDropDown => webDriver.FindElement(By.Id("city"));
        IWebElement submitBtn => webDriver.FindElement(By.Id("submit"));
        By modalContent => By.ClassName("modal-content");

        public void CompleteFirstRegion(string firstName, string lastName, string email, string mobilePhone, string currentAddress)
        {
            elementMethods.FillElement(firstNameElement, firstName);
            elementMethods.FillElement(lastNameElement, lastName);
            elementMethods.FillElement(emailElement, email);
            elementMethods.FillElement(mobilePhoneElement, mobilePhone);
            elementMethods.FillElement(currentAddressElement, currentAddress);
        }

        public void FillPracticeFormUsingXML(PracticeFormData practiceFormData)
        {
            elementMethods.FillElement(firstNameElement, practiceFormData.FirstName);
            elementMethods.FillElement(lastNameElement, practiceFormData.LastName);
            elementMethods.FillElement(emailElement, practiceFormData.Email);
            SelectGender(practiceFormData.Gender);
            elementMethods.FillElement(mobilePhoneElement, practiceFormData.Phone);
            //Date of birth
            SetDateOfBirth(practiceFormData.DateOfBirth);
           // CompleteDate(practiceFormData);
            //Subjects
            jsMethods.ScrollPageVertically(500);
            AddSubjects(practiceFormData.Subjects);
            //Hobbies
            SelectHobbiesUsingXML(practiceFormData.Hobbies);
            //Picture

            elementMethods.FillElement(currentAddressElement, practiceFormData.CurrentAddress);
            //State and City
            SelectState(practiceFormData.State);
            SelectCity(practiceFormData.City);
        }
       
        public void VerifyDataForm(PracticeFormData practiceFormData)
        {
            jsMethods.ScrollPageVertically(1000);
            elementMethods.ClickOnElement(submitBtn);
            
            var modalData = GetConfirmationModalData();

            if (practiceFormData.FirstName ==null) Console.WriteLine("Please provide First Name");
            if (practiceFormData.LastName == null) Console.WriteLine("Please provide Last Name");
            if(practiceFormData.Phone == null) Console.WriteLine("Please provide mobile phone number");
            if(practiceFormData.Gender == null) Console.WriteLine("Please select a gender");

            Console.WriteLine("Student Name: " + modalData["Student Name"]);
            if (string.IsNullOrEmpty(modalData["Student Email"]))
                Console.WriteLine("Email was not provided.");
            else
                Console.WriteLine("Email: " + modalData["Student Email"]);

            Console.WriteLine("Gender: " + modalData["Gender"]);
            Console.WriteLine("Mobile Phone: " + modalData["Mobile"]);
            Console.WriteLine("Date Of Birth: " + modalData["Date of Birth"]);
            Console.WriteLine("Subjects: " + modalData["Subjects"]);
            Console.WriteLine("Hobbies: " + modalData["Hobbies"]);
            Console.WriteLine("Current Address: " + modalData["Address"]);
            Console.WriteLine("State and City: " + modalData["State and City"]);

        }

        public Dictionary<string, string> GetConfirmationModalData()
        {
            var modalData = new Dictionary<string, string>();

            // Locate all rows inside the table body of the modal
            var rows = webDriver.FindElements(By.XPath("//div[@class='modal-content']//table//tr"));

            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td"));

                if (columns.Count == 2)
                {
                    string label = columns[0].Text.Trim();
                    string value = columns[1].Text.Trim();
                    modalData[label] = value;
                }
            }

            return modalData;
        }

        public void SetDateOfBirth(DateTime date)
        { 
            string formattedDoB = date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            elementMethods.ClickOnElement(dateOfBirth);
            elementMethods.SelectAll(dateOfBirth);
            //elementMethods.FillElement(dateOfBirth,formattedDoB);
            elementMethods.TypeTextInDropDown(dateOfBirth, formattedDoB);
            elementMethods.PressEnter(dateOfBirth);
           
        }
        public void FillDateOfBirth(DateTime date)
        {
            Console.WriteLine($"date from practice form var is: {date}");
            elementMethods.ClickOnElement(dateOfBirth);
            elementMethods.SelectByText(datePickerMonth, date.Month.ToString());
            elementMethods.SelectByText(datePickerYear, date.Year.ToString());
            var day = webDriver.FindElement(By.XPath($"//*[@class='react-datepicker__day react-datepicker__day--0{date.Day}' and not (contains(@class, '--outside-month'))]"));


            elementMethods.SelectByValue(day, date.Day.ToString());

        }
        /*
        public void CompleteDate(PracticeFormData practiceFormData)
        {

            var dateTime = elementMethods.FormatDate(practiceFormData.DateOfBirth);

            elementMethods.ClickOnElement(dateOfBirth);
            elementMethods.SelectByText(datePickerMonth, dateTime.ToString("MMMM"));
            elementMethods.SelectByText(datePickerYear, dateTime.Year.ToString());
            var correctDay = webDriver.FindElement(By.XPath($"//*[@class='react-datepicker__day react-datepicker__day--0{dateTime.Day}' and not (contains(@class, '--outside-month'))]"));
            correctDay.Click();
        } */
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
        public void SelectHobbiesUsingXML(string hobbies)
        {
            List<IWebElement> hobbiesCheckBoxList = new List<IWebElement>();
            hobbiesCheckBoxList.Add(sportsCheckBox);
            hobbiesCheckBoxList.Add(readingCheckBox);
            hobbiesCheckBoxList.Add(musicCheckBox);

            List<string> hobbyList = hobbies.Split(',')
                                .Select(s => s.Trim())
                                .ToList();
            foreach (IWebElement hobbyCheckBox in hobbiesCheckBoxList)
                foreach (string hobby in hobbyList)
                    if(hobbyCheckBox.Text.Equals(hobby)) elementMethods.ClickOnElement(hobbyCheckBox);
            
            //foreach (string hobby in hobbyList)
             //   elementMethods.SelectElementFromListByText(hobbiesCheckBoxList, hobby);
        }

        public void AddSubjects(string subjects)
        {
            List<string> subjectsList = subjects.Split(',')
                                .Select(s => s.Trim())
                                .ToList();
            foreach (string subject in subjectsList)
            {
                elementMethods.TypeTextInDropDown(elementSubjects, subject);
                elementMethods.PressEnter(elementSubjects);
            }
        }

        public void SelectState(string state)
        {
            elementMethods.ClickOnElement(selectStateDropDown);
            List<string> statesList = new List<string> { "NCR", "Uttar Pradesh", "Haryana", "Rajasthan" };

            foreach (string stateValue in statesList)
                if (stateValue.Equals(state)) elementMethods.SelectValueFromDropDown(state);
           // elementMethods.SelectValueFromDropDown(state);


        }
        public void SelectCity(string city)
        {
            elementMethods.ClickOnElement(selectCityDropDown);
            elementMethods.SelectValueFromDropDown(city);
        }
    }

}
