using AutomationProject.Access;
using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class PracticeFormTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        PracticeFormPage practiceFormPage;

        [Test]
        public void StudentRegistrationForm()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            practiceFormPage = new PracticeFormPage(driver);
            var practiceFormData = new PracticeFormData(2);

            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            homePage.ClickOnFormsCard();

            commonPage.GoToMenu("Practice Form");

            Console.WriteLine($"data in node is : {practiceFormData.FirstName} {practiceFormData.LastName}\n" +
                $"{practiceFormData.Email} {practiceFormData.Gender} {practiceFormData.Phone}\n" + 
                $"data nasterii:{practiceFormData.DateOfBirth} {practiceFormData.CurrentAddress} ");

            practiceFormPage.FillPracticeFormUsingXML(practiceFormData);
            practiceFormPage.VerifyDataForm();

            /*
            practiceFormPage.CompleteFirstRegion("Ion", "Popa", "ionpopa@gmail.com","0987654321", "Strada Alexandru Macedonski nr.55");
            practiceFormPage.SelectGender("Male");
            practiceFormPage.SelectHobbies();
            */

          /*  
            IWebElement elementSubjects = webDriver.FindElement(By.Id("subjectsInput"));
            elementMethods.FillElement(elementSubjects, "English");
            elementMethods.FillElement(elementSubjects, Keys.Enter);
            elementMethods.FillElement(elementSubjects, "C");
            elementMethods.FillElement(elementSubjects, Keys.ArrowDown);
            elementMethods.FillElement(elementSubjects, Keys.ArrowDown);
            elementMethods.FillElement(elementSubjects, Keys.ArrowDown);
            elementMethods.FillElement(elementSubjects, Keys.Enter);

            List<IWebElement> listRemoveSubjects = webDriver.FindElements(By.XPath("//div[@class='css-xb97g8 subjects-auto-complete__multi-value__remove']")).ToList();
            bool subjectFlag = true;

            //the site will break if we remove all the elements in the list 
            //while (subjectFlag)
            //{
            //    foreach (IWebElement elementSubject in listRemoveSubjects)
            //        elementSubject.Click();
            //    subjectFlag = false;
            //}    

            //Date Picker

            IWebElement dateBirth = webDriver.FindElement(By.Id("dateOfBirthInput"));
            elementMethods.ClickOnElement(dateBirth);

            IWebElement datePickerMonth = webDriver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            SelectElement monthDropDown = new SelectElement(datePickerMonth);
            monthDropDown.SelectByValue("1");

            IWebElement datePickerYear = webDriver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            SelectElement yearDropDown = new SelectElement(datePickerYear);
            yearDropDown.SelectByValue("1990");

            int day = 7;
            IWebElement datePickerDate = webDriver.FindElement(By.XPath("//*[@class='react-datepicker__day react-datepicker__day--026' and not (contains(@class, '--outside-month'))]"));
            elementMethods.ClickOnElement(datePickerDate);*/

        }      

    }
}
