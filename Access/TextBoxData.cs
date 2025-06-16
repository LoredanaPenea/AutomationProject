using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationProject.Access
{
    public partial class TextBoxData
    {
        private XElement dataNode;

        public TextBoxData(int dataSetNumber)
        { 
            LoadData(dataSetNumber);
            FullName = GetValue("FullName");
            Email = GetValue("Email");
            CurrentAddress = GetValue("CurrentAddress");
            PermanentAddress = GetValue("PermanentAddress");

        }

        private void LoadData(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationProject\\Resources\\TextBoxData.xml");
            XDocument doc = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataNode = doc.Root.Element(nodeName);

            if (dataNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
        }

        private string GetValue(string nodeName)
        {
            return dataNode.Element(nodeName).Value;
        }
    }
}
