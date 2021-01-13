using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Data
{

    [DataContract]
    public class Acct
    {
        [Key]
        [DataMember]
        [Display(Name = "Account #")]
        public int AcctID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        [DataMember]
        [Display(Name = "Account Name")]
        public string AcctName { get; set; }
        [Required]
        [DataMember]
        [Display(Name = "Account Type")]
        public AcctTypeEnum AcctType { get; set; }
        [Required]
        [DataMember]
        [Display(Name = "Total Value")]
        public decimal TotalValue { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Date Opened")]
        public DateTimeOffset OpenedUtc { get; set; }

        [Required]
        [DataMember]
        [ForeignKey(nameof(Investor))]
        public int InvestorID { get; set; }
        public virtual Investor Investor { get; set; }

        public virtual List<Purchase> Purchases { get; set; } = new List<Purchase>();
        public virtual List<Sale> Sales { get; set; } = new List<Sale>();

        public enum AcctTypeEnum { Individual, Retirement, CSP, HSA}

    }
}
