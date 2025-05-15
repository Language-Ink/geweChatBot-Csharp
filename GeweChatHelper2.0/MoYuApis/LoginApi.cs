using GeweChatHelper.Model;
using GeweChatHelper2._0.baseVariables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GeweChatHelper.Apis
{
    public class MoYuLoginApi
    {
        public OkhttpUtil okhttpUtil;
        public MoYuLoginApi()
        {
            okhttpUtil = new OkhttpUtil();
        }
        public MoYuLoginApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
        /// <summary>
        /// 获取tokenId   
        /// </summary>
        /// <returns>获取tokenId 将tokenId 配置到OkhttpUtil 类中的token 属性</returns>
        public async Task<ApiResponse> getTokenData()
        {
            JObject param = new JObject();
            var ss= await okhttpUtil.PostJsonAsync("/tools/getTokenId", param);
            GlobalVariables.Token = ss.ToString();
            return JsonConvert.DeserializeObject<ApiResponse>(ss.ToString());
        }


        /// <summary>
        /// 设置微信消息的回调地址
        /// </summary>
        /// <param name="token"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        public async Task<JObject> setCallback(string token, string callbackUrl)
        {
            JObject param = new JObject();
            param["token"] = GlobalVariables.Token;
            param["callbackUrl"] = callbackUrl;
            return await okhttpUtil.PostJsonAsync("/tools/setCallback", param);
        }

        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <param name="appId"> 设备id 首次登录传空，后续登录传返回的appid</param>
        public async Task<JObject> getLoginQrCode(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/login/getLoginQrCode", param);
        }

        /// <summary>
        /// 获取登录二维码
        /// </summary>
        /// <param name="appId"> 设备id 首次登录传空，后续登录传返回的appid</param>
        public async Task<ApiResponse<LoginQrCodeData>> getLoginQrCodeData(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var  ss= await okhttpUtil.PostJsonAsync("/login/getLoginQrCode", param);
           var data=  JsonConvert.DeserializeObject<ApiResponse<LoginQrCodeData>>(ss.ToString());
            GlobalVariables.UUId = data.Data.uuid;
            GlobalVariables.AppId = data.Data.appId;
            return data;
        }
        /// <summary>
        /// 确认登陆
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="uuid">取码返回的uuid</param>
        /// <param name="captchCode"> 登录验证码（跨省登录会出现此提示，使用同省代理ip能避免此问题，也能使账号更加稳定）</param>
        public async Task<JObject> checkLogin(string appId, string uuid, string captchCode)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["uuid"] = appId;
            param["captchCode"] = appId;
            return await okhttpUtil.PostJsonAsync("/login/checkLogin", param);
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<JObject> logOut(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/login/logout", param);
        }

        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        public async Task<JObject> getDeviceList()
        {
            JObject param = new JObject();
            return await okhttpUtil.PostJsonAsync("/login/deviceList", param);
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
        public async Task<JObject> checkOnline(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/login/checkOnline", param);
        }

    }
}
