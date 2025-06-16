using AutomationProject.Access;
using AutomationProject.HelperMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Pages
{
    public class TextBoxPage
    {
        public IWebDriver webDriver;
        public ElementMethods elementMethods;
        public JavaScriptMethods jsMethods;

        public TextBoxPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            elementMethods = new ElementMethods(webDriver);
            jsMethods = new JavaScriptMethods(webDriver);
        }
        IWebElement textBoxFullName => webDriver.FindElement(By.Id("userName"));
        IWebElement textBoxEmail => webDriver.FindElement(By.Id("userEmail"));
        IWebElement textBoxCurrentAddress => webDriver.FindElement(By.Id("currentAddress"));
        IWebElement textBoxPermanentAddress => webDriver.FindElement(By.Id("permanentAddress"));
        IWebElement buttonSubmit => webDriver.FindElement(By.Id("submit"));
        IWebElement outputBox => webDriver.FindElement(By.Id("output"));
        IWebElement outputFullName => webDriver.FindElement(By.Id("name"));
        IWebElement outputEmail => webDriver.FindElement(By.Id("email"));
        IWebElement outputCurrentAddress => webDriver.FindElement(By.XPath("//p[@id='currentAddress']"));
        IWebElement outputPermanentAddress => webDriver.FindElement(By.XPath("//p[@id='permanentAddress']"));
        

        public void FillInTextBoxForm(string fullName, string email, string currentAddress, string permanentAddress)
        {
            elementMethods.FillElement(textBoxFullName, fullName);
            elementMethods.FillElement(textBoxEmail, email);
            elementMethods.FillElement(textBoxCurrentAddress, currentAddress);
            elementMethods.FillElement(textBoxPermanentAddress, permanentAddress);

            jsMethods.ScrollPageVertically(500);
            elementMethods.ClickOnElement(buttonSubmit);
        }

        public void FillInTextBoxFormUsingXML(TextBoxData textBoxData)
        {
            elementMethods.FillElement(textBoxFullName, textBoxData.FullName);
            elementMethods.FillElement(textBoxEmail, textBoxData.Email);
            elementMethods.FillElement(textBoxCurrentAddress, textBoxData.CurrentAddress);
            elementMethods.FillElement(textBoxPermanentAddress, textBoxData.PermanentAddress);

            jsMethods.ScrollPageVertically(500);
            elementMethods.ClickOnElement(buttonSubmit);
        }

        public void VerifyTextBoxOutput(string fullName, string email, string currentAddress, string permanentAddress)
        {
            string actualName = outputFullName.Text.Substring(outputFullName.Text.IndexOf(':') + 1).Trim();
            string actualEmail = outputEmail.Text.Substring(outputEmail.Text.IndexOf(':') + 1).Trim();
            string actualCurrentAddress = outputCurrentAddress.Text.Split(':')[1].Trim();
            string actualPermanentAddress = outputPermanentAddress.Text.Split(':')[1].Trim();

            Console.WriteLine($"actual name is>{actualName}");
            Console.WriteLine($"actual email is>{actualEmail}");
            Console.WriteLine($"actual current address is>{actualCurrentAddress}");
            Console.WriteLine($"actual permanent address is>{actualPermanentAddress}");
            
        }
        public void DisplayOutputData()
        {
            Console.WriteLine($"Data you introduced is:\n{outputBox.Text}");
        }
    }
}
