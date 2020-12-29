﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Sale
{
    public class SaleCreate
    {
        [Required]
        public int AcctID { get; set; }
        [Required]
        public int CryptoID { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal TotalValue { get; set; }
    }
}