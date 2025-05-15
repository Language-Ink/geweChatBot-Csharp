using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.Message
{
    /// <summary>
    /// 接口postAppMsg的出参实体类。
    /// </summary>
    public class AppMsgResponse
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
        public AppMsgData Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class AppMsgData
    {
        /// <summary>
        /// 接收人的wxid，表示消息接收者的wxid标识。
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
