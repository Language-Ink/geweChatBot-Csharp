using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.ChatRoom
{/// <summary>
 /// 接口getChatroomMemberList的出参实体类。
 /// </summary>
    public class ChatroomMemberListResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public ChatroomMemberList Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class ChatroomMemberList
    {
        /// <summary>
        /// 群成员列表，表示群成员的具体信息。
        /// </summary>
        public MemberInfo[] MemberList { get; set; }
    }

}
