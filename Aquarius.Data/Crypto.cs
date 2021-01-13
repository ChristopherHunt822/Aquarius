using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Data
{
    public class Crypto
    {
        [Key]
        public int CryptoID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symbol { get; set; }


        [Required]
        public decimal Price { get; set; }


       

    }
}
