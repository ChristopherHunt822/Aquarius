using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.Crypto
{
    public class CryptoCreate
    {
        [Required]
        [Display(Name = "Currency Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Currency Symbol")]
        public string Symbol { get; set; }
        
    }
}
