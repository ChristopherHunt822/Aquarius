using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Crypto
{
    public class CryptoListItem
    {
        public int CryptoID { get; set; }

        [Display(Name = "Currency Name")]
        public string Name { get; set; }
        [Display(Name = "Currency Symbol")]
        public string Symbol { get; set; }

        //public decimal Price { get; set; }
        
        //[Display(Name ="Market Cap")]
        //public double MarketCap { get; set; }
    }
}