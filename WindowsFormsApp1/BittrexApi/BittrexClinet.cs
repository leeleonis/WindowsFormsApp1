using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bittrex.Net;
using Bittrex.Net.Objects;

namespace BittrexApi
{
    class BittrexApiClinet : IDisposable
    {
        public BittrexApiClinet()
        {

        }
        public BittrexOrderBook SubscribeTicker(string symbol, Action<BittrexOrderBook> onUpdate)
        {
         
            Task.Factory.StartNew(() =>
            {
                using (var BittrexClient = new BittrexClient())
                {
                    while (true)
                    {
                        var responsedata = BittrexClient.GetOrderBook(symbol);
                        if (responsedata.Success)
                        {
                            onUpdate(responsedata.Data);
                        }
                        Thread.Sleep(1000);
                    }
                }
            });
            return null;
        }
        public void Dispose() { }

    }
}
