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
    public class Sale
    {
        [Key]
        [DataMember]
        public int SaleID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        [DataMember]
        [ForeignKey(nameof(Acct))]
        public int AcctID { get; set; }
        public virtual Acct Acct { get; set; }

        [Required]
        [DataMember]
        public CryptoSymbolEnum Symbol { get; set; }


        [Required]
        [DataMember]
        [Display(Name = "Date of Sale")]
        public DateTimeOffset SaleDate { get; set; }

        [Required]
        [DataMember]
        public decimal Quantity { get; set; }
        [Required]
        [DataMember]
        public decimal Price { get; set; }
       
        private decimal _total;

        [Required]
        [DataMember]
        public decimal Total
        {
            get => _total;
            set => _total = Quantity * Price;

        }



        public enum CryptoSymbolEnum { BTC = 1, ETH, LTC, XRP }
    }
}
