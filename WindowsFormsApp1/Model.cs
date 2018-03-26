using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ComboboxItem
    {
        public string Text { get; set; }
        public decimal Value { get; set; }
        public override string ToString() { return Text; }
    }
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
        /// <summary>
        /// 交易類型
        /// </summary>
        public string ViewType { get; set; }

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
    internal class ExchangeTurnover
    {
        /// <summary>
        /// 交易所1
        /// </summary>
        public string  Name1 { get; set; }
        /// <summary>
        /// 交易所2
        /// </summary>
        public string Name2 { get; set; }
        /// <summary>
        /// 價差
        /// </summary>
        public decimal Spread { get; set; }
        /// <summary>
        /// 翻轉次數
        /// </summary>
        public int Turn { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string Status { get; set; }
      
    }
}
