using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.LoginModule
{/// <summary>
 /// Token验证响应（API: /login/checkToken）
 /// </summary>
    public class TokenValidationResponse : BaseResponse
    {
        /// <summary>
        /// 加密的Token字符串（有效期为24小时）
        /// </summary>
        [JsonProperty("data")]
        public string EncryptedToken { get; set; }
    }
}
