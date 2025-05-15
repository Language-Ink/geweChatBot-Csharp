using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Callback
{
    public class AddMsg
    {
        public string TypeName { get; set; } // 消息类型
        public string Appid { get; set; }    // 设备ID
        public string Wxid { get; set; }    // 所属微信的wxid
        public MsgData Data { get; set; }    // 消息数据
    }

    public class MsgData
    {
        [PrimaryKey, AutoIncrement]
        public long MsgId { get; set; }      // 消息ID
        [Ignore]
        public UserName FromUserName { get; set; } // 发送人
        [Ignore]
        public UserName ToUserName { get; set; }   // 接收人

        public int MsgType { get; set; }     // 消息类型（1为文本）
        [Ignore]
        public MsgContent Content { get; set; } // 消息内容

        public int Status { get; set; }
        public int ImgStatus { get; set; }
        [Ignore]
        public ImgBuffer ImgBuf { get; set; }

        public long CreateTime { get; set; } // 消息发送时间（时间戳）

        public string MsgSource { get; set; } // XML格式消息来源

        public string PushContent { get; set; } // 消息通知内容

        public long NewMsgId { get; set; }   // 新消息ID

        public long MsgSeq { get; set; }     // 消息序列号
    }

    // 辅助类
    public class UserName
    {
        public string String { get; set; }
    }

    public class MsgContent
    {
        public string String { get; set; }
    }

    public class ImgBuffer
    {
        public int ILen { get; set; }
    }

}
