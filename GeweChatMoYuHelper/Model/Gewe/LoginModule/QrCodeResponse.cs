using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.LoginModule
{
    /// <summary>
     /// 登录二维码生成响应（API: /login/getQrCode）
     /// </summary>
    public class QrCodeResponse : BaseResponse
    {
        /// <summary>
        /// 二维码数据对象 
        /// </summary>
        [JsonProperty("data")]
        public QrCodeData Data { get; set; }
    }

    /// <summary>
    /// 二维码数据详情 
    /// </summary>
    public class QrCodeData
    {
        /// <summary>
        /// 微信应用ID（固定值：wx782c26e4c19acffb）
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// 二维码内容URL（用于生成二维码图片）
        /// </summary>
        [JsonProperty("qrData")]
        public string QrContentUrl { get; set; }

        /// <summary>
        /// Base64编码的二维码图片（可直接渲染显示）
        /// </summary>
        [JsonProperty("qrImgBase64")]
        public string QrImageBase64 { get; set; }

        /// <summary>
        /// 唯一会话ID（后续轮询需携带此参数）
        /// </summary>
        [JsonProperty("uuid")]
        public string SessionId { get; set; }
    }
}
