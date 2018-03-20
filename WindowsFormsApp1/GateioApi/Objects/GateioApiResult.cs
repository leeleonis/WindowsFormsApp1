using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateioApi.Objects
{
    class GateioApiResult
    {
        public bool result { get; set; }
        [JsonProperty("bids")]
        public List<List<decimal>> Bids { get; set; }

        [JsonProperty("asks")]
        public List<List<decimal>> Asks { get; set; }
    }

}
