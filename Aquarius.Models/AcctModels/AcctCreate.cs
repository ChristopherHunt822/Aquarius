using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.AcctModels
{
    public class AcctCreate
    {
        [Required]
        [Display(Name = "Account Type")]
        public AcctTypeEnum AcctType { get; set; }
        
        [Required]
        [Display(Name = "Account Name")]
        public string AcctName { get; set; }
        
        [Required]
        [Display(Name = "Total Value")]
        public decimal TotalValue { get; set; }

        [Required]
        [Display(Name = "Investor #")]
        public int InvestorID { get; set; }


        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA }
    }
}
