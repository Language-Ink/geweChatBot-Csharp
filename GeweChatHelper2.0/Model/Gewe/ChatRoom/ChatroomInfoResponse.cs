using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.ChatRoom
{/// <summary>
 /// 接口getChatroomInfo的出参实体类。
 /// </summary>
    public class ChatroomInfoResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public ChatroomInfo Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class ChatroomInfo
    {
        /// <summary>
        /// 群ID，表示获取到的群聊ID。
        /// </summary>
        public string ChatroomId { get; set; }

        /// <summary>
        /// 群名称，表示获取到的群聊名称。
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 群名称的拼音首字母，表示获取到的群聊名称的拼音首字母。
        /// </summary>
        public string PyInitial { get; set; }

        /// <summary>
        /// 群名称的全拼，表示获取到的群聊名称的全拼。
        /// </summary>
        public string QuanPin { get; set; }

        /// <summary>
        /// 性别，表示群的性别标识。
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 备注，表示群的备注信息。
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 备注的拼音首字母，表示群备注的拼音首字母。
        /// </summary>
        public string RemarkPyInitial { get; set; }

        /// <summary>
        /// 备注的全拼，表示群备注的全拼。
        /// </summary>
        public string RemarkQuanPin { get; set; }

        /// <summary>
        /// 是否通知，表示群消息是否通知的标识。
        /// </summary>
        public int ChatRoomNotify { get; set; }

        /// <summary>
        /// 群主的wxid，表示群主的wxid标识。
        /// </summary>
        public string ChatRoomOwner { get; set; }

        /// <summary>
        /// 群头像链接，表示群头像的网络地址。
        /// </summary>
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 成员列表，表示群成员的列表信息。
        /// </summary>
        public MemberInfo[] MemberList { get; set; }
    }

    /// <summary>
    /// 成员信息类，用于表示群成员的具体信息。
    /// </summary>
    public class MemberInfo
    {
        /// <summary>
        /// 成员的wxid，表示群成员的wxid标识。
        /// </summary>
        public string Wxid { get; set; }

        /// <summary>
        /// 成员的昵称，表示群成员的昵称。
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 邀请人的wxid，表示邀请该成员入群的wxid标识。
        /// </summary>
        public string InviterUserName { get; set; }

        /// <summary>
        /// 成员标识，表示群成员的标识。
        /// </summary>
        public int MemberFlag { get; set; }

        /// <summary>
        /// 显示名称，表示群成员在群内的显示名称。
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 大头像链接，表示群成员大头像的网络地址。
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 小头像链接，表示群成员小头像的网络地址。
        /// </summary>
        public string SmallHeadImgUrl { get; set; }
    }
}
