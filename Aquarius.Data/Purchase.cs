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
    public class Purchase
    {
        [Key]
        [DataMember]
        public int PurchaseID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        [DataMember]
        [ForeignKey(nameof(Acct))]
        public int AcctID { get; set; }
        public virtual Acct Acct { get; set; }

        [Required]
        [DataMember]
        public PCryptoSymbolEnum Symbol { get; set; }


        [Required]
        [Display(Name = "Date of Purchase")]
        [DataMember]
        public DateTimeOffset PurchaseDate { get; set; }
        
        [Required]
        [DataMember]
        public decimal Quantity { get; set; }
        [Required]
        [DataMember]
        public decimal Price { get; set; }
        [Required]
        [DataMember]
        public decimal Total
        {
            get => Quantity * Price;
        }

        

        public enum PCryptoSymbolEnum { BTC = 1, ETH, LTC, XRP }

    }
}
