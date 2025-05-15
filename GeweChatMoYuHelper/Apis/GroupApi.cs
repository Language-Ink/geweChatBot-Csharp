using GeweChatMoYuHelper.Model.Gewe.ChatRoom;
using GeweChatMoYuHelper.Model.Gewe.LoginModule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Apis
{
    public class GroupApi
    {

        public OkhttpUtil okhttpUtil;
        public GroupApi(string token)
        {
            okhttpUtil = new OkhttpUtil(token);
        }
        /// <summary>
        /// 创建微信群聊
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxids"></param>
        /// <returns></returns>
        public  async Task<JObject> CreateChatroom(string appId, List<string> wxids)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxid"] = JArray.FromObject(wxids);
            return await okhttpUtil.PostJsonAsync("/group/createChatroom", param);

        }
        /// <summary>
        /// 修改群名
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomName"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> ModifyChatroomName(string appId, string chatroomName, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomName"] = chatroomName;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/modifyChatroomName", param);
        }
        /// <summary>
        /// 修改群备注
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomRemark"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> ModifyChatroomRemark(string appId, string chatroomRemark, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomRemark"] = chatroomRemark;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/modifyChatroomRemark", param);
        }
        /// <summary>
        /// 修改群昵称（本人）
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="nickName"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> ModifyChatroomNickNameForSelf(string appId, string nickName, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["nickName"] = nickName;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/modifyChatroomNickNameForSelf", param);
        }
        /// <summary>
        /// 邀请/添加 进群
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxids"></param>
        /// <param name="chatroomId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public  async Task<JObject> InviteMember(string appId, List<string> wxids, string chatroomId, string reason)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxids"] = JArray.FromObject(wxids);
            param["reason"] = reason;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/inviteMember", param);
        }
        /// <summary>
        /// 移除群成员
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="wxids"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> RemoveMember(string appId, List<string> wxids, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxids"] = JArray.FromObject(wxids);
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/removeMember", param);
        }
        /// <summary>
        /// 退出群聊
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> QuitChatroom(string appId, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/quitChatroom", param);
        }
        /// <summary>
        /// 解散群聊
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> DisbandChatroom(string appId, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/disbandChatroom", param);
        }
        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<ChatroomInfoResponse> GetChatroomInfo(string appId, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            var ss = await okhttpUtil.PostJsonAsync("/group/getChatroomInfo", param);
            var data = JsonConvert.DeserializeObject<ChatroomInfoResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 获取群成员列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<ChatroomMemberListResponse> GetChatroomMemberList(string appId, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            var ss = await okhttpUtil.PostJsonAsync("/group/getChatroomMemberList", param);
            var data = JsonConvert.DeserializeObject<ChatroomMemberListResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        ///  获取群成员详情
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <param name="memberWxids"></param>
        /// <returns></returns>
        public  async Task<ChatroomMemberDetailResponse> GetChatroomMemberDetail(string appId, string chatroomId, List<string> memberWxids)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["memberWxids"] = JArray.FromObject(memberWxids);
            param["chatroomId"] = chatroomId;
            var ss = await okhttpUtil.PostJsonAsync("/group/getChatroomMemberDetail", param);
            var data = JsonConvert.DeserializeObject<ChatroomMemberDetailResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        ///  获取群公告
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> GetChatroomAnnouncement(string appId, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/getChatroomAnnouncement", param);
        }
        /// <summary>
        /// 设置群公告
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public  async Task<JObject> SetChatroomAnnouncement(string appId, string chatroomId, string content)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            param["content"] = content;
            return await okhttpUtil.PostJsonAsync("/group/setChatroomAnnouncement", param);
        }
        /// <summary>
        /// 同意进群
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public  async Task<JObject> AgreeJoinRoom(string appId, string url)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomName"] = url;
            return await okhttpUtil.PostJsonAsync("/group/agreeJoinRoom", param);
        }
        /// <summary>
        /// 添加群成员为好友
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="memberWxid"></param>
        /// <param name="chatroomId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public  async Task<JObject> AddGroupMemberAsFriend(string appId, string memberWxid, string chatroomId, string content)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["memberWxid"] = memberWxid;
            param["content"] = content;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/addGroupMemberAsFriend", param);
        }
        /// <summary>
        /// 获取群二维码
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<ChatroomQrCodeResponse> GetChatroomQrCode(string appId, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomId"] = chatroomId;
            var ss= await okhttpUtil.PostJsonAsync("/group/getChatroomQrCode", param);
            var data = JsonConvert.DeserializeObject<ChatroomQrCodeResponse>(ss.ToString());
            return data;
        }
        /// <summary>
        /// 群保存到通讯录
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="operType"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> SaveContractList(string appId, int operType, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["chatroomName"] = operType;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/saveContractList", param);
        }
        /// <summary>
        /// 管理员操作
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="chatroomId"></param>
        /// <param name="wxids"></param>
        /// <param name="operType"></param>
        /// <returns></returns>
        public  async Task<JObject> AdminOperate(string appId, string chatroomId, List<string> wxids, int operType)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["wxids"] = JArray.FromObject(wxids);
            param["operType"] = operType;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/adminOperate", param);
        }
        /// <summary>
        /// 聊天置顶
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="top"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> PinChat(string appId, bool top, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["top"] = top;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/pinChat", param);
        }
        /// <summary>
        /// 设置消息免打扰
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="silence"></param>
        /// <param name="chatroomId"></param>
        /// <returns></returns>
        public  async Task<JObject> SetMsgSilence(string appId, bool silence, string chatroomId)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["silence"] = silence;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/setMsgSilence", param);
        }
        /// <summary>
        /// 扫码进群
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="qrUrl"></param>
        /// <returns></returns>
        public  async Task<JObject> JoinRoomUsingQRCode(string appId, string qrUrl)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["qrUrl"] = qrUrl;
            return await okhttpUtil.PostJsonAsync("/group/joinRoomUsingQRCode", param);
        }
        /// <summary>
        /// 确认进群申请
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="newMsgId"></param>
        /// <param name="chatroomId"></param>
        /// <param name="msgContent"></param>
        /// <returns></returns>

        public  async Task<JObject> RoomAccessApplyCheckApprove(string appId, string newMsgId, string chatroomId, string msgContent)
        {
            JObject param = new JObject();
            param["appId"] = appId;
            param["newMsgId"] = newMsgId;
            param["msgContent"] = msgContent;
            param["chatroomId"] = chatroomId;
            return await okhttpUtil.PostJsonAsync("/group/roomAccessApplyCheckApprove", param);
        }
    }
}
