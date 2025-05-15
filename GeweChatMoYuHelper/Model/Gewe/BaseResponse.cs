using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe
{
     /// <summary>
     /// 登录Token响应基类（所有登录API的通用返回结构）
     /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// 状态码（200=成功，其他值参考错误码表）
        /// </summary>
        [JsonProperty("ret")]
        public int StatusCode { get; set; }

        /// <summary>
        /// 操作消息（成功时为"success"，失败时为错误描述）
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
