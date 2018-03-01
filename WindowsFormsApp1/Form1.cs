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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static bool bExchange = false;
        public decimal MinQuantity = 0.1M;
        List<ViewData> ListVal = new List<ViewData>();
        List<Info> ListInfo = new List<Info>();
        List<Memo> ListMsg = new List<Memo>();
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
            ListVal.Add(new ViewData { Name = "Binance", Status = "OK", Bid = 0, Ask = 0, Fee = 0.05M, Currency = "BTCUSDT" });
            ListVal.Add(new ViewData { Name = "Hitbtc", Status = "OK", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "BTCUSDT" });
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetInfo();
            GetTicker();
        }

        private void MatchExchange()
        {
            Task.Factory.StartNew(() =>
            {
                while (bExchange)
                {
                    var lowest = ListVal.OrderBy(x => x.Ask).FirstOrDefault();
                    var highest = ListVal.OrderByDescending(x => x.Bid).FirstOrDefault();
                    var Askval = lowest.Ask;// * (1 + (lowest.Fee / 100));
                    var Bidval = highest.Bid;// * (1 - (highest.Fee / 100));
                    if (Askval < Bidval)
                    {
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
                        var msg = string.Format("{5} - {0} 配對完成： {1}的Bid - {2} 和 {3}的Ask - {4}   原Bid {6}   原Ask {7}   ;交易數量：{9}  ＞獲利 {8}", argsData);
                        ListMsg.Insert(0, new Memo { Msg = msg });
                        var sourceMemo = new BindingSource();
                        sourceMemo.DataSource = ListMsg;
                        SysHelper.Print(dataGridViewMemo, sourceMemo);
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        private void GetTicker()
        {
            using (var BinanceSocketClient = new BinanceSocketClient())
            {
                var successSymbol = BinanceSocketClient.SubscribeToSymbolTicker("BTCUSDT", (data) =>
                {
                    //dataGridViewMoney.DataSource = null;
                    foreach (var item in ListVal.Where(x => x.Name == "Binance" ))
                    {
                        item.Status = "OK";
                        item.Ask = data.BestAskPrice;//賣出價
                        item.Bid = data.BestBidPrice;//買入價
                    }
                    var sourceMoney = new BindingSource();
                    sourceMoney.DataSource = ListVal;
                    SysHelper.Print(dataGridViewMoney, sourceMoney);
                });
            }
            using (var HitbtcSocketClient = new HitbtcSocketClient())
            {
                var SocketResult = HitbtcSocketClient.SubscribeTicker("BTCUSD", (data) =>
                {
                    foreach (var item in ListVal.Where(x => x.Name == "Hitbtc"))
                    {
                        item.Status = "OK";
                        item.Ask = data.Data.Ask;//賣出價
                        item.Bid = data.Data.Bid;//買入價
                    }
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
