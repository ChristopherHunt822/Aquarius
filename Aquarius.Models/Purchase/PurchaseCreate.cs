using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Purchase
{
    public class PurchaseCreate
    {


        public int AcctID { get; set; }

        public int CryptoID { get; set; }

        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalValue { get; set; }
    }
}
