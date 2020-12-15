using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Investor
{
    public class InvestorDetail
    {
        public int InvestorID { get; set; }
       
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        
    }
}
