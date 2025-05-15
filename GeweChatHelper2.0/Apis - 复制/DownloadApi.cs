using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using System.Threading.Tasks;


namespace GeweChatHelper.Apis2
{
    /**
     * 下载模块
     */
    public class DownloadApi
    {
        public OkhttpUtil okhttpUtil;
        public DownloadApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }

       /// <summary>
       /// 下载图片
       /// </summary>
       /// <param name="appId"></param>
       /// <param name="xml"></param>
       /// <param name="type"></param>
       /// <returns></returns>
        public  async Task<JObject> downloadImage(string appId, string xml, int type)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["xml"] = xml;
            param["type"] = type;
            return await okhttpUtil.PostJsonAsync("/message/downloadImage", param);
        }

      /// <summary>
      /// 下载语音
      /// </summary>
      /// <param name="appId"></param>
      /// <param name="xml"></param>
      /// <param name="msgId"></param>
      /// <returns></returns>
        public  async Task<JObject> downloadVoice(string appId, string xml, int msgId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["xml"] = xml;
            param["msgId"] = msgId;
            return await okhttpUtil.PostJsonAsync("/message/downloadVoice", param);
        }

      /// <summary>
      /// 下载视频
      /// </summary>
      /// <param name="appId"></param>
      /// <param name="xml"></param>
      /// <returns></returns>
        public  async Task<JObject> downloadVideo(string appId, string xml)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["xml"] = xml;
            return await okhttpUtil.PostJsonAsync("/message/downloadVideo", param);
        }

       /// <summary>
       /// 下载表情
       /// </summary>
       /// <param name="appId"></param>
       /// <param name="emojiMd5"></param>
       /// <returns></returns>
        public  async Task<JObject> downloadEmojiMd5(string appId, string emojiMd5)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["emojiMd5"] = emojiMd5;
            return await okhttpUtil.PostJsonAsync("/message/downloadEmojiMd5", param);
        }
      /// <summary>
      /// 下载图片（CDN）
      /// </summary>
      /// <param name="appId"></param>
      /// <param name="aesKey"></param>
      /// <param name="fileId"></param>
      /// <param name="type"></param>
      /// <param name="totalSize"></param>
      /// <param name="suffix"></param>
      /// <returns></returns>
        public  async Task<JObject> downloadImage(string appId, string aesKey, string fileId, string type, string totalSize, string suffix)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["aesKey"] = aesKey;
            param["appId"] = appId;
            param["fileId"] = fileId;
            param["totalSize"] = totalSize;
            param["type"] = type;
            param["suffix"] = suffix;
            return await okhttpUtil.PostJsonAsync("/message/downloadCdn", param);
        }

    }
}