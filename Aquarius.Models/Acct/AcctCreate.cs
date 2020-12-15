using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Acct
{
    public class AcctCreate
    {
        [Required]
        public AcctTypeEnum AcctType { get; set; }
        [Required]

        public decimal TotalValue { get; set; }

        [Required]

        public int InvestorID { get; set; }


        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA }
    }
}
