using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

public class OkhttpUtil1
{
    public const string BaseUrl = "http://192.168.7.23:2531/v2/api";
    public  string Token = "";

    public static HttpClient GetHttpClient()
    {

        HttpClient client = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        return client;
    }
    public OkhttpUtil1( string token)
    {
        Token = token;
    }
    public OkhttpUtil1()
    {
    }

    public  async Task<JObject> PostJsonAsync(string route, JObject param)
    {
        var header = new Dictionary<string, object>();
        if (!string.IsNullOrEmpty(Token))
        {
            header.Add("X-GEWE-TOKEN", Token);
        }

        try
        {
            if (string.IsNullOrEmpty(BaseUrl))
            {
                throw new Exception("baseUrl 未配置");
            }

            string url = BaseUrl + route;
            var content = new StringContent(param.ToString(), System.Text.Encoding.UTF8, "application/json");

            foreach (var kvp in header)
            {
                content.Headers.Add(kvp.Key, kvp.Value.ToString());
            }

            HttpResponseMessage response =  GetHttpClient().PostAsync(url, content).Result;
            string res = await response.Content.ReadAsStringAsync();
            Console.WriteLine(res);

            JObject jsonObject = JObject.Parse(res);
            if (jsonObject.ContainsKey("ret") && jsonObject["ret"].ToString() == "200")
            {
                return jsonObject;
            }
            else if (jsonObject.ContainsKey("ret") && jsonObject["ret"].ToString() == "500") 
            {
                return jsonObject;
            }
            else
            {
                throw new Exception(res);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("url=" + BaseUrl + route);
            throw new Exception(e.Message);
        }
    }

    public async Task<JObject> GetJsonAsync(string issue)
    {
        var header = new Dictionary<string, object>();

        try
        {
            string url = "http://myipv4.melove.icu:18004/api/public/wx-client/bot-reply/08da6c59-b9a7-4ffb-8bdb-1e3e0de3952a?keyword=";
            HttpResponseMessage response = GetHttpClient().GetAsync(url+ issue).Result;
            string res = await response.Content.ReadAsStringAsync();
            Console.WriteLine(res);

            JObject jsonObject = JObject.Parse(res);
            if (jsonObject.ContainsKey("code") && jsonObject["code"].ToString() == "1")
            {
                return jsonObject;
            }
            else
            {
                throw new Exception(res);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}