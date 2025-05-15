using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.ChatRoom
{
    /// <summary>
    /// 接口getChatroomMemberDetail的出参实体类。
    /// </summary>
    public class ChatroomMemberDetailResponse:BaseResponse
    {
        /// <summary>
        /// 返回码，通常用于表示接口调用是否成功。
        /// </summary>
        public int Ret { get; set; }

        /// <summary>
        /// 返回信息，通常包含操作结果的描述。
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public ChatroomMemberDetail Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class ChatroomMemberDetail
    {
        /// <summary>
        /// 用户名，表示群成员的wxid标识。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称，表示群成员的昵称。
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户拼音缩写，表示群成员的拼音缩写。
        /// </summary>
        public string PyInitial { get; set; }

        /// <summary>
        /// 用户全拼，表示群成员的全拼。
        /// </summary>
        public string QuanPin { get; set; }

        /// <summary>
        /// 性别，表示群成员的性别标识。
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 备注，表示群成员的备注信息。
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 备注的拼音首字母，表示群成员备注的拼音首字母。
        /// </summary>
        public string RemarkPyInitial { get; set; }

        /// <summary>
        /// 备注的全拼，表示群成员备注的全拼。
        /// </summary>
        public string RemarkQuanPin { get; set; }

        /// <summary>
        /// 是否通知，表示群成员是否接收群消息的标识。
        /// </summary>
        public int ChatRoomNotify { get; set; }

        /// <summary>
        /// 签名，表示群成员的签名信息。
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 别名，表示群成员的别名信息。
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 社交背景图链接，表示群成员社交背景图的网络地址。
        /// </summary>
        public string SnsBgImg { get; set; }

        /// <summary>
        /// 大头像链接，表示群成员大头像的网络地址。
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 小头像链接，表示群成员小头像的网络地址。
        /// </summary>
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 国家，表示群成员所在国家信息。
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 省份，表示群成员所在省份信息。
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市，表示群成员所在城市信息。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 电话号码列表，表示群成员的电话号码列表信息。
        /// </summary>
        public string[] PhoneNumList { get; set; }

        /// <summary>
        /// 好友的wxid，表示群成员好友的wxid标识。
        /// </summary>
        public string FriendUserName { get; set; }

        /// <summary>
        /// 邀请人的wxid，表示邀请该成员入群的wxid标识。
        /// </summary>
        public string InviterUserName { get; set; }

        /// <summary>
        /// 成员标识，表示群成员的标识。
        /// </summary>
        public int MemberFlag { get; set; }
    }
}
