using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.PersonModule
{
    /// <summary>
    /// 接口getProfile的出参实体类。
    /// </summary>
    public class ProfileResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public Profile Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 微信号，表示用户的微信号。
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 微信ID，表示用户的微信ID。
        /// </summary>
        public string Wxid { get; set; }

        /// <summary>
        /// 昵称，表示用户的昵称。
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 绑定的手机号，表示用户的绑定手机号。
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// uin，表示用户的uin标识。
        /// </summary>
        public int Uin { get; set; }

        /// <summary>
        /// 性别，表示用户的性别标识。
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 省份，表示用户所在的省份。
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市，表示用户所在的城市。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 签名，表示用户的签名信息。
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 国家，表示用户所在的国家。
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 大头像链接，表示用户大头像的网络地址。
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 小头像链接，表示用户小头像的网络地址。
        /// </summary>
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 注册国家，表示用户注册时所在的国家。
        /// </summary>
        public string RegCountry { get; set; }

        /// <summary>
        /// 朋友圈背景图链接，表示用户朋友圈背景图的网络地址。
        /// </summary>
        public string SnsBgImg { get; set; }
    }
}
