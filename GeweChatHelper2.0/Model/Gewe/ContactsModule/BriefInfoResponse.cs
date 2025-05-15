using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.ContactsModule
{
     public class BriefInfoResponse: BaseResponse
    {
        /// <summary>
        /// 联系人信息列表
        /// </summary>
        public List<ContactInfo> data { get; set; }
    }
    public class ContactInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nickName { get; set; }

        /// <summary>
        /// 拼音首字母
        /// </summary>
        public string pyInitial { get; set; }

        /// <summary>
        /// 全拼
        /// </summary>
        public string quanPin { get; set; }

        /// <summary>
        /// 性别，1为男性，2为女性
        /// </summary>
        public int sex { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 备注拼音首字母
        /// </summary>
        public string remarkPyInitial { get; set; }

        /// <summary>
        /// 备注全拼
        /// </summary>
        public string remarkQuanPin { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// 社交背景图片
        /// </summary>
        public string snsBgImg { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 大头像URL
        /// </summary>
        public string bigHeadImgUrl { get; set; }

        /// <summary>
        /// 小头像URL
        /// </summary>
        public string smallHeadImgUrl { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 卡片图片URL
        /// </summary>
        public string cardImgUrl { get; set; }

        /// <summary>
        /// 标签列表
        /// </summary>
        public string labelList { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 电话号码列表
        /// </summary>
        public List<string> phoneNumList { get; set; }
    }

}
