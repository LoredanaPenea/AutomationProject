using AutomationProject.Access;
using AutomationProject.BasePage;
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
    public class WebTableTest : BasePage.BasePage
    {
        ElementMethods elementMethods;
        HomePage homePage;
        CommonPage commonPage;
        WebTablesPage webTablesPage;

        [Test]
        public void WebTableAddRecordsInTable()
        {
            elementMethods = new ElementMethods(driver);
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            webTablesPage = new WebTablesPage(driver);
            var webTableData = new WebTableData(1);


            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
            jsExec.ExecuteScript("window.scrollTo(0,1000)");

            homePage.ClickOnElementsCard();
            commonPage.GoToMenu("Web Tables");

            webTablesPage.AddNewRecordInTable();
            webTablesPage.FillRegistrationFormUsingXML(webTableData);
           // webTablesPage.FillRegistrationForm("Loredana", "Penea", "loredana.penea@email.com", "36", "5500", "IT");
            int rowIndex = webTablesPage.GetNumberOfRowsFromTable();

            bool result = webTablesPage.VerifySubmittedDataInTable(rowIndex,"Loredana","Penea", "loredana.penea@email.com", "36", "5500", "IT");
            
            if (result)
                Console.WriteLine("Is true, data was added correctly in the table");

            webTablesPage.AddNewRecordInTable();
            webTablesPage.FillRegistrationForm("Ionela", "Ionescu", "ionela.ionescu@email.com", "44", "6000", "Finance");
           
            webTablesPage.AddNewRecordInTable();
            webTablesPage.FillRegistrationForm("Mihai", "Marinescu", "mihai.marinescu@email.com", "29", "5500", "Platform");
            rowIndex = webTablesPage.GetNumberOfRowsFromTable();
          //  result = webTablesPage.VerifySubmittedDataInTable(rowIndex, "Mihai", "Marinescu", "mihai.marinescu@email.com", "29", "5500", "Platform");
           // if(result) Console.WriteLine("Last record is added with correct data");

            /*
           string firstNameInTable = webTablesPage.GetColumnFromRow(rowIndex, "First Name");
           string lastNameInTable = webTablesPage.GetColumnFromRow(rowIndex, "Last Name");
           string emailInTable = webTablesPage.GetColumnFromRow(rowIndex, "Email");
           string ageInTable = webTablesPage.GetColumnFromRow(rowIndex, "Age");
           string salaryInTable = webTablesPage.GetColumnFromRow(rowIndex, "Salary");
           string departamentInTable = webTablesPage.GetColumnFromRow(rowIndex, "Department");

             Console.WriteLine($"Last entry from Registration form is: {firstNameInTable}  {lastNameInTable}"); */

        }
    }


}
