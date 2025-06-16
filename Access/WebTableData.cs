using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationProject.Access
{
    public partial class WebTableData
    {
        private XElement dataNode;

        public WebTableData(int dataSetNumber) 
        {
            LoadData(dataSetNumber);
            FirstName = GetValue("FirstName");
            LastName = GetValue("LastName");
            UserEmail = GetValue("Email");
            Age = GetValue("Age");
            Salary = GetValue("Salary");
            Department = GetValue("Department");
        }   
        private void LoadData(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationProject\\Resources\\WebTableData.xml");
            XDocument doc = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataNode = doc.Root.Element(nodeName);

            if (dataNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
        }

        private string GetValue (string nodeName)
        {
            return dataNode.Element(nodeName).Value;
           // dataNode.Element(nodeName)?.Value ?? throw new Exception($"Node {nodeName} not found in XML file!");
        }
    }
}
