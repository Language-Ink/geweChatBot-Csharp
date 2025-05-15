using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.Message
{/// <summary>
 /// 接口postText的出参实体类。
 /// </summary>
    public class TextResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public TextData Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class TextData
    {
        /// <summary>
        /// 接收者的wxid，表示消息接收者的wxid标识。
        /// </summary>
        public string ToWxid { get; set; }

        /// <summary>
        /// 发送时间，表示消息发送的时间戳。
        /// </summary>
        public int CreateTime { get; set; }

        /// <summary>
        /// 消息ID，表示消息的唯一标识。
        /// </summary>
        public int MsgId { get; set; }

        /// <summary>
        /// 新消息ID，表示新消息的唯一标识。
        /// </summary>
        public int NewMsgId { get; set; }

        /// <summary>
        /// 消息类型，表示消息的类型标识。
        /// </summary>
        public int Type { get; set; }
    }
}
