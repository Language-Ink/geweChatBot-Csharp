using GeweChatHelper.Apis;
using GeweChatHelper.baseVariables;
using GeweChatHelper.db;
using GeweChatHelper.Model;
using GeweChatHelper.Model.Callback;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GeweChatTest
{
    internal class Program
    {
        static HttpListener httpobj;
        static LoginApi loginApi;
        static LoginApi loginApi2;
        static string _token;
        static string _appid;
        static async Task Main(string[] args)
        {
            string envVar = Environment.GetEnvironmentVariable("APPLICTION_TOKEN");
            string envVars = Environment.GetEnvironmentVariable("PLATFORM_HOST_URL");
            Console.WriteLine("Hello, World!");
             loginApi = new LoginApi();
            string ss =( await loginApi.getToken()).ToString();
            var ssdata = await loginApi.getTokenData();
            var entity = JsonConvert.DeserializeObject<ApiResponse>(ss);
            _token=entity.Data as string;
            GlobalVariables.Token = entity.Data as string;
            Console.WriteLine(entity.Data as string);
             loginApi2 = new LoginApi(entity.Data as string);
            if (_appid==null)
            {
               var data= await loginApi2.getDeviceList();
                var entitys = JsonConvert.DeserializeObject<ApiResponse<List<string>>>(data.ToString());
                if (entitys.Data.Count>0)
                {
                    _appid=entitys.Data[0];
                }
            }
            /*var entity2 = JsonConvert.DeserializeObject<ApiResponse<LoginQrCodeData>>((await loginApi2.getLoginQrCode(_appid)).ToString());
            _appid=entity2.Data.appId;
            Console.WriteLine(loginApi2.getLoginQrCode(_appid));*/

            //提供一个简单的、可通过编程方式控制的 HTTP 协议侦听器。此类不能被继承。
            httpobj = new HttpListener();
            //定义url及端口号，通常设置为配置文件
            httpobj.Prefixes.Add("http://+:8089/");
            //启动监听器
            httpobj.Start();
            //异步监听客户端请求，当客户端的网络请求到来时会自动执行Result委托
            //该委托没有返回值，有一个IAsyncResult接口的参数，可通过该参数获取context对象
            httpobj.BeginGetContext(Result, null);
            Console.WriteLine($"服务端初始化完毕，正在等待客户端请求,时间：{DateTime.Now.ToString()}\r\n");
            Console.ReadKey();
            Console.WriteLine(loginApi2.setCallback(entity.Data as string, "http://192.168.9.11:8089/").ToString());

        }





        private static void Result(IAsyncResult ar)
        {
            //当接收到请求后程序流会走到这里

            //继续异步监听
            httpobj.BeginGetContext(Result, null);
            var guid = Guid.NewGuid().ToString();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"接到新的请求:{guid},时间：{DateTime.Now.ToString()}");
            //获得context对象
            var context = httpobj.EndGetContext(ar);
            var request = context.Request;
            var response = context.Response;
            ////如果是js的ajax请求，还可以设置跨域的ip地址与参数
            //context.Response.AppendHeader("Access-Control-Allow-Origin", "*");//后台跨域请求，通常设置为配置文件
            //context.Response.AppendHeader("Access-Control-Allow-Headers", "ID,PW");//后台跨域参数设置，通常设置为配置文件
            //context.Response.AppendHeader("Access-Control-Allow-Method", "post");//后台跨域请求设置，通常设置为配置文件
            context.Response.ContentType = "text/plain;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
            context.Response.AddHeader("Content-type", "text/plain");//添加响应头信息
            context.Response.ContentEncoding = Encoding.UTF8;
            string returnObj = null;//定义返回客户端的信息
            if (request.HttpMethod == "POST" && request.InputStream != null)
            {
                //处理客户端发送的请求并返回处理信息
                returnObj = HandleRequest(request, response);
            }
            else
            {
                returnObj = $"不是post请求或者传过来的数据为空";
            }
            var returnByteArr = Encoding.UTF8.GetBytes(returnObj);//设置客户端返回信息的编码
            try
            {
                using (var stream = response.OutputStream)
                {
                    //把处理信息返回到客户端
                    stream.Write(returnByteArr, 0, returnByteArr.Length);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"网络蹦了：{ex.ToString()}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"请求处理完成：{guid},时间：{DateTime.Now.ToString()}\r\n");
        }

        private static string HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string data = null;
            try
            {
                var byteList = new List<byte>();
                var byteArr = new byte[2048];
                int readLen = 0;
                int len = 0;
                //接收客户端传过来的数据并转成字符串类型
                do
                {
                    readLen = request.InputStream.Read(byteArr, 0, byteArr.Length);
                    len += readLen;
                    byteList.AddRange(byteArr);
                } while (readLen != 0);
                data = Encoding.UTF8.GetString(byteList.ToArray(), 0, len);
                try
                {

                    var authobj = JsonConvert.DeserializeObject<CallBackAuth>(data);
                    if (authobj.token==GlobalVariables.Token)
                    {
                        response.StatusDescription = "200";//获取或设置返回给客户端的 HTTP 状态代码的文本说明。
                        response.StatusCode = 200;// 获取或设置返回给客户端的 HTTP 状态代码。
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"接收数据完成:{data.Trim()},时间：{DateTime.Now.ToString()}");
                        return $"接收数据完成";
                    }
                }
                catch (Exception)
                {
                }
                var obj = JsonConvert.DeserializeObject<AddMsg>(data);
                if (obj.Data.FromUserName.String.Contains("@chatroom"))//群聊
                {
                    SQLiteHelper<MsgData> sQLiteHelper= new SQLiteHelper<MsgData>();
                    if (sQLiteHelper.Query(w => w.NewMsgId == obj.Data.NewMsgId).Count>0)
                    {
                        return "重复消息:"+obj.Data.NewMsgId;
                    }
                    else
                    {
                        sQLiteHelper.Insert(obj.Data);
                    }
                        PersonalApi personalApi = new PersonalApi(_token);
                   var userData= personalApi.getProfile(obj.Appid).Result;

                    var userInfo = JsonConvert.DeserializeObject<ApiResponse<UserInfo>>(userData.ToString());
                    if (obj.Data.Content.String.Contains("@"+ userInfo.Data.NickName))
                    {

                        int mentionIndex = obj.Data.Content.String.IndexOf(("@" + userInfo.Data.NickName + "?"));
                        if (mentionIndex==-1)
                        {
                            mentionIndex = obj.Data.Content.String.IndexOf(("@" + userInfo.Data.NickName));
                        }
                        if (mentionIndex >= 0)
                        {
                            string result = obj.Data.Content.String.Substring(mentionIndex + ("@" + userInfo.Data.NickName + "?").Length).Trim();
                            if (result==null || result.Length == 0|| result=="")
                            {   ContactApi contactApi= new ContactApi(_token);
                                List<string> list = new List<string>();
                                list.Add(obj.Data.Content.String.ToString().Split(":")[0]);
                               var contactdata= contactApi.GetDetailInfo(obj.Appid, list).Result;
                                var contactdatauserInfo = JsonConvert.DeserializeObject<ApiResponse<List<ContactUserInfo>>>(contactdata.ToString());
                                MessageApi messageApi = new MessageApi(_token);
                                messageApi.PostText(obj.Appid, obj.Data.FromUserName.String,"@"+ contactdatauserInfo.Data[0].NickName+"\n1.毒鸡汤(发送“毒鸡汤”，随机干了这碗鸡汤)\n"
                        + "2.天气查询(发送“上海天气”，查询Ta的天气)\n"
                        + "3.故事大全(发送“故事、讲个故事”，即可随机获得一个故事)\n"
                        + "4.成语接龙(发送“成语接龙”，即可进入成语接龙模式)\n"
                        + "5.歇后语(发送“歇后语”，返回短小风趣又像谜语的句子)\n"
                        + "6.笑话大全(发送“笑话、讲个笑话”，让我陪你笑开心)\n"
                        + "7.土味情话(发送“情话、讲个情话”，让我陪你撩心里的TA)\n"
                        + "8.顺口溜(发送“顺口溜”，好听的民俗有趣的轶事)\n"
                        + "9.舔狗日记(发送“舔狗”，随机返回一个舔狗日记)\n"
                        + "10.彩虹屁(发送“彩虹屁”，随机返回一个彩虹屁句子)\n"
                        + "11.切换API(切换，星火，图灵，原神,GPT3)\n", obj.Data.Content.String.ToString().Split(":")[0]);
                            }
                            else
                            {
                                ContactApi contactApi = new ContactApi(_token);
                                List<string> list = new List<string>();
                                list.Add(obj.Data.Content.String.ToString().Split(":")[0]);
                                var contactdata = contactApi.GetDetailInfo(obj.Appid, list).Result;
                                var contactdatauserInfo = JsonConvert.DeserializeObject<ApiResponse<List<ContactUserInfo>>>(contactdata.ToString());
                                OkhttpUtil okhttpUtil = new OkhttpUtil();
                               string ss= okhttpUtil.GetJsonAsync(result).Result.ToString();
                                MessageApi messageApi = new MessageApi(_token);
                                messageApi.PostText(obj.Appid, obj.Data.FromUserName.String, "@" + contactdatauserInfo.Data[0].NickName + "\n"+ ss+"\n", obj.Data.Content.String.ToString().Split(":")[0]);
                            }
                                Console.WriteLine(result); // 输出："今天天气不错"
                        }
                    }//群聊 
                }
                else if (obj.Data.FromUserName.String.Contains("gh_"))//公众号
                {

                }
                else//联系人
                {

                }
                //获取得到数据data可以进行其他操作
            }
            catch (Exception ex)
            {
                response.StatusDescription = "404";
                response.StatusCode = 404;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"在接收数据时发生错误:{ex.ToString()}");
                return $"在接收数据时发生错误:{ex.ToString()}";//把服务端错误信息直接返回可能会导致信息不安全，此处仅供参考
            }
            response.StatusDescription = "200";//获取或设置返回给客户端的 HTTP 状态代码的文本说明。
            response.StatusCode = 200;// 获取或设置返回给客户端的 HTTP 状态代码。
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"接收数据完成:{data.Trim()},时间：{DateTime.Now.ToString()}");
            return $"接收数据完成";
        }
    }
}
