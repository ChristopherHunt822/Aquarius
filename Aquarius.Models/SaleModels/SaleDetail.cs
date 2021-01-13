using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.SaleModels
{
    public class SaleDetail
    {
        public int SaleID { get; set; }

        public int AcctID { get; set; }

        public CryptoSymbolEnum Symbol { get; set; }


        [Display(Name = "Date of Sale")]
        public DateTimeOffset SaleDate { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        private decimal _total;

        [Display(Name = "Total Proceeds")]
        public decimal Total
        {
            get => _total;
            set => _total = Quantity * Price;

        }


        public enum CryptoSymbolEnum { BTC = 1, ETH, LTC, XRP }
    }
}
