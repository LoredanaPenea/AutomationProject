using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationProject.Access
{
    public partial class SelectMenuData
    {
        private XElement dataNode;
        public SelectMenuData(int dataSetNumber) 
        {
            LoadData(dataSetNumber);
            SelectOption = GetValue("SelectOption");
            SelectTitle = GetValue("SelectTitle");
            OldStyleSelectMenu = GetValue("OldStyleSelectMenu");
            MultiselectDropDown = GetValue("MultiselectDropDown");
            StandardMultiselect = GetValue("StandardMultiselect");
        }

        private string GetValue(string nodeName)
        {
            var element = dataNode.Element(nodeName);
            return element != null ? element.Value?.Trim() : string.Empty;
        }

        private void LoadData(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationProject\\Resources\\SelectMenuData.xml");
            XDocument document = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataNode = document.Root.Element(nodeName);

            if (dataNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
            //  else Console.WriteLine($"Loaded node: {dataNode}");
        }
    }
}
