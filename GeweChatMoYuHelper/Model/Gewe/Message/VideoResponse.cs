using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.Message
{  /// <summary>
   /// 接口postVideo的出参实体类。
   /// </summary>
    public class VideoResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public VideoData Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class VideoData
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

        /// <summary>
        /// CDN相关的aeskey，用于加密。
        /// </summary>
        public string AesKey { get; set; }

        /// <summary>
        /// CDN相关的fileid，用于标识文件。
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 视频文件大小，单位字节。
        /// </summary>
        public int Length { get; set; }
    }
}
