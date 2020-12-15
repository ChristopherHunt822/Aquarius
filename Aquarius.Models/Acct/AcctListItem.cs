using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Acct
{
    public class AcctListItem
    {
        public int AcctID { get; set; }

        public AcctTypeEnum AcctType { get; set; }
       
        public decimal TotalValue { get; set; }


        
        [Display(Name = "Date Opened")]
        public DateTimeOffset OpenedUtc { get; set; }

        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA }
    }
}
