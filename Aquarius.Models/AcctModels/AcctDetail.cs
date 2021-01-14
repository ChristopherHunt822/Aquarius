using Aquarius.Models.PurchaseModels;
using Aquarius.Models.SaleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.AcctModels
{
    public class AcctDetail
    {
        [Display(Name = "Account #")]
        public int AcctID { get; set; }

        [Display(Name = "Account Name")]
        public string AcctName { get; set; }

        [Display(Name = "Account Type")]
        public AcctTypeEnum AcctType { get; set; }

        [Display(Name = "Total Value")]
        public decimal TotalValue { get; set; }

        [Display(Name = "Date Opened")]
        public DateTimeOffset OpenedUtc { get; set; }

        [Display(Name = "Investor #")]
        public int InvestorID { get; set; }

        public List<PurchaseListItem> Purchases { get; set; }
        public List<SaleListItem> Sales { get; set; }

        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA }
    }
}
