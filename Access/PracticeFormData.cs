using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationProject.Access
{
    public partial class PracticeFormData
    {
        private XElement dataNode;
        public PracticeFormData(int dataSetNumber) 
        { 
            LoadData(dataSetNumber);
            FirstName = GetValue("FirstName");
            LastName = GetValue("LastName");
            Email = GetValue("Email");
            Gender = GetValue("Gender");
            Phone = GetValue("Phone");
            //date of birth
            //DateOfBirth = GetValue("DateOfBirth");
           string DateOfBirthString = GetValue("DateOfBirth");

            if (!string.IsNullOrWhiteSpace(DateOfBirthString) &&
                 DateTime.TryParseExact(DateOfBirthString, "dd MMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                DateOfBirth = parsedDate;
            else
            {
                // Optionally handle missing DOB
                Console.WriteLine("Date of Birth invalid or missing");
                DateOfBirth = DateTime.Now;
            }
          
            //Subjects
            Subjects = GetValue("Subjects");
            //Hobbies
            Hobbies = GetValue("Hobbies");
            CurrentAddress = GetValue("CurrentAddress");
            State = GetValue("State");
            City = GetValue("City");
        }

        private string GetValue(string nodeName)
        {
            var element = dataNode.Element(nodeName);
            return element != null ? element.Value?.Trim() : string.Empty;
        }

        private void LoadData(int dataSetNumber)
        {
            string filePath = Path.Combine("C:\\Users\\npenea\\source\\repos\\AutomationProject\\Resources\\PracticeFormData.xml");
            XDocument document = XDocument.Load(filePath);

            string nodeName = $"dataSet_{dataSetNumber}";
            dataNode = document.Root.Element(nodeName);

            if (dataNode == null)
                throw new Exception($"Data set {dataSetNumber} not found in XML file");
          //  else Console.WriteLine($"Loaded node: {dataNode}");
        }
    }
}
