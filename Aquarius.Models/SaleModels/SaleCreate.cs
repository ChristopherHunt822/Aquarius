﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.SaleModels
{
    public class SaleCreate
    {
        [Required]
        public int AcctID { get; set; }
        [Required]
        public CryptoSymbolEnum Symbol { get; set; }

        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        private decimal _total;

        public decimal Total
        {
            get => _total;
            set => _total = Quantity * Price;

        }


        public enum CryptoSymbolEnum { BTC = 1, ETH, LTC, XRP }
    }
}
