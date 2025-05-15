using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.ContactsModule
{  /// <summary>
   /// 接口getPhoneAddressList的出参实体类。
   /// </summary>
    public class PhoneAddressListResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public List<PhoneAddress> Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class PhoneAddress
    {
        /// <summary>
        /// 用户名，表示获取到的用户信息。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户昵称，表示获取到的用户昵称信息。
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户性别，表示获取到的用户性别信息。
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户签名，表示获取到的用户签名信息。
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 用户所在省份，表示获取到的用户所在省份信息。
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 用户所在城市，表示获取到的用户所在城市信息。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户电话号码的MD5值，表示获取到的用户电话号码的MD5值信息。
        /// </summary>
        public string PhoneMd5 { get; set; }

        /// <summary>
        /// 用户大头像链接，表示获取到的用户大头像链接信息。
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 用户小头像链接，表示获取到的用户小头像链接信息。
        /// </summary>
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 用户所在国家，表示获取到的用户所在国家信息。
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户个人卡片标识，表示获取到的用户个人卡片标识信息。
        /// </summary>
        public int PersonalCard { get; set; }
    }
}
