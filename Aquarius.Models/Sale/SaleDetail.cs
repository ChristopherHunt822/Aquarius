using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Sale
{
    public class SaleDetail
    {
        public int SaleID { get; set; }

        public int AcctID { get; set; }

        public int CryptoID { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTimeOffset SaleDate { get; set; }

        public double Quantity { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Total Cost")]
        public decimal TotalValue { get; set; }
    }
}
