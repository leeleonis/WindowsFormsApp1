using Binance.Net;
using HitbtcApi.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hitbtc;
using HuobiApi;
using GateioApi;
using CoinexApi;
using WebSocket4Net;
using System.IO;
using System.IO.Compression;
using System.Security.Authentication;
using System.Net;
using System.Net.Http;
using GateioApi.Objects;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static decimal Ratio = 1;
        public static decimal TempOder = 0;
        public static bool bExchange = false;
        public decimal MinQuantity = 0.5M;
        List<ViewData> ListVal = new List<ViewData>();
        List<Info> ListInfo = new List<Info>();
        List<Memo> ListMsg = new List<Memo>();
        List<ExchangeTurnover> ListTurn = new List<ExchangeTurnover>();
        public string Banapi = "h5TWlHtbZBKdpoyXPAoKmYlaomjldPUqdpPXbM9GJPzTnP9fHXBjeALSs8Bpmafy";
        public string BanSecret = "nBaIuHv1pTXBC2bz5x8fF8nfcudcpp0jLQsQgCcS1kxMEJzxjWo3hOFnUNIcYg40";
        public string Hitapi = "c5fcf2185b0d96905e523b2e7c621ebc";
        public string HitSecret = "47bf92e959e2aea11801d709306c977f";
        public static decimal BanBTC { get; set; }
        public static decimal BanUSDT { get; set; }
        //public static decimal BanFee { get; set; }
        public static decimal HitBTC { get; set; }
        public static decimal HitUSDT { get; set; }
        //public static decimal HitFee { get; set; }
        public static decimal AllBTC { get; set; }
        public static decimal AllUSDT { get; set; }
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            //報價
            ListVal.Add(new ViewData { Name = "Binance", Bid = 0, Ask = 0, Fee = 0.05M, Currency = "BTCUSDT", ViewType = "BTCUSDT" });
            ListVal.Add(new ViewData { Name = "Hitbtc", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "BTCUSD", ViewType = "BTCUSDT" });
            ListVal.Add(new ViewData { Name = "Huobi", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "btcusdt", ViewType = "BTCUSDT" });
            ListVal.Add(new ViewData { Name = "Gateio", Bid = 0, Ask = 0, Fee = 0.2M, Currency = "btc_usdt", ViewType = "BTCUSDT" });
            ListVal.Add(new ViewData { Name = "Coinex", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "btcusdt", ViewType = "BTCUSDT" });
            //ListVal.Add(new ViewData { Name = "Binance", Bid = 0, Ask = 0, Fee = 0.05M, Currency = "ETHBTC" });
            //ListVal.Add(new ViewData { Name = "Hitbtc", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "ETHBTC" });
            //ListVal.Add(new ViewData { Name = "Binance", Bid = 0, Ask = 0, Fee = 0.05M, Currency = "ETHUSDT" });
            //ListVal.Add(new ViewData { Name = "Hitbtc", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "ETHUSD" });
            //ListVal.Add(new ViewData { Name = "Binance", Status = "OK", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "BCC" });
            //ListVal.Add(new ViewData { Name = "Hitbtc", Status = "OK", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "BCH" });
            //ListVal.Add(new ViewData { Name = "Binance", Status = "OK", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "USDT" });
            //ListVal.Add(new ViewData { Name = "Hitbtc", Status = "OK", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "UDS" });
            //帳戶資訊
            ListInfo.Add(new Info { Name = "Binance", Status = "", BTC = 0, USDT = 0 });
            ListInfo.Add(new Info { Name = "Hitbtc", Status = "", BTC = 0, USDT = 0 });
            // ListInfo.Add(new Info { Name = "總量", Status = "OK", BTC = 0, USDT = 0 });
            //BanFee = 0.1M;
            //HitFee = 0.1M;
            dataGridViewMoney.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var p = 200m;
            //for (int i = 0; i < 100; i++)
            //{
            //    p *= 1 + 0.012m;
            //    Console.Write(i.ToString("00") + ":");
            //    Console.WriteLine(p);
            //}
            GetInfo();
            GetTicker();
            //MatchCheck();
        }
        /// <summary>
        /// 比價差
        /// </summary>
        private void MatchCheck()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    foreach (var item1 in ListVal)
                    {
                        foreach (var item2 in ListVal)
                        {
                            if (item1.Name!=item2.Name)
                            {
                                var Askval = item1.Ask * (1 + (item1.Fee / 100));
                                var Bidval = item2.Bid * (1 - (item2.Fee / 100));
                                var TurnVal = ListTurn.Where(x => x.Name1 == item1.Name && x.Name2 == item2.Name);
                                var Spread = Bidval - Askval;
                                if (TurnVal.Any())
                                {
                                    foreach (var TurnValitem in TurnVal)
                                    {
                                        TurnValitem.Spread = Spread;
                                        if (Spread > 0)
                                        {
                                            if (TurnValitem.Status == "-")
                                            {
                                                TurnValitem.Status = "+";
                                                TurnValitem.Turn++;
                                            }

                                        }
                                        else
                                        {
                                            if (TurnValitem.Status == "+")
                                            {
                                                TurnValitem.Status = "-";
                                                TurnValitem.Turn++;
                                            }
                                        }                                
                                    }
                                }
                                else
                                {
                                    var TurnValitem = new ExchangeTurnover();
                                    ListTurn.Add(TurnValitem);
                                    TurnValitem.Name1 = item1.Name;
                                    TurnValitem.Name2 = item2.Name;
                                    TurnValitem.Spread = Spread;
                                    TurnValitem.Turn = 0;
                                    if (Spread > 0)
                                    {
                                        TurnValitem.Status = "+";
                                    }
                                    else
                                    {
                                        TurnValitem.Status = "-";
                                    }
                                }
                            }
                        }
                    }
                    //var highest = ListVal.OrderByDescending(x => x.Bid).FirstOrDefault();
                    //if (TempName != highest.Name)
                    //{
                    //    TempName = highest.Name;
                    //    var msg = string.Format("最高價：{0}", TempName);
                    //    ListMsg.Insert(0, new Memo { Msg = msg });
                    //    var sourceMemo = new BindingSource();
                    //    sourceMemo.DataSource = ListMsg;
                    //    SysHelper.Print(dataGridViewMemo, sourceMemo);
                    //}
                    var i = 0;
                    foreach (var item in ListTurn)
                    {
                        var msg = string.Format("交易所：{0}>{1} 價差：{2} ；翻轉次數{3}" ,item.Name1,item.Name2, item.Spread, item.Turn);
                        ListMsg.Insert(0, new Memo { Msg = msg });
                    }
                   
                    var sourceMemo = new BindingSource();
                    sourceMemo.DataSource = ListMsg;
                    SysHelper.Print(dataGridViewMemo, sourceMemo);
                    Thread.Sleep(1000);
                }
            });
        }

        private void MatchExchange()
        {
            Task.Factory.StartNew(() =>
            {
                var TempName = "";
                while (bExchange)
                {
                    var lowest = ListVal.OrderBy(x => x.Ask).FirstOrDefault();
                    var highest = ListVal.OrderByDescending(x => x.Bid).FirstOrDefault();
                    var Askval = lowest.Ask * (1 + (lowest.Fee / 100));
                    var Bidval = highest.Bid * (1 - (highest.Fee / 100));
                    if (TempName != highest.Name)
                    {
                        if (Askval < Bidval)
                        {
                            TempName = highest.Name;
                            //獲利
                            var Profit = (Bidval * MinQuantity) - (Askval * MinQuantity);
                            string[] argsData = new string[] {
                            "測試",
                            highest.Name, //最高賣價交易所
                            Bidval.ToString(), //含手續費賣價
                            lowest.Name, //最低買價交易所
                            Askval.ToString(),  //含手續費買價
                            DateTime.Now.ToString(), //時間
                            highest.Bid.ToString(), //不含手續費賣價
                            lowest.Ask.ToString(),  //不含手續費買價
                            Profit.ToString(),  //獲利
                            MinQuantity.ToString()//交易數量
                            };
                            var msg = string.Format("{5} - {0} 配對完成： {1}的Bid - {2} 和 {3}的Ask - {4}   原Bid {6}   原Ask {7}   ;交易數量：{9} BTC  ＞獲利 {8} USDT", argsData);
                            ListMsg.Insert(0, new Memo { Msg = msg });
                            var sourceMemo = new BindingSource();
                            sourceMemo.DataSource = ListMsg;
                            SysHelper.Print(dataGridViewMemo, sourceMemo);
                        }
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        private void GetTicker()
        {
            foreach (var item in ListVal)
            {
                if (item.Name == "Binance")
                {
                    BinanceFun(item);
                }
                else if (item.Name == "Hitbtc")
                {
                    HitbtcFun(item);
                }
                else if (item.Name == "Huobi")
                {
                    HuobiFun(item);
                }
                else if (item.Name == "Gateio")
                {
                   GateioFun(item);
                }
                else if (item.Name == "Coinex")
                {
                    CoinexFun(item);
                }
            }
        }

        private void CoinexFun(ViewData item)
        {
            using (var CoinexClinet = new CoinexClinet())
            {
                var SocketResult = CoinexClinet.SubscribeTicker(item.Currency, (data) =>
                {
                    var Asklist = data.data.Asks;//賣出價
                    var Bidlist = data.data.Bids;//買入價
                    var Askitemlist = new List<HuobiApi.Objects.liem>();
                    var Biditemlist = new List<HuobiApi.Objects.liem>();
                    foreach (var listitem in Asklist)
                    {
                        Askitemlist.Add(new HuobiApi.Objects.liem { price = listitem[0], amount = listitem[1] });
                    }
                    foreach (var listitem in Asklist)
                    {
                        Biditemlist.Add(new HuobiApi.Objects.liem { price = listitem[0], amount = listitem[1] });
                    }
                    var Ask = Askitemlist.Max(x => x.price);
                    var Bid = Biditemlist.Min(x => x.price);

                    if (Ask > item.Ask)
                    {
                        item.StatusAsk = "上漲";
                    }
                    else
                    {
                        item.StatusAsk = "下跌";
                    }
                    if (Bid > item.Bid)
                    {
                        item.StatusBid = "上漲";
                    }
                    else
                    {
                        item.StatusBid = "下跌";
                    }
                    item.Ask = Ask * Ratio;//賣出價
                    item.Bid = Bid * Ratio;//買入價

                    var sourceMoney = new BindingSource();
                    sourceMoney.DataSource = ListVal;
                    SysHelper.Print(dataGridViewMoney, sourceMoney);
                });
            }
        }

        private void GateioFun(ViewData item)
        {
            using (var GateioClinet = new GateioClinet())
            {
                var SocketResult = GateioClinet.SubscribeTicker(item.Currency, (data) =>
                {
                    var Asklist = data.Asks;//賣出價
                    var Bidlist = data.Bids;//買入價
                    var Askitemlist = new List<HuobiApi.Objects.liem>();
                    var Biditemlist = new List<HuobiApi.Objects.liem>();
                    foreach (var listitem in Asklist)
                    {
                        Askitemlist.Add(new HuobiApi.Objects.liem { price = listitem[0], amount = listitem[1] });
                    }
                    foreach (var listitem in Asklist)
                    {
                        Biditemlist.Add(new HuobiApi.Objects.liem { price = listitem[0], amount = listitem[1] });
                    }
                    var Ask = Askitemlist.Max(x => x.price);
                    var Bid = Biditemlist.Min(x => x.price);

                    if (Ask > item.Ask)
                    {
                        item.StatusAsk = "上漲";
                    }
                    else
                    {
                        item.StatusAsk = "下跌";
                    }
                    if (Bid > item.Bid)
                    {
                        item.StatusBid = "上漲";
                    }
                    else
                    {
                        item.StatusBid = "下跌";
                    }
                    item.Ask = Ask * Ratio;//賣出價
                    item.Bid = Bid * Ratio;//買入價

                    var sourceMoney = new BindingSource();
                    sourceMoney.DataSource = ListVal;
                    SysHelper.Print(dataGridViewMoney, sourceMoney);
                });
            }
        }

        private void HitbtcFun(ViewData item)
        {
            using (var HitbtcSocketClient = new HitbtcSocketClient())
            {
                var SocketResult = HitbtcSocketClient.SubscribeTicker(item.Currency, (data) =>
                {

                    var Ask = data.Data.Ask* Ratio;//賣出價
                    var Bid = data.Data.Bid* Ratio;//買入價
                    if (Ask > item.Ask)
                    {

                        item.StatusAsk = "上漲";
                    }
                    else
                    {
                        item.StatusAsk = "下跌";
                    }
                    if (Bid > item.Bid)
                    {

                        item.StatusBid = "上漲";
                    }
                    else
                    {
                        item.StatusBid = "下跌";
                    }
                    item.Ask = Ask;//賣出價
                    item.Bid = Bid;//買入價

                    var sourceMoney = new BindingSource();
                    sourceMoney.DataSource = ListVal;
                    SysHelper.Print(dataGridViewMoney, sourceMoney);
                });
            }
        }

        private void BinanceFun(ViewData item)
        {
            using (var BinanceSocketClient = new BinanceSocketClient())
            {
                //var BTCUSDTDepth = BinanceSocketClient.SubscribeToDepthStream(item.Currency, (data) =>
                //{
                //    var AsksMin = data.Asks.OrderBy(x => x.Price)?.FirstOrDefault()?.Price;
                //    var AsksMax = data.Asks.OrderByDescending(x => x.Price)?.FirstOrDefault()?.Price;
                //    var BidsMin = data.Bids.OrderBy(x => x.Price)?.FirstOrDefault()?.Price;
                //    var BidsMax = data.Bids.OrderByDescending(x => x.Price)?.FirstOrDefault()?.Price;
                //    if (TempOder == 0 && AsksMin.HasValue)
                //    {
                //        TempOder = AsksMin.Value;
                //        ListMsg.Insert(0, new Memo { Msg = "買入：" + TempOder });
                //        var sourceMemo = new BindingSource();
                //        sourceMemo.DataSource = ListMsg;
                //        SysHelper.Print(dataGridViewMemo, sourceMemo);
                //    }
                //    else if (BidsMin > (TempOder * (1 + (0.5M / 100))))
                //    {
                //        ListMsg.Insert(0, new Memo { Msg = "已賣出：" + BidsMin });
                //        var sourceMemo = new BindingSource();
                //        sourceMemo.DataSource = ListMsg;
                //        SysHelper.Print(dataGridViewMemo, sourceMemo);
                //    }


                //});

                var successSymbol = BinanceSocketClient.SubscribeToDepthStream(item.Currency, (data) =>
                {
                    //dataGridViewMoney.DataSource = null;
                    try
                    {
                        var Ask = data.Asks.Max(x => x.Price) * Ratio;//賣出價
                        var Bid = data.Bids.Min(x => x.Price) * Ratio;//買入價
                        if (Ask > item.Ask)
                        {

                            item.StatusAsk = "上漲";
                        }
                        else
                        {
                            item.StatusAsk = "下跌";
                        }
                        if (Bid > item.Bid)
                        {

                            item.StatusBid = "上漲";
                        }
                        else
                        {
                            item.StatusBid = "下跌";
                        }
                        item.Ask = Ask;//賣出價
                        item.Bid = Bid;//買入價
                        var sourceMoney = new BindingSource();
                        sourceMoney.DataSource = ListVal;
                        SysHelper.Print(dataGridViewMoney, sourceMoney);
                    }
                    catch (Exception)
                    {
                    }
                 
                });
            }
        }

        private void HuobiFun(ViewData item)
        {
            //var result = HuobiMarket.Init();
            //var topic = string.Format(HuobiMarket.MARKET_DEPTH, "btcusdt", "step0");
            //var guid = Guid.NewGuid().ToString();
            //HuobiMarket.Subscribe(topic, guid);
            //HuobiMarket.OnMessage += (sender, data) =>
            //{
            //    Console.WriteLine("OnMessage:" + data.Message);
            //};

            using (var HuobiClientWebSocket = new HuobiClientWebSocket())
            {
                var SocketResult = HuobiClientWebSocket.SubscribeTicker(item.Currency, (data) =>
                {
                    var Asklist = data.Data.Asks;//賣出價
                    var Bidlist = data.Data.Bids;//買入價
                    var Askitemlist = new List<HuobiApi.Objects.liem>();
                    var Biditemlist = new List<HuobiApi.Objects.liem>();
                    foreach (var listitem in Asklist)
                    {
                        Askitemlist.Add(new HuobiApi.Objects.liem { price = listitem[0], amount = listitem[1] });
                    }
                    foreach (var listitem in Asklist)
                    {
                        Biditemlist.Add(new HuobiApi.Objects.liem { price = listitem[0], amount = listitem[1] });
                    }
                    var Ask = Askitemlist.Max(x => x.price);
                    var Bid = Biditemlist.Min(x => x.price);

                    if (Ask > item.Ask)
                    {

                        item.StatusAsk = "上漲";
                    }
                    else
                    {
                        item.StatusAsk = "下跌";
                    }
                    if (Bid > item.Bid)
                    {

                        item.StatusBid = "上漲";
                    }
                    else
                    {
                        item.StatusBid = "下跌";
                    }
                    item.Ask = Ask * Ratio;//賣出價
                    item.Bid = Bid * Ratio;//買入價

                    var sourceMoney = new BindingSource();
                    sourceMoney.DataSource = ListVal;
                    SysHelper.Print(dataGridViewMoney, sourceMoney);
                });
            }
        }

        private void GetInfo()
        {
            foreach (var item in ListInfo)
            {
                if (item.Name == "Binance")
                {
                    #region Binance
                    //讀取帳戶資訊
                    using (var client = new BinanceClient(Banapi, BanSecret))
                    {
                        var accountInfo = client.GetAccountInfo();
                        if (accountInfo.Success)
                        {
                            BanBTC = accountInfo.Data.Balances.Where(x => x.Asset == "BTC").FirstOrDefault().Total;
                            BanUSDT = accountInfo.Data.Balances.Where(x => x.Asset == "USDT").FirstOrDefault().Total;
                            item.BTC = BanBTC;
                            item.USDT = BanUSDT;
                            item.Status = "OK";
                        }
                        else
                        {
                            item.Status = "Err";
                        }
                    }
                    #endregion
                }
                else if (item.Name == "Hitbtc")
                {
                    #region Hitbtc
                    using (var client = new HitbtcSocketClient(Hitapi, HitSecret))
                    {
                        var accountInfo = client.GetAccountbalance();
                        HitBTC = accountInfo.Where(x => x.currency == "BTC").FirstOrDefault().available;
                        HitUSDT = accountInfo.Where(x => x.currency == "USD").FirstOrDefault().available;
                        item.BTC = HitBTC;
                        item.USDT = HitUSDT;
                        item.Status = "OK";
                    }

                    #endregion
                }
                else
                {
                    //item.BTC = HitBTC+ BanBTC;
                    //item.USDT = HitUSDT+ BanUSDT;
                    //item.Status = "OK";
                }
            }
            var sourceInfo = new BindingSource();
            sourceInfo.DataSource = ListInfo;
            SysHelper.Print(dataGridViewInfo, sourceInfo);
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            if (bExchange)
            {
                btnExchange.Text = "開始";
                bExchange = false;
            }
            else
            {
                btnExchange.Text = "停止";
                bExchange = true;
            }
            MatchExchange();
        }
    }
}