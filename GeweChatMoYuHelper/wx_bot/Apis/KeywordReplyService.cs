using GeweChatMoYuHelper.Model.Gewe.LoginModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GeweChatMoYuHelper.wx_bot.Apis
{
    public class KeywordReplyService
    {
        static string platformHostUrl = "http://myipv4.melove.icu:18004/api/public/wx-client";
        static string applicationToken = "08db8459-68e7-47ae-8a35-5c2973176b94";

        public static HttpClient GetHttpClient()
        {

            HttpClient client = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(60)
            };

            return client;
        }
        public async Task<string> getBotReply(string issue)
        {
            var header = new Dictionary<string, object>();

            try
            {
                string url = $"{platformHostUrl}/bot-reply/{applicationToken}?keyword=";
               // string url = "http://myipv4.melove.icu:18004/api/public/wx-client/bot-reply/08da6c59-b9a7-4ffb-8bdb-1e3e0de3952a?keyword=";
                HttpResponseMessage response = GetHttpClient().GetAsync(url + issue).Result;
                string res = await response.Content.ReadAsStringAsync();
                Console.WriteLine(res);

                var result = JsonConvert.DeserializeObject<ApiResponse>(res.ToString());

                // 6. 检查返回码是否为1 
                return result?.Code == 1 ? result.Data : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<ResponseMessage> getKeywordReply(string issue)
        {
            var header = new Dictionary<string, object>();

            try
            {
                string url = $"{platformHostUrl}/keyword-reply/{applicationToken}?keyword=";
                // string url = "http://myipv4.melove.icu:18004/api/public/wx-client/bot-reply/08da6c59-b9a7-4ffb-8bdb-1e3e0de3952a?keyword=";
                HttpResponseMessage response = GetHttpClient().GetAsync(url + issue).Result;
                string res = await response.Content.ReadAsStringAsync();
                Console.WriteLine(res);

                var result = JsonConvert.DeserializeObject<ResponseMessage>(res.ToString());

                // 6. 检查返回码是否为1 
                return result ;
            }
            catch (Exception e)
            {
                return null;
            }
        }

      

    }
    public class ResponseMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public bool IsAnalyze { get; set; }
        public string Result { get; set; }
        public string AnalyzeExpression { get; set; }
        public int MessageType { get; set; }
        public string ClosingRemarks { get; set; }
    }
    // 定义API响应模型 
    public class ApiResponse
    {
        public int Code { get; set; }
        public string Data { get; set; }
    }
}
