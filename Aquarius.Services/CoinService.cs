using Aquarius.Models.CoinPriceAPIModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Services
{
    public class CoinService
    {
        public CoinService()
        {

        }

        public string GetAllCoinInfo()
        {
            string apiKey = "abd90df5f27a7b170cd775abf89d632b350b7c1c9d53e08b340cd9832ce52c2c";

            List<String> listOfCoins = new List<String>() { "BTC", "ETH", "LTC", "XRP" };

            List<CoinDetailModel> listOfCrypto = new List<CoinDetailModel>();
            
            foreach (string coin in listOfCoins)
            {
                var client = new RestClient($"https://api.coinbase.com/v2/prices/{coin}-USD/spot?authorization=Bearer {apiKey}'");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                var myDeserializedClass = JsonConvert.DeserializeObject<CoinDetailModel>(response.Content);

                listOfCrypto.Add(myDeserializedClass);
            }

            var listOfCryptoInJson = JsonConvert.SerializeObject(listOfCrypto);

            return listOfCryptoInJson;
        }

        public async Task<CoinPriceModel> GetCoinPrice(string symbol)
        {
            string apiKey = "abd90df5f27a7b170cd775abf89d632b350b7c1c9d53e08b340cd9832ce52c2c";

            var client = new RestClient($"https://api.coinbase.com/v2/prices/{symbol}-USD/spot?authorization=Bearer {apiKey}'");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            var myDeserializedClass = JsonConvert.DeserializeObject<CoinPriceModel>(response.Content);

            return myDeserializedClass;
        }

        //public string CallKrakenAPI()
        //{

        //    List<String> listOfCoinPairs = new List<String>() { "BTC", "ETH", "LTC", "DOT", "KSM" };

        //    List<CoinAPIListItem> listOfCrypto = new List<CoinAPIListItem>();

        //    foreach (string coinpair in listOfCoinPairs)
        //    {
        //        var client = new RestClient($"https://api.kraken.com/0/public/Ticker?pair={coinpair}USD'");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.GET);
        //        IRestResponse response = client.Execute(request);

        //        var myDeserializedClass = JsonConvert.DeserializeObject<CoinAPIListItem>(response.Content);

        //        listOfCrypto.Add(myDeserializedClass);
        //    }

        //    var listOfCryptoInJson = JsonConvert.SerializeObject(listOfCrypto);

        //    return listOfCryptoInJson;
        //}
    }
}

