using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Acct
{
    public class AcctEdit
    {
        public int AcctID { get; set; }

        public AcctTypeEnum AcctType { get; set; }

        public int InvestorID { get; set; }


        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA }
    }
}
