using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Investor
{
    public class InvestorCreate
    {
        [Required(ErrorMessage = "Investor first name is required.")]
        [MaxLength(50, ErrorMessage = "Max Length 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Investor last name is required.")]
        [MaxLength(50, ErrorMessage = "Max Length 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Investor address is required.")]
        [MaxLength(100, ErrorMessage = "Max Length 100 characters")]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage = "Investor email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Investor phone number is required.")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
