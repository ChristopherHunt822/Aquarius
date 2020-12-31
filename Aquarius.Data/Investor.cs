using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Data
{
    public class Investor
    {
        [Key]
        public int InvestorID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required(ErrorMessage = "Investor first name is required.")]
        [MaxLength(50, ErrorMessage = "Max Length 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Investor last name is required.")]
        [MaxLength(50, ErrorMessage = "Max Length 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        [Required(ErrorMessage = "Investor address is required.")]
        [MaxLength(100, ErrorMessage = "Max Length 100 characters")]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "A phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        public virtual List<Acct> Accts { get; set; } = new List<Acct>();
    }
}
