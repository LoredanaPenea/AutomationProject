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
           
            int rowIndex = webTablesPage.GetNumberOfRowsFromTable();
            webTablesPage.VerifyDataFromTable(rowIndex, webTableData);
            /*
            bool result = webTablesPage.VerifySubmittedDataInTable(rowIndex,"Loredana","Penea", "loredana.penea@test.com", "37", "6500", "Testing");
            if (result)
                Console.WriteLine("Is true, data was added correctly in the table");
            */

            webTablesPage.AddNewRecordInTable();
            webTableData = new WebTableData(2);
            webTablesPage.FillRegistrationFormUsingXML(webTableData);
            rowIndex = webTablesPage.GetNumberOfRowsFromTable();
            webTablesPage.VerifyDataFromTable(rowIndex, webTableData);

        }
    }


}
