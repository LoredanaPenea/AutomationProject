using AutomationProject.Access;
using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AutomationProject.Pages.Elements
{
    public class WebTablesPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;

        public WebTablesPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
        }
        IWebElement addBtnInWebTable => webDriver.FindElement(By.Id("addNewRecordButton"));
        IWebElement firstNameField => webDriver.FindElement(By.Id("firstName"));
        IWebElement lastNameField => webDriver.FindElement(By.Id("lastName"));
        IWebElement emailField => webDriver.FindElement(By.Id("userEmail"));
        IWebElement ageField => webDriver.FindElement(By.Id("age"));
        IWebElement salaryField => webDriver.FindElement(By.Id("salary"));
        IWebElement departmentField => webDriver.FindElement(By.Id("department"));
        IWebElement registrationSubmitBtn => webDriver.FindElement(By.Id("submit"));
        

        public void AddNewRecordInTable()
        {
            elementMethods.ClickOnElement(addBtnInWebTable);
        }

        public void FillRegistrationFormUsingXML(WebTableData webTableData)
        {
            elementMethods.FillElement(firstNameField, webTableData.FirstName);
            elementMethods.FillElement(lastNameField, webTableData.LastName);
            elementMethods.FillElement(emailField, webTableData.UserEmail);
            elementMethods.FillElement(ageField, webTableData.Age);
            elementMethods.FillElement(salaryField, webTableData.Salary);
            elementMethods.FillElement(departmentField, webTableData.Department);

            elementMethods.ClickOnElement(registrationSubmitBtn);
        }
        public void VerifyDataFromTable(int rowIndex, WebTableData webTableData)
        {
            var rows = webDriver.FindElements(By.CssSelector("div.rt-tbody div[role='row']"));
            IWebElement row = rows[rowIndex-1];
            var cells = row.FindElements(By.CssSelector("div[role='gridcell']"))
               .Select(c => c.Text.Trim())
               .ToList();
         
            Assert.Multiple(() =>
            {
                Assert.That(cells[0], Is.EqualTo(webTableData.FirstName), "First name");
                Assert.That(cells[1], Is.EqualTo(webTableData.LastName), "Last name");
                Assert.That(cells[2], Is.EqualTo(webTableData.Age.ToString()), "Age");
                Assert.That(cells[3], Is.EqualTo(webTableData.UserEmail), "Email");
                Assert.That(cells[4], Is.EqualTo(webTableData.Salary.ToString()), "Salary");
                Assert.That(cells[5], Is.EqualTo(webTableData.Department), "Department");
            });

        }
        /*
        public void FillRegistrationForm(string firstName, string lastName, string email, string age, string salary, string department)
        {
            elementMethods.FillElement(firstNameField, firstName);
            elementMethods.FillElement(lastNameField, lastName);
            elementMethods.FillElement(emailField, email);
            elementMethods.FillElement(ageField, age);
            elementMethods.FillElement(salaryField, salary);
            elementMethods.FillElement(departmentField, department);

            elementMethods.ClickOnElement(registrationSubmitBtn);
        }  */

        public int GetNumberOfRowsFromTable()
        {
            var rows = webDriver.FindElements(By.CssSelector(".rt-tbody .rt-tr-group"));
            int numberOfRows = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(rows[i].Text))
                    numberOfRows = i + 1; // XPath uses 1-based indexing
            }
            //throw new ArgumentException("Table is empty. No rows with data");
            return numberOfRows;
        }

        public string GetColumnFromRow(int rowIndex, string columnName)
        {
            // Get all headers
            var headers = webDriver.FindElements(By.CssSelector(".rt-table .rt-thead.-header .rt-th"));

            int columnIndex = -1;

            // Find index for the given column name
            for (int i = 0; i < headers.Count; i++)
            {
                if (headers[i].Text.Trim().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    columnIndex = i + 1; // +1 because XPath is 1-based
                    break;
                }
            }

            if (columnIndex == -1)
            {
                throw new ArgumentException($"Column with name '{columnName}' not found.");
            }

            // Retrieve the cell based on row and resolved column index
            IWebElement row = webDriver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{rowIndex}]"));
            IWebElement column = row.FindElement(By.XPath($".//div[@class='rt-td'][{columnIndex}]"));

            return column.Text;
        }

        public bool VerifySubmittedDataInTable(int rowIndex, string firstName, string lastName, string email, string age, string salary, string department)
        {
            bool correctData = false;
            string firstNameInTable = GetColumnFromRow(rowIndex, "First Name");
            string lastNameInTable = GetColumnFromRow(rowIndex, "Last Name");
            string emailInTable = GetColumnFromRow(rowIndex, "Email");
            string ageInTable = GetColumnFromRow(rowIndex, "Age");
            string salaryInTable = GetColumnFromRow(rowIndex, "Salary");
            string departamentInTable = GetColumnFromRow(rowIndex, "Department");

            if (firstNameInTable.Equals(firstName) &&
           lastNameInTable.Equals(lastName) &&
           emailInTable.Equals(email) &&
           ageInTable.Equals(age) &&
           salaryInTable.Equals(salary) &&
           departamentInTable.Equals(department))
                correctData = true;

            return correctData;
        }

    }
}
