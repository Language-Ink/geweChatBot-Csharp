using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper.Model
{
    public class ContactUserInfo
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string PyInitial { get; set; }
        public string QuanPin { get; set; }
        public int Sex { get; set; }
        public object Remark { get; set; } // null可表示为可空类型，但这里为简化使用object
        public object RemarkPyInitial { get; set; }
        public object RemarkQuanPin { get; set; }
        public string Signature { get; set; }
        public string Alias { get; set; }
        public string SnsBgImg { get; set; }
        public string Country { get; set; }
        public string BigHeadImgUrl { get; set; }
        public string SmallHeadImgUrl { get; set; }
        public object Description { get; set; }
        public object CardImgUrl { get; set; }
        public object LabelList { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public object PhoneNumList { get; set; }
    }
}
