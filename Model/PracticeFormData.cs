using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Access
{
    public partial class PracticeFormData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Gender {  get; set; }
        public string Phone { get; set; }

       //public string DateOfBirth { get; set; }
       public DateTime DateOfBirth { get; set; }

       // public List<string> Subjects { get; set; }
        public string Subjects;

      // public List<string> Hobbies { get; set; }
        public string Hobbies { get; set; }
        public string CurrentAddress { get; set; }
        public string State {  get; set; }
        public string City { get; set; }

    }
}
