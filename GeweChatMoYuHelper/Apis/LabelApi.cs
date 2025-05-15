using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Apis
{
    /**
     * 标签模块
     */
    public class LabelApi
    {


        public OkhttpUtil okhttpUtil;
        public LabelApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
    /// <summary>
    /// 添加标签
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="labelName"></param>
    /// <returns></returns>
        public  async Task<JObject> Add(string appId, string labelName)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["labelName"] = labelName;
            return await okhttpUtil.PostJsonAsync("/label/add", param);
        }

       /// <summary>
       /// 删除标签
       /// </summary>
       /// <param name="appId"></param>
       /// <param name="labelIds"></param>
       /// <returns></returns>
        public  async Task<JObject> Delete(string appId, string labelIds)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["labelIds"] = labelIds;
            return await okhttpUtil.PostJsonAsync("/label/delete", param);
        }

      /// <summary>
      /// 获取标签列表
      /// </summary>
      /// <param name="appId"></param>
      /// <returns></returns>
        public  async Task<JObject> List(string appId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            return await okhttpUtil.PostJsonAsync("/label/list", param);
        }

      /// <summary>
      /// 修改标签成员
      /// </summary>
      /// <param name="appId"></param>
      /// <param name="labelIds"></param>
      /// <param name="wxIds"></param>
      /// <returns></returns>
        public  async Task<JObject> ModifyMemberList(string appId, string labelIds, List<string> wxIds)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["labelIds"] = labelIds;
            param["wxIds"] = JArray.FromObject(wxIds);
            return await okhttpUtil.PostJsonAsync("/label/modifyMemberList", param);
        }
    }
}
