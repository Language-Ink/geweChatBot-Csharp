
using GeweChatMoYuHelper.baseVariables;
using GeweChatMoYuHelper.Model.Gewe;
using GeweChatMoYuHelper.Model.Gewe.LoginModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Apis
{
    public class LoginApi
    {
        public OkhttpUtil okhttpUtil;
        public LoginApi()
        {
            okhttpUtil = new OkhttpUtil();
        }
        public LoginApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
        public LoginApi(string token, string baseUrl)
        {
            okhttpUtil = new OkhttpUtil(token,baseUrl);
        }
        /// <summary>
        /// 获取tokenId   
        /// </summary>
        /// <returns>获取tokenId 将tokenId 配置到OkhttpUtil 类中的token 属性</returns>
        public async Task<TokenValidationResponse> getToken()
        {
            JObject param = new JObject();
            var ss = await okhttpUtil.PostJsonAsync("/tools/getTokenId", param);
            GlobalVariables.Token = ss.ToString();
            return JsonConvert.DeserializeObject<TokenValidationResponse>(ss.ToString());
        }


        /// <summary>
        /// 设置微信消息的回调地址
        /// </summary>
        /// <param name="token"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        public async Task<BaseResponse> setCallback(string token, string callbackUrl)
        {
            JObject param = new JObject();
            param["token"] = token;
            param["callbackUrl"] = callbackUrl;
            var ss = await okhttpUtil.PostJsonAsync("/tools/setCallback", param);
            return JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
        }

        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <param name="appId"> 设备id 首次登录传空，后续登录传返回的appid</param>
        public async Task<QrCodeResponse> getLoginQrCode(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var ss = await okhttpUtil.PostJsonAsync("/login/getLoginQrCode", param);
            return JsonConvert.DeserializeObject<QrCodeResponse>(ss.ToString());
        }

        /// <summary>
        /// 确认登陆
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="uuid">取码返回的uuid</param>
        /// <param name="captchCode"> 登录验证码（跨省登录会出现此提示，使用同省代理ip能避免此问题，也能使账号更加稳定）</param>
        public async Task<LoginStatusResponse> checkLogin(string appId, string uuid, string captchCode)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["uuid"] = uuid;
            param["captchCode"] = captchCode;
            var ss = await okhttpUtil.PostJsonAsync("/login/checkLogin", param);
            if (ss==null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<LoginStatusResponse>(ss.ToString());
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<BaseResponse> logOut(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var ss = await okhttpUtil.PostJsonAsync("/login/logout", param);
            return JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
        }

        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        public async Task<DeviceListResponse> getDeviceList()
        {
            JObject param = new JObject();
            var ss = await okhttpUtil.PostJsonAsync("/login/deviceList", param);
            var data = JsonConvert.DeserializeObject<DeviceListResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 弹框登录
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<JObject> dialogLogin(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/login/dialogLogin", param);
        }

        /// <summary>
        /// 检查是否在线
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<CheckOnlineResponse> checkOnline(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var ss = await okhttpUtil.PostJsonAsync("/login/checkOnline", param);
            var data = JsonConvert.DeserializeObject<CheckOnlineResponse>(ss.ToString());
            return data;
        }

    }
}
