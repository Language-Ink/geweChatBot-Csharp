using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.PersonModule
{ /// <summary>
  /// 接口getQrCode的出参实体类。
  /// </summary>
    public class QrCodeResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public QrCode1 Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class QrCode1
    {
        /// <summary>
        /// 二维码的Base64编码，表示二维码的编码信息。
        /// </summary>
        public string QrCode { get; set; }
    }
}
