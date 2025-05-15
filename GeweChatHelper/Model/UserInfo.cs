using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper.Model
{
    public class UserInfo
    {
        /// <summary>
        /// 用户别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 微信ID
        /// </summary>
        public string Wxid { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// UIN（用户唯一标识符，此处为0可能表示未使用或隐藏）
        /// </summary>
        public int Uin { get; set; }

        /// <summary>
        /// 性别（1通常表示男性，2表示女性，0表示未知）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 国家代码
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 大头像URL
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 小头像URL
        /// </summary>
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 注册国家代码
        /// </summary>
        public string RegCountry { get; set; }

        /// <summary>
        /// SNS背景图片URL
        /// </summary>
        public string SnsBgImg { get; set; }
    }

}
