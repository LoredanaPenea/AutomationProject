using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class WebTableTest
    {
        IWebDriver webDriver;
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        WebTablesPage webTablesPage;

        [Test]
        public void WebTableMethod()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demoqa.com/");
            webDriver.Manage().Window.Maximize();

            elementMethods = new ElementMethods(webDriver);
            homePage = new HomePage(webDriver);
            commonPage = new CommonPage(webDriver);
            webTablesPage = new WebTablesPage(webDriver);


            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)webDriver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            homePage.ClickOnElementsCard();
            commonPage.GoToMenu("Web Tables");

            webTablesPage.AddNewRecordInTable();
            webTablesPage.FillRegistrationForm("Loredana", "Penea", "loredana.penea@email.com", "36", "5500", "IT");
            int rowIndex = webTablesPage.GetNumberOfRowsFromTable();
            
            string firstNameInTable = webTablesPage.GetColumnFromRow(rowIndex, "First Name");
            string lastNameInTable = webTablesPage.GetColumnFromRow(rowIndex, "Last Name");
            string emailInTable = webTablesPage.GetColumnFromRow(rowIndex, "Email");
            string ageInTable = webTablesPage.GetColumnFromRow(rowIndex, "Age");
            string salaryInTable = webTablesPage.GetColumnFromRow(rowIndex, "Salary");
            string departamentInTable = webTablesPage.GetColumnFromRow(rowIndex, "Department");

            Assert.That(firstNameInTable.Equals("Loredana"));
            if (lastNameInTable.Equals("Penea"))
            {
                Console.WriteLine($"Is true, last name is: {lastNameInTable}");
            }

            webTablesPage.AddNewRecordInTable();
            webTablesPage.FillRegistrationForm("Ionela", "Ionescu", "ionela.ionescu@email.com", "44", "6000", "Finance");
            webTablesPage.AddNewRecordInTable();
            webTablesPage.FillRegistrationForm("Mihai", "Marinescu", "mihai.marinescu@email.com", "29", "5500", "Platform");
            rowIndex = webTablesPage.GetNumberOfRowsFromTable();

            firstNameInTable = webTablesPage.GetColumnFromRow(rowIndex, "First Name");
            lastNameInTable = webTablesPage.GetColumnFromRow(rowIndex, "Last Name");
            emailInTable = webTablesPage.GetColumnFromRow(rowIndex, "Email");
            ageInTable = webTablesPage.GetColumnFromRow(rowIndex, "Age");
            salaryInTable = webTablesPage.GetColumnFromRow(rowIndex, "Salary");
            departamentInTable = webTablesPage.GetColumnFromRow(rowIndex, "Department");

            Console.WriteLine($"Last entry from Registration form is: {firstNameInTable}  {lastNameInTable}");

        }

        [TearDown]
        public void TearDown()
        {
            // webDriver.Quit();
            webDriver.Close();
        }
    }


}
