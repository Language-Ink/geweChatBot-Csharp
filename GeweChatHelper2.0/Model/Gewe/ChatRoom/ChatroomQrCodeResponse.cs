using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.ChatRoom
{
    /// <summary>
    /// 接口getChatroomQrCode的出参实体类。
    /// </summary>
    public class ChatroomQrCodeResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public ChatroomQrCode Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class ChatroomQrCode
    {
        /// <summary>
        /// 群二维码的Base64编码，表示群二维码的编码信息。
        /// </summary>
        public string QrBase64 { get; set; }

        /// <summary>
        /// 群二维码的提示信息，表示群二维码的提示信息。
        /// </summary>
        public string QrTips { get; set; }
    }
}
