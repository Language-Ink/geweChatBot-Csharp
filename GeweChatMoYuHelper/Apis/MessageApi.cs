using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Apis
{
    /**
     * 消息模块
     */
    public class MessageApi
    {
        public OkhttpUtil okhttpUtil;
        public MessageApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
        /**
     * 发送文字消息
     */
        public  async Task<JObject> PostText(string appId, string toWxid, string content, string ats)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["content"] = content;
            param["ats"] = ats;
            return await okhttpUtil.PostJsonAsync("/message/postText", param);
        }

        /**
         * 发送文件消息
         */
        public  async Task<JObject> PostFile(string appId, string toWxid, string fileUrl, string fileName)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["fileUrl"] = fileUrl;
            param["fileName"] = fileName;
            return await okhttpUtil.PostJsonAsync("/message/postFile", param);
        }

        /**
         * 发送图片消息
         */
        public  async Task<JObject> PostImage(string appId, string toWxid, string imgUrl)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["imgUrl"] = imgUrl;
            return await okhttpUtil.PostJsonAsync("/message/postImage", param);
        }

        /**
         * 发送语音消息
         */
        public  async Task<JObject> PostVoice(string appId, string toWxid, string voiceUrl, int voiceDuration)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["voiceUrl"] = voiceUrl;
            param["voiceDuration"] = voiceDuration;
            return await okhttpUtil.PostJsonAsync("/message/postVoice", param);
        }

        /**
         * 发送视频消息
         */
        public  async Task<JObject> PostVideo(string appId, string toWxid, string videoUrl, string thumbUrl, int videoDuration)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["videoUrl"] = videoUrl;
            param["thumbUrl"] = thumbUrl;
            param["videoDuration"] = videoDuration;
            return await okhttpUtil.PostJsonAsync("/message/postVideo", param);
        }

        /**
         * 发送链接消息
         */
        public  async Task<JObject> PostLink(string appId, string toWxid, string title, string desc, string linkUrl, string thumbUrl)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["title"] = title;
            param["desc"] = desc;
            param["linkUrl"] = linkUrl;
            param["thumbUrl"] = thumbUrl;
            return await okhttpUtil.PostJsonAsync("/message/postLink", param);
        }

        /**
         * 发送名片消息
         */
        public  async Task<JObject> PostNameCard(string appId, string toWxid, string nickName, string nameCardWxid)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["nickName"] = nickName;
            param["nameCardWxid"] = nameCardWxid;
            return await okhttpUtil.PostJsonAsync("/message/postNameCard", param);
        }

        /**
         * 发送emoji消息
         */
        public  async Task<JObject> PostEmoji(string appId, string toWxid, string emojiMd5, string emojiSize)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["emojiMd5"] = emojiMd5;
            param["emojiSize"] = emojiSize;
            return await okhttpUtil.PostJsonAsync("/message/postEmoji", param);
        }

        /**
         * 发送appmsg消息
         */
        public  async Task<JObject> PostAppMsg(string appId, string toWxid, string appmsg)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["appmsg"] = appmsg;
            return await okhttpUtil.PostJsonAsync("/message/postAppMsg", param);
        }

        /**
         * 发送小程序消息
         */
        public  async Task<JObject> PostMiniApp(string appId, string toWxid, string miniAppId, string displayName, string pagePath, string coverImgUrl, string title, string userName)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["miniAppId"] = miniAppId;
            param["displayName"] = displayName;
            param["pagePath"] = pagePath;
            param["coverImgUrl"] = coverImgUrl;
            param["title"] = title;
            param["userName"] = userName;
            return await okhttpUtil.PostJsonAsync("/message/postMiniApp", param);
        }

        /**
         * 转发文件
         */
        public  async Task<JObject> ForwardFile(string appId, string toWxid, string xml)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["xml"] = xml;
            return await okhttpUtil.PostJsonAsync("/message/forwardFile", param);
        }

        /**
         * 转发图片
         */
        public  async Task<JObject> ForwardImage(string appId, string toWxid, string xml)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["xml"] = xml;
            return await okhttpUtil.PostJsonAsync("/message/forwardImage", param);
        }

        /**
         * 转发视频
         */
        public  async Task<JObject> ForwardVideo(string appId, string toWxid, string xml)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["xml"] = xml;
            return await okhttpUtil.PostJsonAsync("/message/forwardVideo", param);
        }

        /**
         * 转发链接
         */
        public  async Task<JObject> ForwardUrl(string appId, string toWxid, string xml)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["xml"] = xml;
            return await okhttpUtil.PostJsonAsync("/message/forwardUrl", param);
        }

        /**
         * 转发小程序
         */
        public  async Task<JObject> ForwardMiniApp(string appId, string toWxid, string xml, string coverImgUrl)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["xml"] = xml;
            param["coverImgUrl"] = coverImgUrl;
            return await okhttpUtil.PostJsonAsync("/message/forwardMiniApp", param);
        }

        /**
         * 撤回消息
         */
        public  async Task<JObject> RevokeMsg(string appId, string toWxid, string msgId, string newMsgId, string createTime)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["toWxid"] = toWxid;
            param["msgId"] = msgId;
            param["newMsgId"] = newMsgId;
            param["createTime"] = createTime;
            return await okhttpUtil.PostJsonAsync("/message/revokeMsg", param);
        }
    }
}
