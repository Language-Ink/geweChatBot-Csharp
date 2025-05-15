using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.PersonModule
{ /// <summary>
  /// 接口getSafetyInfo的出参实体类。
  /// </summary>
    public class SafetyInfoResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public SafetyInfo Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class SafetyInfo
    {
        /// <summary>
        /// 设备记录列表，表示设备记录的具体信息。
        /// </summary>
        public DeviceRecord[] List { get; set; }
    }

    /// <summary>
    /// 设备记录类，用于表示设备记录的具体信息。
    /// </summary>
    public class DeviceRecord
    {
        /// <summary>
        /// 设备ID，表示设备的唯一标识。
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// 设备名称，表示设备的名称。
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备类型，表示设备的类型。
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 最后一次操作时间，表示设备最后一次操作的时间戳。
        /// </summary>
        public int LastTime { get; set; }
    }
}
