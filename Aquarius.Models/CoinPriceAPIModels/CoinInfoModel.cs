using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.CoinPriceAPIModels
{
    public class CoinInfoModel
    {

        public class Rootobject
        {
            public object[] error { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public XETHZUSD XETHZUSD { get; set; }
        }

        public class XETHZUSD
        {
            public string[] a { get; set; }
            public string[] b { get; set; }
            public string[] c { get; set; }
            public string[] v { get; set; }
            public string[] p { get; set; }
            public int[] t { get; set; }
            public string[] l { get; set; }
            public string[] h { get; set; }
            public string o { get; set; }
        }

    }
}
