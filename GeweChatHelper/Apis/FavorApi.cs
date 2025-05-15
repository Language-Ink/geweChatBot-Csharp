using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GeweChatHelper.Apis
{
    /**
     * 收藏夹模块
     */
    public class FavorApi
    {
        public OkhttpUtil okhttpUtil;
        public FavorApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }


       /// <summary>
       /// 同步收藏夹
       /// </summary>
       /// <param name="appId"></param>
       /// <param name="syncKey"></param>
       /// <returns></returns>
        public  async Task<JObject> sync(string appId, string syncKey)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["syncKey"] = syncKey;
            return await okhttpUtil.PostJsonAsync("/favor/sync", param);
        }

       /// <summary>
       /// 获取收藏夹内容
       /// </summary>
       /// <param name="appId"></param>
       /// <param name="favId"></param>
       /// <returns></returns>
        public  async Task<JObject> getContent(string appId, int favId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["favId"] = favId;
            return await okhttpUtil.PostJsonAsync("/favor/getContent", param);
        }

     /// <summary>
     /// 删除收藏夹
     /// </summary>
     /// <param name="appId"></param>
     /// <param name="favId"></param>
     /// <returns></returns>
        public  async Task<JObject> delete(string appId, int favId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["favId"] = favId;
            return await okhttpUtil.PostJsonAsync("/favor/delete", param);
        }

    }
}
