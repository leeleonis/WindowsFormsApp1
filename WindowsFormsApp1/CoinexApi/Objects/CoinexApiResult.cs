using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinexApi.Objects
{
    class CoinexApiResult
    {
        public int code { get; set; }
        public TickerData data { get; set; }
    }
    class TickerData
    {
        [JsonProperty("bids")]
        public List<decimal[]> Bids { get; set; }

        [JsonProperty("asks")]
        public List<decimal[]> Asks { get; set; }
    }
}
