using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITPointApi.Objects
{
    class BITPointApiResult
    {
        public string Result { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}
