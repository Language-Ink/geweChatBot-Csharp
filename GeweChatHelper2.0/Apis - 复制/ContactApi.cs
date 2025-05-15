using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeweChatHelper.Apis2
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
        public  async Task<JObject> A(string appId)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        return  await okhttpUtil.PostJsonAsync("/login/checkOnline", param);
    }
        /// <summary>
        /// 获取通讯录列表
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>

    public  async Task<JObject> FetchContactsList(string appId)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        return  await okhttpUtil.PostJsonAsync("/contacts/fetchContactsList", param);
    }

    public  async Task<JObject> GetBriefInfo(string appId, List<string> wxids)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["wxids"] = new JArray(wxids);
        return  await okhttpUtil.PostJsonAsync("/contacts/getBriefInfo", param);
    }

    public  async Task<JObject> GetDetailInfo(string appId, List<string> wxids)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["wxids"] = new JArray(wxids);
        return  await okhttpUtil.PostJsonAsync("/contacts/getDetailInfo", param);
    }

    public  async Task<JObject> SearchAsync(string appId, string contactsInfo)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["contactsInfo"] = contactsInfo;
        return await okhttpUtil.PostJsonAsync("/contacts/search", param);
    }

    public  async Task<JObject> AddContacts(string appId, int scene, int option, string v3, string v4, string content)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["scene"] = scene;
        param["option"] = option;
        param["v3"] = v3;
        param["v4"] = v4;
        param["content"] = content;
        return await okhttpUtil.PostJsonAsync("/contacts/addContacts", param);
    }

    public  async Task<JObject> DeleteFriend(string appId, string wxid)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["wxid"] = wxid;
        return await  okhttpUtil.PostJsonAsync("/contacts/deleteFriend", param);
    }

    public  async Task<JObject> SetFriendPermissionsAsync(string appId, string wxid, bool onlyChat)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["wxid"] = wxid;
        param["onlyChat"] = onlyChat;
        return await okhttpUtil.PostJsonAsync("/contacts/setFriendPermissions", param);
    }

    public  async Task<JObject> SetFriendRemarkAsync(string appId, string wxid, string remark)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["wxid"] = wxid;
        param["remark"] = remark;
        return await okhttpUtil.PostJsonAsync("/contacts/setFriendRemark", param);
    }

    public  async Task<JObject> GetPhoneAddressList(string appId, List<string> phones)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["phones"] = new JArray(phones);
        return await okhttpUtil.PostJsonAsync("/contacts/getPhoneAddressList", param);
    }

    public  async Task<JObject> UploadPhoneAddressList(string appId, List<string> phones, int opType)
    {
        JObject param = new JObject();
        param["appId"] = appId;
        param["phones"] = new JArray(phones);
        param["opType"] = opType;
        return await okhttpUtil.PostJsonAsync("/contacts/uploadPhoneAddressList", param);
    }
}
}