using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Purchase
{
    public class PurchaseDetail
    {
        public int PurchaseID { get; set; }

        public int AcctID { get; set; }

        public int CryptoID { get; set; }

        [Display(Name = "Date of Purchase")]
        public DateTime DatePurchased { get; set; }

        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalValue { get; set; }
    }
}
