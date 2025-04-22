using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
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
        public void FillRegistrationForm( string firstName, string lastName, string email, string age, string salary, string department)
        {
            elementMethods.FillElement(firstNameField, firstName);
            elementMethods.FillElement(lastNameField, lastName);
            elementMethods.FillElement(emailField, email);
            elementMethods.FillElement(ageField, age);
            elementMethods.FillElement(salaryField, salary);
            elementMethods.FillElement(departmentField, department);

            elementMethods.ClickOnElement(registrationSubmitBtn);

        }

        public int GetNumberOfCellsFromTable()
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

        public bool VerifySubmittedDatainTable()
        {
            bool correctData = false;

            return correctData;
        }

    }
}
