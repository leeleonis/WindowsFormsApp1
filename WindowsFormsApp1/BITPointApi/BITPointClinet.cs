using BITPointApi.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITPointApi
{
    class BITPointClinet : IDisposable
    {
        public BITPointClinet()
        {

        }
        public BITPointApiResult SubscribeTicker(string symbol, WebBrowser webBrowserBtc ,Action<BITPointApiResult> onUpdate)
        {
           var responsedata = new BITPointApiResult();
            Task.Factory.StartNew(() =>
            {

                //var loginged = false;
                //var url1 = "https://trade.bitpoint-tw.com/bptw-web/login";
                //var url3 = "https://trade.bitpoint-tw.com/bptw-web/spot_trading";
                while (true)
                {
                    try
                    {
                        webBrowserBtc.ScriptErrorsSuppressed = true;
                        HtmlElement ele = webBrowserBtc.Document.CreateElement("script");
                        ele.SetAttribute("type", "text/javascript");
                        ele.SetAttribute("text", @"function GetPictureData() { 
                                        var vTable = $('body').html();
                                        return vTable;}");

                        webBrowserBtc.Document.Body.AppendChild(ele);
                        object result = webBrowserBtc.Document.InvokeScript("GetPictureData");
                        // convert string to stream
                        byte[] byteArray = Encoding.UTF8.GetBytes(result.ToString());
                        //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                        MemoryStream stream = new MemoryStream(byteArray);
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.Load(stream, Encoding.UTF8);
                        var bid = 0M;
                        var ask = 0M;
                        decimal.TryParse(doc.GetElementbyId("bid_BTCTWD")?.InnerText, out bid);
                        decimal.TryParse(doc.GetElementbyId("ask_BTCTWD")?.InnerText, out ask);
                        responsedata.Ask = ask;
                        responsedata.Bid = bid;
                        onUpdate(responsedata);
                    }
                    catch (Exception ex)
                    {
                        //responsedata.Result = "Err";
                        //onUpdate(responsedata);
                    }
                    SpinWait.SpinUntil(() => false, 10000);
                    //Thread.Sleep(1000);
                }

            }, CancellationToken.None
             , TaskCreationOptions.None
             , TaskScheduler.FromCurrentSynchronizationContext());
            return responsedata;
        }

        private void loading(WebBrowser webBrowserBtc)
        {
            while (!(webBrowserBtc.ReadyState == WebBrowserReadyState.Complete))
                Application.DoEvents();
        }

        public void Dispose() { }
        //等待網頁讀取完成
    }
}
