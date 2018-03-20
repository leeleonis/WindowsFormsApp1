using Newtonsoft.Json;
using System.Collections.Generic;

namespace GateioApi.Objects
{
    class TickerData
    {
        [JsonProperty("bids")]
        public string[] Bids { get; set; }

        [JsonProperty("asks")]
        public string[] Asks { get; set; }
    }
    class liem
    {
        public decimal price { get; set; }
        public decimal amount { get; set; }
    }
}
