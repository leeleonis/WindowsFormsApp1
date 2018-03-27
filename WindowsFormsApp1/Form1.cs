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
using BittrexApi;
using BITPointApi;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static DateTime SYSdt = DateTime.Now;
        public static DateTime trydt = new DateTime(2018, 5, 1);
        public static string ID { get; set; }
        public static string PWD { get; set; }
        public static string url1 = "https://trade.bitpoint-tw.com/bptw-web/login";
        public static string url3 = "https://trade.bitpoint-tw.com/bptw-web/spot_trading";
        public static string htt = "";
        public static decimal Ratio = 30;
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
            //ListVal.Add(new ViewData { Name = "Hitbtc", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "BTCUSD", ViewType = "BTCUSDT" });
            //ListVal.Add(new ViewData { Name = "Huobi", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "btcusdt", ViewType = "BTCUSDT" });
            //ListVal.Add(new ViewData { Name = "Gateio", Bid = 0, Ask = 0, Fee = 0.2M, Currency = "btc_usdt", ViewType = "BTCUSDT" });
            //ListVal.Add(new ViewData { Name = "Coinex", Bid = 0, Ask = 0, Fee = 0.1M, Currency = "btcusdt", ViewType = "BTCUSDT" });
            //ListVal.Add(new ViewData { Name = "Bittrex", Bid = 0, Ask = 0, Fee = 0.25M, Currency = "USDT-BTC", ViewType = "BTCUSDT" });
            ListVal.Add(new ViewData { Name = "BITPoint", Bid = 0, Ask = 0, Fee = 0M, Currency = "BTCTWD", ViewType = "BTCTWD" });
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
            var list = new List<ComboboxItem>();
            list.Add(new ComboboxItem { Text = "台幣", Value = 1 });
            list.Add(new ComboboxItem { Text = "美金", Value = 30 });
            comboBoxCurrency.Items.AddRange(list.ToArray());
        }
        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 NForm2 = (Form2)sender;
            ID = NForm2.ID;
            PWD = NForm2.PWD;
            GetTicker();
            //this.textBox1.Text = NForm2.pw
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //試用日期

            if (trydt > DateTime.Today)
            {
                Form2 aChild = new Form2();
                aChild.ShowInTaskbar = false;
                aChild.ShowDialog(this);
                ID = aChild.ID;
                PWD = aChild.PWD;
                GetTicker();
            }
            else
            {
                MessageBox.Show("程式發生錯誤，請聯絡系統人員");
                this.Close();
            }

            //aChild.Show();
            //委託
            //aChild.FormClosed += new FormClosedEventHandler(Form2_FormClosed);


            //var p = 200m;
            //for (int i = 0; i < 100; i++)
            //{
            //    p *= 1 + 0.012m;
            //    Console.Write(i.ToString("00") + ":");
            //    Console.WriteLine(p);
            //}
            //GetInfo();
            //GetTicker();
            //MatchCheck();
            //var url1 = "https://trade.bitpoint-tw.com/bptw-web/login";
            //var url3 = "https://trade.bitpoint-tw.com/bptw-web/spot_trading";
            //webBrowserBtc.ScriptErrorsSuppressed = true;
            //webBrowserBtc.Navigate(url1);
            ////等網頁載完
            //loading(webBrowserBtc);
            //HtmlElement username = webBrowserBtc.Document.All["username"];
            //username.InnerText = "p6492leonis@gmail.com";
            //HtmlElement password = webBrowserBtc.Document.All["passwd"];
            //password.InnerText = "trazzp6492";
            //HtmlElement commit = webBrowserBtc.Document.All["login_btn"];
            //commit.InvokeMember("click");
            ////等網頁載完
            ////loading(webBrowserBtc);
            //webBrowserBtc.Navigate(url3);
            //等網頁載完
            //loading(webBrowserBtc);
            //WebBrowser NwebBrowserBtc = webBrowserBtc;
            //Task.Factory.StartNew(() =>
            //{

            //    var loginged = false;
            //    var url1 = "https://trade.bitpoint-tw.com/bptw-web/login";
            //    var url3 = "https://trade.bitpoint-tw.com/bptw-web/spot_trading";
            //    while (true)
            //    {
            //        try
            //        {

            //            NwebBrowserBtc.ScriptErrorsSuppressed = true;
            //            if (!loginged)
            //            {
            //                NwebBrowserBtc.Navigate(url1);
            //                //等網頁載完
            //                loading(webBrowserBtc);
            //                HtmlElement username = NwebBrowserBtc.Document.All["username"];
            //                username.InnerText = "p6492leonis@gmail.com";
            //                HtmlElement password = NwebBrowserBtc.Document.All["passwd"];
            //                password.InnerText = "trazzp6492";
            //                HtmlElement commit = NwebBrowserBtc.Document.All["login_btn"];
            //                commit.InvokeMember("click");
            //                //等網頁載完
            //                //loading(webBrowserBtc);
            //                NwebBrowserBtc.Navigate(url3);
            //                //等網頁載完
            //                //loading(webBrowserBtc);
            //                loginged = true;
            //            }
            //            HtmlElement ele = NwebBrowserBtc.Document.CreateElement("script");
            //            ele.SetAttribute("type", "text/javascript");
            //            ele.SetAttribute("text", @"function GetPictureData() { 
            //                            var vTable = $('body').html();
            //                            return vTable;}");

            //            NwebBrowserBtc.Document.Body.AppendChild(ele);
            //            object result = NwebBrowserBtc.Document.InvokeScript("GetPictureData");
            //            // convert string to stream
            //            byte[] byteArray = Encoding.UTF8.GetBytes(result.ToString());
            //            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            //            MemoryStream stream = new MemoryStream(byteArray);
            //            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //            doc.Load(stream, Encoding.UTF8);
            //            var bid = 0M;
            //            var ask = 0M;
            //            decimal.TryParse(doc.GetElementbyId("bid_BTCTWD")?.InnerText, out bid);
            //            decimal.TryParse(doc.GetElementbyId("ask_BTCTWD")?.InnerText, out ask);
            //            //responsedata.Ask = ask;
            //            //responsedata.Bid = bid;
            //            //onUpdate(responsedata);
            //        }
            //        catch (Exception ex)
            //        {
            //            loginged = false;
            //        }
            //        Thread.Sleep(1000);
            //    }

            //}).ContinueWith((taskResult) =>
            //{
            //    //// 顯示在 Form 的視窗標題上
            //    //this.Test = taskResult.Result.ToString();
            //}, TaskScheduler.FromCurrentSynchronizationContext()); ;


        }
        private void loading(WebBrowser webBrowserBtc)
        {
            while (!(webBrowserBtc.ReadyState == WebBrowserReadyState.Complete))
                Application.DoEvents();
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
                            if (item1.Name != item2.Name)
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
                        var msg = string.Format("交易所：{0}>{1} 價差：{2} ；翻轉次數{3}", item.Name1, item.Name2, item.Spread, item.Turn);
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
                        if (Askval < Bidval && Askval > 0 && Bidval > 0)
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
                else if (item.Name == "Bittrex")
                {
                    BittrexFun(item);
                }
                else if (item.Name == "BITPoint")
                {
                    BITPointFun(item);
                }
            }
        }

        private void BITPointFun(ViewData item)
        {
            using (var BITPointClinet = new BITPointClinet())
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        try
                        {
                            webBrowserBtc.ScriptErrorsSuppressed = true;

                            Action<string> test = s => GetElement(item);
                            this.Invoke(test, "test");
                            Application.DoEvents();


                        }
                        catch (Exception ex)
                        {

                        }
                        SpinWait.SpinUntil(() => false, 1000);
                    }

                }).ContinueWith((taskResult) =>
                {

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void GetElement(ViewData item)
        {
            Action<string> test = s => GetElement1(item);
            this.Invoke(test, "test");
            Application.DoEvents();
        }
        private void GetElement1(ViewData item)
        {
            var loginged = true;
            var haveData = true;
            var bid = 0M;
            var ask = 0M;
            while (loginged)
            {

                loginged = false;
                try
                {
                    if (webBrowserBtc.Document != null)
                    {
                        //HtmlElement bidPrice = webBrowserBtc.Document.All["bidPrice"];
                        //HtmlElement askPrice = webBrowserBtc.Document.All["askPrice"];


                        HtmlElement ele = webBrowserBtc.Document.CreateElement("script");
                        ele.SetAttribute("type", "text/javascript");
                        ele.SetAttribute("text", @"function GetPictureData() { 
                                        var vTable = $('body').html();
                                        return vTable;}");

                        webBrowserBtc.Document.Body.AppendChild(ele);
                        object result = webBrowserBtc.Document.InvokeScript("GetPictureData");
                        if (result != null)
                        {
                            // convert string to stream
                            byte[] byteArray = Encoding.UTF8.GetBytes(result.ToString());
                            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                            MemoryStream stream = new MemoryStream(byteArray);
                            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                            doc.Load(stream, Encoding.UTF8);

                            decimal.TryParse(doc.GetElementbyId("bid_BTCTWD")?.InnerText, out bid);
                            decimal.TryParse(doc.GetElementbyId("ask_BTCTWD")?.InnerText, out ask);
                        }
                        else
                        {
                            loginged = true;
                        }
                    }
                    else
                    {
                        haveData = false;
                    }
                    //if (SYSdt < DateTime.Now.AddMinutes(-5) && item.Ask == ask && item.Bid == bid)
                    //{
                    //    SYSdt = DateTime.Now;
                    //    webBrowserBtc.Navigate(url3);
                    //    //等網頁載完
                    //    loading(webBrowserBtc);
                    //    loginged = true;
                    //}

                }
                catch (Exception)
                {
                    haveData = false;
                }

                if ((bid == 0 && ask == 0 && !haveData)|| loginged|| SYSdt < DateTime.Now.AddMinutes(-30))
                {
                    SYSdt = DateTime.Now;
                    loginged = true;
                    webBrowserBtc.Navigate(url1);
                    //等網頁載完
                    loading(webBrowserBtc);
                    HtmlElement username = webBrowserBtc.Document.All["username"];
                    username.InnerText = ID;
                    HtmlElement password = webBrowserBtc.Document.All["passwd"];
                    password.InnerText = PWD;
                    HtmlElement commit = webBrowserBtc.Document.All["login_btn"];
                    commit.InvokeMember("click");
                    //等網頁載完
                    loading(webBrowserBtc);
                    webBrowserBtc.Navigate(url3);
                    //等網頁載完
                    loading(webBrowserBtc);
                    var divlist = webBrowserBtc.Document.GetElementsByTagName("div");
                    foreach (HtmlElement link1 in divlist)
                    {
                        if (link1.GetAttribute("className") == ("ui horizontal list"))
                        {
                            var divlistA = link1.GetElementsByTagName("div");
                            foreach (HtmlElement link2 in divlistA)
                            {
                                if (link2.GetAttribute("className") == "item")
                                {
                                    if( link2.InnerText.Contains("先生"))
                                    {
                                        labelName.Text = divlistA[0].InnerText + divlistA[1].InnerText;
                                    }
                                }
                            }
                        }
                    }
                    loginged = true;
                    haveData = true;
                }
                SpinWait.SpinUntil(() => false, 1000);
            }
            var Ask = ask;//賣出價
            var Bid = bid;//買入價
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

        private void BittrexFun(ViewData item)
        {
            using (var BittrexApiClinet = new BittrexApiClinet())
            {
                var SocketResult = BittrexApiClinet.SubscribeTicker(item.Currency, (data) =>
                {

                    var Ask = data.Sell.Min(x => x.Rate) * Ratio;//賣出價
                    var Bid = data.Buy.Max(x => x.Rate) * Ratio;//買入價
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
                    var Ask = Askitemlist.Min(x => x.price);
                    var Bid = Biditemlist.Max(x => x.price);

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
                    var Ask = Askitemlist.Min(x => x.price);
                    var Bid = Biditemlist.Max(x => x.price);

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

                    var Ask = data.Data.Ask * Ratio;//賣出價
                    var Bid = data.Data.Bid * Ratio;//買入價
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

                var successSymbol = BinanceSocketClient.SubscribeToPartialBookDepthStream(item.Currency,5, (data) =>
                {
                    //dataGridViewMoney.DataSource = null;
                    try
                    {
                        var Ask = data.Asks.Min(x => x.Price) * Ratio;//賣出價
                        var Bid = data.Bids.Max(x => x.Price) * Ratio;//買入價
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
                    var Ask = Askitemlist.Min(x => x.price);
                    var Bid = Biditemlist.Max(x => x.price);

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