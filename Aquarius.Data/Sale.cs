﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Data
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        [ForeignKey(nameof(Crypto))]
        public int AcctID { get; set; }
        public virtual Acct Acct { get; set; }

        [Required]
        [ForeignKey(nameof(Crypto))]
        public int CryptoID { get; set; }
        public virtual Crypto Crypto { get; set; }

        [Required]
        [Display(Name = "Date of Sale")]
        public DateTimeOffset SaleDate { get; set; }

        [Required]
        public double Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal TotalValue { get; set; }
    }
}