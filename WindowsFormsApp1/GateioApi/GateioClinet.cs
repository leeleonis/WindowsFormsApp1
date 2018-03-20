using GateioApi.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GateioApi
{
    class GateioClinet : IDisposable
    {
        public GateioClinet()
        {

        }
        public GateioApiResult SubscribeTicker(string symbol, Action<GateioApiResult> onUpdate)
        {
            var responsedata = new GateioApiResult();
            var url = "http://data.gateio.io/api2/1/orderBook/";
            Task.Factory.StartNew(() =>
            {
                using (var httpClient = new HttpClient())
                {
                    while (true)
                    {
                        var response = httpClient.GetStringAsync(url + symbol).Result;
                        responsedata = JsonConvert.DeserializeObject<GateioApiResult>(response);
                        if (responsedata.result)
                        {
                            onUpdate(responsedata);
                        }
                        Thread.Sleep(10000);
                    }
                }
            });
            return responsedata;
        }

        public void Dispose() { }
    }
}
