using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.AcctModels
{
    public class AcctEdit
    {
        [Display(Name = "Account #")]
        public int AcctID { get; set; }

        [Display(Name = "Account Name")]
        public string AcctName { get; set; }

        [Display(Name = "Account Type")]
        public AcctTypeEnum AcctType { get; set; }

        [Display(Name = "Investor #")]
        public int InvestorID { get; set; }


        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA }
    }
}
