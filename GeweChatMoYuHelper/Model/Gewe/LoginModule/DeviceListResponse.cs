using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.LoginModule
{
    /// <summary>
    /// 设备列表响应实体 
    /// </summary>
    public class DeviceListResponse : BaseResponse
    {
        /// <summary>
        /// 设备信息集合 
        /// </summary>
        [JsonProperty("data")]
        public List<string> Devices { get; set; }

        public class DeviceInfo
        {
            /// <summary>
            /// 设备唯一标识 
            /// </summary>
            [JsonProperty("appId")]
            public string DeviceId { get; set; }

            /// <summary>
            /// 设备名称 
            /// </summary>
            [JsonProperty("deviceName")]
            public string Name { get; set; }

            /// <summary>
            /// 最后活跃时间（UTC时间戳）
            /// </summary>
            [JsonProperty("lastActive")]
            public long LastActiveTime { get; set; }
        }
    }
}
