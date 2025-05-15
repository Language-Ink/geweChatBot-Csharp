using GeweChaMoYutHelper.db;
using GeweChatMoYuHelper.Apis;
using GeweChatMoYuHelper.baseVariables;
using GeweChatMoYuHelper.Model.Callback;
using GeweChatMoYuHelper.Model.Gewe.LoginModule;
using GeweChatMoYuHelper.Model.Gewe.PersonModule;
using GeweChatMoYuHelper.util;
using GeweChatMoYuHelper.wx_bot.Apis;
using GeweChatMoYuHelper.wx_bot.util;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeweMoYuTest
{
    internal class Program
    {
        private static Timer ResultTimer;
        static HttpListener httpobj;
        static LoginApi loginApi = new LoginApi();
        static LoginApi loginApi2;
        static string _token;
        static string _appid;
        static string filePath;
        static int denglu = 0;
        static int huidiaoxiaoxi = 0;
        static GlobalVariablesData globalVariables = new GlobalVariablesData();
        static void Main(string[] args)
        {
            GlobalVariables.BaseUrl = "http://127.0.0.1:2531/v2/api";
            Console.WriteLine("欢迎使用Gewe机器人助手-墨语");

            Timer timer = new Timer(OnTimedEvent, null, 0, 50000);

            httpobj = new HttpListener();
            //定义url及端口号，通常设置为配置文件
            httpobj.Prefixes.Add("http://+:8089/");
            //启动监听器
            httpobj.Start();
            //异步监听客户端请求，当客户端的网络请求到来时会自动执行Result委托
            //该委托没有返回值，有一个IAsyncResult接口的参数，可通过该参数获取context对象
            httpobj.BeginGetContext(Result, null);
            Console.WriteLine($"服务端初始化完毕，正在等待客户端请求,时间：{DateTime.Now.ToString()}\r\n");
            ResultTimer = new Timer(ResultOnTimedEvent, null, 0, 600000);
            while (true)
            {
                Console.ReadKey();
            }

        }

        public static string WriteGlobal()
        {
            globalVariables.AppId = GlobalVariables.AppId;
            globalVariables.UUId = GlobalVariables.UUId;
            globalVariables.BaseUrl = GlobalVariables.BaseUrl;
            globalVariables.Token = GlobalVariables.Token;
            string baseDir = AppDomain.CurrentDomain.BaseDirectory; // 适用于桌面应用 
                                                                    // 构建文件路径（使用Path.Combine避免路径拼接问题）
            filePath = Path.Combine(baseDir, "Config", "PeiZhi.txt");
            string ssss = JsonConvert.SerializeObject(globalVariables);
                // 确保目录存在（自动创建父目录）
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                // 创建新文件并写入示例内容 
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(ssss);
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("文件已创建：{0}", filePath);
            return JsonConvert.SerializeObject(globalVariables);
        }
        public static GlobalVariablesData ReadGlobal() 
        {

            // 获取当前工作目录（根据应用类型调整）
            string baseDir = AppDomain.CurrentDomain.BaseDirectory; // 适用于桌面应用 
                                                                    // 构建文件路径（使用Path.Combine避免路径拼接问题）
            filePath = Path.Combine(baseDir, "Config", "PeiZhi.txt");
            // 检查文件是否存在 
            if (File.Exists(filePath))
            {  // 读取现有文件内容 
                try
                {
                    string content = File.ReadAllText(filePath);
                    globalVariables = JsonConvert.DeserializeObject<GlobalVariablesData>(content);
                    if (globalVariables != null && globalVariables.BaseUrl != null)
                    {
                        GlobalVariables.BaseUrl = globalVariables.BaseUrl;
                    }
                    if (globalVariables != null && globalVariables.AppId != null)
                    {
                        GlobalVariables.AppId = globalVariables.AppId;
                    }
                    if (globalVariables != null && globalVariables.Token != null)
                    {
                        GlobalVariables.Token = globalVariables.Token;
                    }
                    GlobalVariables.UUId = globalVariables.UUId;
                    return globalVariables;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private static async void ResultOnTimedEvent(object state)
        {
            if (huidiaoxiaoxi==1)
            {
                return;
            }
            loginApi = new LoginApi(GlobalVariables.Token);
           await loginApi.setCallback(GlobalVariables.Token, "http://192.168.245.152:8089/");
            huidiaoxiaoxi = 1;
        }
        private static async void OnTimedEvent(object state)
        {
            if (denglu!=0) 
            {
                Console.WriteLine("正在执行中");
                return;
            }
            denglu = 1;
            Console.WriteLine($"定时触发: {DateTime.Now}");
            GlobalVariablesData globalVariables = ReadGlobal();

            //开始检测是否登录
            GlobalVariables.Token = (await loginApi.getToken()).EncryptedToken;
            loginApi = new LoginApi(GlobalVariables.Token);
           

            loginApi = new LoginApi(GlobalVariables.Token);
            //获取是否有设备
            DeviceListResponse deviceListResponse = await loginApi.getDeviceList();
            if (deviceListResponse.Devices == null || deviceListResponse.Devices.Count < 1)
            {
                loginApi = new LoginApi(GlobalVariables.Token);
                QrCodeResponse qrCodeResponse = await loginApi.getLoginQrCode("");
                if (GlobalVariables.AppId == null || GlobalVariables.AppId == "")
                {
                    GlobalVariables.AppId = qrCodeResponse.Data.AppId;
                }
                GlobalVariables.UUId = qrCodeResponse.Data.SessionId;
                Base64ToImageHelper.Output(qrCodeResponse.Data.QrContentUrl);
            }
            else
            {
                CheckOnlineResponse checkOnlineResponse = await loginApi.checkOnline(GlobalVariables.AppId);
                if (checkOnlineResponse.Data == true)
                {
                    return;
                }
                GlobalVariables.AppId = deviceListResponse.Devices[0];
                loginApi = new LoginApi(GlobalVariables.Token);
                QrCodeResponse qrCodeResponse = await loginApi.getLoginQrCode(GlobalVariables.AppId);
                if (qrCodeResponse.Message.Contains("微信已登录"))
                {
                    return;
                }
                GlobalVariables.UUId = qrCodeResponse.Data.SessionId;
                Base64ToImageHelper.Output(qrCodeResponse.Data.QrContentUrl);
            }
            Thread.Sleep(20000);
            loginApi = new LoginApi(GlobalVariables.Token);
            LoginStatusResponse loginStatusResponse = await loginApi.checkLogin(GlobalVariables.AppId, GlobalVariables.UUId, "");
            loginApi = new LoginApi(GlobalVariables.Token);
            loginApi.setCallback(GlobalVariables.Token, "http://192.168.163.152:8089/");
            denglu = 0;
            Console.WriteLine("执行结束");
            return;
        }

        private static async void OnTimedEvent1(object state)
        {
            Console.WriteLine($"定时触发: {DateTime.Now}");
            GlobalVariablesData globalVariables = ReadGlobal();
           
            //开始检测是否登录
            GlobalVariables.Token = (await loginApi.getToken()).EncryptedToken;
            loginApi=new LoginApi(GlobalVariables.Token, GlobalVariables.BaseUrl);
            if (GlobalVariables.AppId != null && GlobalVariables.UUId !=null && GlobalVariables.UUId !=""&& GlobalVariables.AppId != "")
            {
                if (globalVariables == null)
                {
                    WriteGlobal();
                }
                CheckOnlineResponse checkOnlineResponse = await loginApi.checkOnline(GlobalVariables.AppId); 
                if (checkOnlineResponse != null && checkOnlineResponse.Data == false)
                {
                    QrCodeResponse qrCodeResponse = await loginApi.getLoginQrCode(GlobalVariables.AppId);
                    GlobalVariables.UUId = qrCodeResponse.Data.SessionId;
                    Base64ToImageHelper.Output(qrCodeResponse.Data.QrContentUrl);

                    if (globalVariables == null)
                    {
                        WriteGlobal();
                    }
                    Thread.Sleep(20000);
                    LoginStatusResponse loginStatusResponse = await loginApi.checkLogin(GlobalVariables.AppId, GlobalVariables.UUId, "");
                    if (loginStatusResponse==null)
                    {

                    }
                    return;
                }
            }
            if (GlobalVariables.AppId != null&& GlobalVariables.AppId != "") 
            {
                CheckOnlineResponse checkOnlineResponse = await loginApi.checkOnline(GlobalVariables.AppId);
                if (checkOnlineResponse != null && checkOnlineResponse.Data == false)
                {
                    QrCodeResponse qrCodeResponse = await loginApi.getLoginQrCode(GlobalVariables.AppId);
                    GlobalVariables.UUId = qrCodeResponse.Data.SessionId;
                    Base64ToImageHelper.Output(qrCodeResponse.Data.QrContentUrl);

                    if (globalVariables == null)
                    {
                        WriteGlobal();
                    }
                    Thread.Sleep(5000);
                    LoginStatusResponse loginStatusResponse = await loginApi.checkLogin(GlobalVariables.AppId, GlobalVariables.UUId, "");
                    return;
                }
            }
            loginApi = new LoginApi(GlobalVariables.Token);
            //获取是否有设备
            DeviceListResponse deviceListResponse = await loginApi.getDeviceList();
            if (deviceListResponse.Devices == null || deviceListResponse.Devices.Count < 1)
            {
                QrCodeResponse qrCodeResponse = await loginApi.getLoginQrCode("");
                if (GlobalVariables.AppId==null || GlobalVariables.AppId=="")
                {
                    GlobalVariables.AppId = qrCodeResponse.Data.AppId;
                }
                GlobalVariables.UUId = qrCodeResponse.Data.SessionId;
                Base64ToImageHelper.Output(qrCodeResponse.Data.QrContentUrl);

                if (globalVariables.UUId == null)
                {
                    WriteGlobal();
                }
                Thread.Sleep(5000);
                LoginStatusResponse loginStatusResponse= await loginApi.checkLogin(GlobalVariables.AppId, GlobalVariables.UUId,"");
                return;
            }
            else
            {
                GlobalVariables.AppId = deviceListResponse.Devices[0];
                CheckOnlineResponse checkOnlineResponse=await loginApi.checkOnline(deviceListResponse.Devices[0]);
                if (checkOnlineResponse != null&& checkOnlineResponse.Data==false) 
                {
                    QrCodeResponse qrCodeResponse = await loginApi.getLoginQrCode(GlobalVariables.AppId);
                    GlobalVariables.UUId = qrCodeResponse.Data.SessionId;
                    Base64ToImageHelper.Output(qrCodeResponse.Data.QrContentUrl);

                        WriteGlobal();
                    Thread.Sleep(5000);
                    LoginStatusResponse loginStatusResponse = await loginApi.checkLogin(GlobalVariables.AppId, GlobalVariables.UUId, "");
                    return;
                }
            }
        }
        private static async void Result(IAsyncResult ar)
        {
            //当接收到请求后程序流会走到这里
            huidiaoxiaoxi = 1;
           
            ResultTimer.Change(0, 600000);

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
                returnObj =await HandleRequest(request, response);
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

        private static async Task<string> HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
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
                    if (authobj.token == GlobalVariables.Token)
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

                SQLiteHelper<MsgData> sQLiteHelper = new SQLiteHelper<MsgData>();
                if (sQLiteHelper.Query(w => w.NewMsgId == obj.Data.NewMsgId).Count > 0)
                {
                    return "重复消息:" + obj.Data.NewMsgId;
                }
                else
                {
                    sQLiteHelper.Insert(obj.Data);
                    if (obj.Data.FromUserName.String.Contains("@chatroom"))//群聊
                    {

                        PersonalApi personalApi = new PersonalApi(GlobalVariables.Token);
                        ProfileResponse userData = personalApi.getProfile(obj.Appid).Result;
                        if (obj.Data.Content.String.Contains("@" + userData.Data.NickName))
                        {
                            int mentionIndex = obj.Data.Content.String.IndexOf(("@" + userData.Data.NickName + "?"));
                            if (mentionIndex == -1)
                            {
                                mentionIndex = obj.Data.Content.String.IndexOf(("@" + userData.Data.NickName));
                            }
                            if (mentionIndex >= 0)
                            {
                                string result = obj.Data.Content.String.Substring(mentionIndex + ("@" + userData.Data.NickName + "?").Length).Trim();
                                if (result == null || result.Length == 0 || result == "")
                                {
                                    ContactApi contactApi = new ContactApi(GlobalVariables.Token);
                                    List<string> list = new List<string>();
                                    list.Add(obj.Data.Content.String.ToString().Split(":")[0]);
                                    var contactdata = contactApi.GetDetailInfo(obj.Appid, list).Result;
                                    MessageApi messageApi = new MessageApi(GlobalVariables.Token);
                                  await  messageApi.PostText(obj.Appid, obj.Data.FromUserName.String, "@" + contactdata.Data[0].NickName + "\n1.毒鸡汤(发送“毒鸡汤”，随机干了这碗鸡汤)\n"
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
                                    var service = new KeywordReplyService();
                                    ContactApi contactApi = new ContactApi(GlobalVariables.Token);
                                    List<string> list = new List<string>();
                                    list.Add(obj.Data.Content.String.ToString().Split(":")[0]);
                                    var contactdata = contactApi.GetDetailInfo(obj.Appid, list).Result;
                                    OkhttpUtil okhttpUtil = new OkhttpUtil();
                                    //string ss = okhttpUtil.GetJsonAsync(result).Result.ToString();
                                    var replyContent = await service.getKeywordReply(result);
                                    if (replyContent != null)
                                    {
                                        Console.WriteLine("关键字回复："+ replyContent);
                                       // ArtTemplateRenderer artTemplateRenderer = new ArtTemplateRenderer();
                                      string sss= JNTemplateHelper.ReplaceTokens(replyContent.Data.AnalyzeExpression, replyContent.Data.Result);
                                        MessageApi messageApi = new MessageApi(GlobalVariables.Token);
                                        await messageApi.PostText(obj.Appid, obj.Data.FromUserName.String, "@" + contactdata.Data[0].NickName + "\n" + sss + "\n", obj.Data.Content.String.ToString().Split(":")[0]);

                                    }
                                    else
                                    {
                                        //调用机器人回复
                                        string ss = await service.getBotReply(result);
                                        Console.WriteLine("机器人回复：" + ss);
                                        MessageApi messageApi = new MessageApi(GlobalVariables.Token);
                                        await messageApi.PostText(obj.Appid, obj.Data.FromUserName.String, "@" + contactdata.Data[0].NickName + "\n" + ss + "\n", obj.Data.Content.String.ToString().Split(":")[0]);

                                    }
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
