using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.BasePage.Browser
{
    public interface IBrowserService
    {
        void OpenBrowser();
        object BrowserOptions();
    }
}
