using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.PurchaseModels
{
    public class PurchaseDetail
    {
        public int PurchaseID { get; set; }

        public int AcctID { get; set; }

        public PCryptoSymbolEnum Symbol { get; set; }


        [Display(Name = "Date of Purchase")]
        public DateTimeOffset PurchaseDate { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        private decimal _total;

        [Display(Name = "Total Cost")]
        public decimal Total
        {
            get => _total;
            set => _total = Quantity * Price;

        }


        public enum PCryptoSymbolEnum { BTC = 1, ETH, LTC, XRP }
    }
}
