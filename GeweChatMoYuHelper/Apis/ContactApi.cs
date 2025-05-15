using GeweChatMoYuHelper.Model.Gewe;
using GeweChatMoYuHelper.Model.Gewe.ContactsModule;
using GeweChatMoYuHelper.Model.Gewe.LoginModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Apis
{

    public class ContactApi
    {
        public OkhttpUtil okhttpUtil;
        public ContactApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
        /// <summary>
        /// 检测是否在线
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<CheckOnlineResponse> A(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var ss = await okhttpUtil.PostJsonAsync("/login/checkOnline", param);
            var data = JsonConvert.DeserializeObject<CheckOnlineResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 获取通讯录列表
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>

        public async Task<ContactsListResponse> FetchContactsList(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/fetchContactsList", param);
            var data = JsonConvert.DeserializeObject<ContactsListResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 获取好友/群简要信息
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxids"></param>
        /// <returns></returns>
        public async Task<BriefInfoResponse> GetBriefInfo(string appId, List<string> wxids)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxids"] = new JArray(wxids);
            var ss = await okhttpUtil.PostJsonAsync("/contacts/getBriefInfo", param);
            var data = JsonConvert.DeserializeObject<BriefInfoResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 获取好友/群详细信息
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxids"></param>
        /// <returns></returns>
        public async Task<DetailInfoResponse> GetDetailInfo(string appId, List<string> wxids)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxids"] = new JArray(wxids);
            var ss = await okhttpUtil.PostJsonAsync("/contacts/getDetailInfo", param);
            var data = JsonConvert.DeserializeObject<DetailInfoResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 搜索好友
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="contactsInfo"></param>
        /// <returns></returns>
        public async Task<SearchResponse> SearchAsync(string appId, string contactsInfo)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["contactsInfo"] = contactsInfo;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/search", param);
            var data = JsonConvert.DeserializeObject<SearchResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="scene"></param>
        /// <param name="option"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<BaseResponse> AddContacts(string appId, int scene, int option, string v3, string v4, string content)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["scene"] = scene;
            param["option"] = option;
            param["v3"] = v3;
            param["v4"] = v4;
            param["content"] = content;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/addContacts", param);
            var data = JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxid"></param>
        /// <returns></returns>
        public async Task<BaseResponse> DeleteFriend(string appId, string wxid)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxid"] = wxid;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/deleteFriend", param);
            var data = JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 设置好友仅聊天
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxid"></param>
        /// <param name="onlyChat"></param>
        /// <returns></returns>
        public async Task<BaseResponse> SetFriendPermissionsAsync(string appId, string wxid, bool onlyChat)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxid"] = wxid;
            param["onlyChat"] = onlyChat;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/setFriendPermissions", param);
            var data = JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 设置好友备注
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxid"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public async Task<BaseResponse> SetFriendRemarkAsync(string appId, string wxid, string remark)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxid"] = wxid;
            param["remark"] = remark;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/setFriendRemark", param);
            var data = JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 获取手机通讯录
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="phones"></param>
        /// <returns></returns>
        public async Task<PhoneAddressListResponse> GetPhoneAddressList(string appId, List<string> phones)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["phones"] = new JArray(phones);
            var ss = await okhttpUtil.PostJsonAsync("/contacts/getPhoneAddressList", param);
            var data = JsonConvert.DeserializeObject<PhoneAddressListResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 上传手机通讯录
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="phones"></param>   
        /// <param name="opType"></param>
        /// <returns></returns>
        public async Task<BaseResponse> UploadPhoneAddressList(string appId, List<string> phones, int opType)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["phones"] = new JArray(phones);
            param["opType"] = opType;
            var ss = await okhttpUtil.PostJsonAsync("/contacts/uploadPhoneAddressList", param);
            var data = JsonConvert.DeserializeObject<BaseResponse>(ss.ToString());
            return data;
        }
    }
}