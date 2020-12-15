using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Data
{
    public class Acct
    {
        [Key]
        public int AcctID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public AcctTypeEnum AcctType { get; set; }
        [Required]
        public decimal TotalValue { get; set; }

        [Required]
        [Display(Name = "Date Opened")]
        public DateTimeOffset OpenedUtc { get; set; }


        [Required]
        [ForeignKey(nameof(Investor))]
        public int InvestorID { get; set; }
        public virtual Investor Investor { get; set; }

        
        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA}
    }
}
