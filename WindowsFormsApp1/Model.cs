using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ViewData
    {
        /// <summary>
        /// 交易所名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusBid { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusAsk { get; set; }
        /// <summary>
        /// 幣別
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 買入價(最高可賣的價)
        /// </summary>
        public decimal Bid { get; set; }
        /// <summary>
        /// 賣出價(最低可買的價)
        /// </summary>
        public decimal Ask { get; set; }
        /// <summary>
        /// 手續費
        /// </summary>
        public decimal Fee { get; set; }

    }
    internal class Info
    {
        /// <summary>
        /// 交易所名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// BTC數量
        /// </summary>
        public decimal BTC { get; set; }
        /// <summary>
        /// USDT數量
        /// </summary>
        public decimal USDT { get; set; }
    }
    internal class Memo
    {
        public string Msg { get; set; }
    }
}
