using GeweChatMoYuHelper.Model.Gewe.LoginModule;
using GeweChatMoYuHelper.Model.Gewe.PersonModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Apis
{
    /**
     * 个人模块
     */
    public class PersonalApi
    {
        public OkhttpUtil okhttpUtil;
        public PersonalApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
        /**
         * 获取个人资料
         */
        public async Task<ProfileResponse> getProfile(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var ss= await okhttpUtil.PostJsonAsync("/personal/getProfile", param);
            var data = JsonConvert.DeserializeObject<ProfileResponse>(ss.ToString());
            return data;
        }

        /**
         * 获取自己的二维码
         */
        public async Task<JObject> getQrCode(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/personal/getQrCode", param);
        }

        /**
         * 获取设备记录
         */
        public async Task<JObject> getSafetyInfo(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/personal/getSafetyInfo", param);
        }

        /**
         * 隐私设置
         */
        public async Task<JObject> privacySettings(string appId, int option, bool open)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["option"] = option;
            param["open"] = open;
            return await okhttpUtil.PostJsonAsync("/personal/privacySettings", param);
        }

        /**
         * 修改个人信息
         */
        public async Task<JObject> updateProfile(string appId, string city, string country, string nickName, string province, string sex, string signature)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["city"] = city;
            param["country"] = country;
            param["nickName"] = nickName;
            param["province"] = province;
            param["sex"] = sex;
            return await okhttpUtil.PostJsonAsync("/personal/updateProfile", param);
        }

        /**
         * 修改头像
         */
        public async Task<JObject> updateHeadImg(string appId, string headImgUrl)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["headImgUrl"] = headImgUrl;
            return await okhttpUtil.PostJsonAsync("/personal/updateHeadImg", param);
        }
    }
}
