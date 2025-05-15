using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper.Model
{
    public class LoginQrCodeData
    {
        public string appId { get; set; }
        public string qrData { get; set; }
        public string qrImgBase64 { get; set; }
        public string uuid { get; set; }
    
    }
}
