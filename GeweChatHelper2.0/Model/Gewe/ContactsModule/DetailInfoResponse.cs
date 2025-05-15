using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.ContactsModule
{
    /// <summary>
    /// 接口getDetailInfo的出参实体类。
    /// </summary>
    public class DetailInfoResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public DetailInfo[] Data { get; set; }
    }

    /// <summary>
    /// 业务数据类，用于表示具体的业务信息。
    /// </summary>
    public class DetailInfo
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
        /// 用户拼音缩写，表示获取到的用户拼音缩写信息。
        /// </summary>
        public string PyInitial { get; set; }

        /// <summary>
        /// 用户全拼，表示获取到的用户全拼信息。
        /// </summary>
        public string QuanPin { get; set; }

        /// <summary>
        /// 用户性别，表示获取到的用户性别信息。
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户备注，表示获取到的用户备注信息。
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 用户备注拼音缩写，表示获取到的用户备注拼音缩写信息。
        /// </summary>
        public string RemarkPyInitial { get; set; }

        /// <summary>
        /// 用户备注全拼，表示获取到的用户备注全拼信息。
        /// </summary>
        public string RemarkQuanPin { get; set; }

        /// <summary>
        /// 用户签名，表示获取到的用户签名信息。
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 用户昵称，表示获取到的用户昵称信息。
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 用户社交背景图链接，表示获取到的用户社交背景图链接信息。
        /// </summary>
        public string SnsBgImg { get; set; }

        /// <summary>
        /// 用户所在国家，表示获取到的用户所在国家信息。
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户大头像链接，表示获取到的用户大头像链接信息。
        /// </summary>
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 用户小头像链接，表示获取到的用户小头像链接信息。
        /// </summary>
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 用户描述，表示获取到的用户描述信息。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户卡片图片链接，表示获取到的用户卡片图片链接信息。
        /// </summary>
        public string CardImgUrl { get; set; }

        /// <summary>
        /// 用户标签列表，表示获取到的用户标签列表信息。
        /// </summary>
        public string[] LabelList { get; set; }

        /// <summary>
        /// 用户所在省份，表示获取到的用户所在省份信息。
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 用户所在城市，表示获取到的用户所在城市信息。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户电话号码列表，表示获取到的用户电话号码列表信息。
        /// </summary>
        public string[] PhoneNumList { get; set; }
    }
}
