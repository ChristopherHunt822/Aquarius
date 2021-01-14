using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.CoinPriceAPIModels
{
    public class CoinDetailModel
    {

        public class Rootobject
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public string Base { get; set; }
            public string Currency { get; set; }
            public string Amount { get; set; }
        }


    }
}
