﻿using Aquarius.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.PurchaseModels
{
    public class PurchaseCreate
    {

        [Required]
        public int AcctID { get; set; }
        [Required]
        public PCryptoSymbolEnum Symbol { get; set; }

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



        public enum PCryptoSymbolEnum { BTC = 1, ETH, LTC, XRP }
    }
}
