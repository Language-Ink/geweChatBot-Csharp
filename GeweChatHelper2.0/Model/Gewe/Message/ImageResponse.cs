using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.Message
{/// <summary>
 /// 接口postImage的出参实体类。
 /// </summary>
    public class ImageResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public ImageData Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class ImageData
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
        /// 图片文件大小，单位字节。
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 图片宽度，单位像素。
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 图片高度，单位像素。
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 图片的MD5值，用于校验文件完整性。
        /// </summary>
        public string Md5 { get; set; }
    }
}
