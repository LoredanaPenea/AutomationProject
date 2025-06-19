using AutomationProject.Access;
using AutomationProject.BasePage;
using AutomationProject.HelperMethods;
using AutomationProject.Pages;
using AutomationProject.Pages.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests.Elements
{
    public class WebTablesTest : BasePage.BasePage
    {
        HomePage homePage;
        CommonPage commonPage;
        WebTablesPage webTablesPage;

        [Test]
        public void WebTableAddRecordsInTable()
        {
            homePage = new HomePage(driver);
            commonPage = new CommonPage(driver);
            webTablesPage = new WebTablesPage(driver);
            var webTableData = new WebTableData(1);

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

        }
    }


}
