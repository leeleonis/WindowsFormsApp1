using CoinexApi.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinexApi
{
    class CoinexClinet : IDisposable
    {
        public CoinexClinet()
        {

        }
        public CoinexApiResult SubscribeTicker(string symbol, Action<CoinexApiResult> onUpdate)
        {
            var responsedata = new CoinexApiResult();
            var url = string.Format("https://api.coinex.com/v1/market/depth?market={0}&limit=10&merge=0", symbol);
            Task.Factory.StartNew(() =>
            {
                using (var httpClient = new HttpClient())
                {
                    while (true)
                    {
                        try
                        {
                            var response = httpClient.GetStringAsync(url).Result;
                            responsedata = JsonConvert.DeserializeObject<CoinexApiResult>(response);
                            if (responsedata.code == 0)
                            {
                                onUpdate(responsedata);
                            }
                        }
                        catch
                        {


                        }
                       
                        Thread.Sleep(1000);
                    }
                }
            });
            return responsedata;
        }
        public void Dispose() { }
    }
}
